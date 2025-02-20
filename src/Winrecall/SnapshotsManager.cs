using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

public class SnapshotsManager
{
    private string snapshotFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "snapshots");
    private int snapshotCount = 0;

    private OcrHelper ocrHelper = new OcrHelper();

    // Property to enable/disable AI description with py script
    public bool useAiDescription { get; set; }

    // Event to notify when a snapshot is captured and counted
    public event Action<int> SnapshotCountUpdated;

    public SnapshotsManager()
    {
        Directory.CreateDirectory(snapshotFolder);
    }

    /// <summary>
    /// Generates a hash for the given image bitmap.
    /// Optimizing Image Comparison via Hashing
    /// </summary>
    /// <param name="bitmap"></param>
    /// <returns></returns>
    public static string GetImageHash(Bitmap bitmap)
    {
        using (var md5 = MD5.Create())
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                byte[] hashBytes = md5.ComputeHash(imageBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }

    /// <summary>
    /// Captures snapshots and processes them asynchronously with OCR in a queue.
    /// Optimized to only capture when the screen changes, based on hash comparison.
    /// </summary>
public async Task CaptureSnapshotAsync(CancellationToken cancellationToken)
{
    Queue<Task> taskQueue = new Queue<Task>();  // Queue for OCR processing tasks

    int snapshotCheckInterval = 5000;  // Snapshot interval
    string lastSnapshotHash = string.Empty;

    while (!cancellationToken.IsCancellationRequested)
    {
        try
        {
            string filePath = Path.Combine(snapshotFolder, $"snapshot_{DateTime.Now.Ticks}.jpg");

            // Capture the screen
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                // Create a hash of the current snapshot to compare with the last one
                string currentSnapshotHash = GetImageHash(bitmap);

                if (currentSnapshotHash != lastSnapshotHash) // Save only if the screen has changed
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);  // Save to memory stream
                        byte[] imageBytes = ms.ToArray();  // Convert to byte array

                        // Encrypt the image data
                        byte[] encryptedImageBytes = ImageEncryptionHelper.Encrypt(imageBytes);

                        // Save the encrypted image file
                        File.WriteAllBytes(filePath, encryptedImageBytes);
                        Logger.Log($"Snapshot captured and encrypted: {filePath}");

                        lastSnapshotHash = currentSnapshotHash;
                        snapshotCount++;
                        SnapshotCountUpdated?.Invoke(snapshotCount);

                        // Queue OCR processing
                        var processOcrTask = ProcessOcrAndSaveAsync(filePath);
                        taskQueue.Enqueue(processOcrTask);

                        // If AI description is enabled, process with AI 
                        if (useAiDescription)
                        {
                            Logger.Log("Describing the Image with AI...");
                            await DescribeImageInPythonAsync(filePath, cancellationToken);
                        }
                        else
                        {
                            Logger.Log("AI description skipped. Running OCR only...");
                            await ProcessQueuedOcrTasksAsync(taskQueue, cancellationToken);

                        }
                    }
                }
                else
                {
                    Logger.Log("No screen change detected. No snapshot taken.");
                }
            }

            await Task.Delay(snapshotCheckInterval, cancellationToken).ConfigureAwait(false);
        }
        catch (TaskCanceledException)
        {
            Logger.Log("Snapshot capture task was canceled.");
            break;
        }
        catch (Exception ex)
        {
            Logger.Log($"Error during snapshot capture: {ex.Message}");
        }
    }

    Logger.Log("Snapshot capturing stopped.");
}

    /// <summary>
    /// Starts the Python script that describes the image asynchronously.
    /// </summary>
    private async Task DescribeImageInPythonAsync(string imagePath, CancellationToken cancellationToken)
    {
        try
        {
            // Load the encrypted image into a byte array
            byte[] encryptedImage = File.ReadAllBytes(imagePath);

            // Decrypt the image before passing it to the Python script
            byte[] decryptedImage = ImageEncryptionHelper.Decrypt(encryptedImage);

            // Generate a temporary file path for the decrypted image
            string decryptedImagePath = Path.Combine(Path.GetDirectoryName(imagePath), "decrypted_" + Path.GetFileName(imagePath));

            // Write the decrypted image to the disk so that it can be processed by the Python script
            File.WriteAllBytes(decryptedImagePath, decryptedImage);

            // Set up the Python script to process the decrypted image
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"describe_image.py \"{decryptedImagePath}\"", // Pass the decrypted image path to Python script
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();
                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();
                await process.WaitForExitAsync();

                // Log the output and any errors from the Python script
                Logger.Log($"Python Output: {output}", Logger.LogLevel.Info);
                Logger.Log($"Python Error: {error}", Logger.LogLevel.Error);

                // If the Python script returns a description, save it to the database
                if (!string.IsNullOrEmpty(output))
                {
                    Logger.Log($"Saving to DB: ImagePath: {imagePath}, Description: {output.Trim()}", Logger.LogLevel.Info);

                    // Save the description and image path to the database
                    await DatabaseManager.SaveSnapshotToDatabaseAsync(imagePath, output);
                }
                else
                {
                    // Log a warning if no description is returned
                    Logger.Log("Description is empty. Skipping DB save.", Logger.LogLevel.Warning);
                }
            }

            // Attempt to delete the temporary decrypted image file after processing
            try
            {
                File.Delete(decryptedImagePath);
                Logger.Log($"Deleted temporary decrypted image: {decryptedImagePath}", Logger.LogLevel.Info);
            }
            catch (Exception ex)
            {
                // Log an error if the deletion of the temporary file fails
                Logger.Log($"Error deleting temporary decrypted image: {ex.Message}", Logger.LogLevel.Error);
            }
        }
        catch (Exception ex)
        {
            // Log any exceptions that occur during the process
            Logger.Log("Error executing Python script: " + ex.Message, Logger.LogLevel.Error);
        }
    }



    // Open the snapshots folder in the default file explorer
    public void OpenSnapshotFolder()
    {
        try
        {
            Process.Start("explorer.exe", snapshotFolder);
        }
        catch (Exception ex)
        {
            Logger.Log($"Error opening snapshots folder: {ex.Message}");
        }
    }

    // !OCR processing for a snapshot!

    /// <summary>
    /// Processes OCR extraction for a snapshot asynchronously.
    /// </summary>
    public async Task ProcessOcrAndSaveAsync(string encryptedFilePath)
    {
        try
        {
            // Load the encrypted image
            byte[] encryptedImageBytes = File.ReadAllBytes(encryptedFilePath);

            // Decrypt the image
            byte[] decryptedImageBytes = ImageEncryptionHelper.Decrypt(encryptedImageBytes);

            // Save decrypted image temporarily
            string decryptedFilePath = Path.Combine(Path.GetTempPath(), $"decrypted_{Guid.NewGuid()}.jpg");
            File.WriteAllBytes(decryptedFilePath, decryptedImageBytes);

            // Run OCR on the decrypted image file
            string extractedText = await ocrHelper.ExtractTextFromImageAsync(decryptedFilePath);

            // Save extracted text and the original file path in the database
            await DatabaseManager.SaveSnapshotToDatabaseAsync(encryptedFilePath, extractedText);

            Logger.Log($"Snapshot saved and OCR processed: {encryptedFilePath}");

            // Delete the temporary decrypted image file
            File.Delete(decryptedFilePath);
        }
        catch (Exception ex)
        {
            Logger.Log($"Error during OCR processing: {ex.Message}", Logger.LogLevel.Error);
        }
    }


    /// <summary>
    /// Processes all queued OCR tasks asynchronously
    /// </summary>
    private async Task ProcessQueuedOcrTasksAsync(Queue<Task> taskQueue, CancellationToken cancellationToken)
    {
        while (taskQueue.Count > 0)
        {
            var task = taskQueue.Dequeue();
            await task.ConfigureAwait(false); // Wait for the OCR processing to complete
        }
    }
}

public static class ProcessExtensions
{
    public static async Task WaitForExitAsync(this Process process)
    {
        var tcs = new TaskCompletionSource<bool>();
        process.EnableRaisingEvents = true;
        process.Exited += (sender, args) => tcs.TrySetResult(true);
        await tcs.Task;
    }
}