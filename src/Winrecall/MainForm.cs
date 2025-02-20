using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Winrecall.UIEnums;

namespace Winrecall
{
    public partial class MainForm : Form
    {
        private SnapshotsManager SnapshotsManager;
        private DatabaseManager databaseManager;
        private SnapshotDisplayManager snapshotDisplayManager;
        private CancellationTokenSource cancellationTokenSource;
        private int snapshotCount = 0;

        // List to store snapshot file paths and timestamps for history (TrackBar)
        private List<(string filePath, DateTime timestamp)> snapshotList = new List<(string, DateTime)>();

        // Tracks the current position in the history
        private int currentIndex = 0;

        public MainForm()
        {
            InitializeComponent();
            SnapshotsManager = new SnapshotsManager();
            databaseManager = new DatabaseManager();
            snapshotDisplayManager = new SnapshotDisplayManager(flowLayoutPanelResults, pictureBoxResult);
            SnapshotsManager.SnapshotCountUpdated += OnSnapshotCountUpdated;
            Logger.Initialize(textLog); 
            LoadSnapshots(); // Load snapshots from the database for history
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupUI();
            ShowSettingsForm();
        }

        private void SetupUI()
        {
            // Set Sego UI Symbol font for the buttons
            btnStopCapture.Text = "\uEDB4";

            // Add items to the SizeMode
            comboBoxSizeMode.Items.AddRange(Enum.GetNames(typeof(SizeModeOptions)));
            comboBoxSizeMode.SelectedIndex = 1;
        }

        private void ShowSettingsForm()
        {
            using (var settingsForm = new SettingsForm())
            {
                settingsForm.ModeSelected += SettingsForm_ModeSelected;
                settingsForm.FormClosed += (s, args) => this.Opacity = 1.0;

                this.Opacity = 0.7;  //  Dim the MainForm
                settingsForm.StartPosition = FormStartPosition.CenterParent;
                settingsForm.ShowDialog(this); 
                this.Opacity = 1.0;  // Restore opacity after closing SettingsForm
            }
        }

        // Event handler for the ModeSelected event from the SettingsForm
        private void SettingsForm_ModeSelected(string selectedMode)
        {
            // Set the mode in SnapshotsManager based on the user's selection
            SnapshotsManager.useAiDescription = (selectedMode == nameof(UIEnums.CaptureModeOptions.AIAndOCR));
            // MessageBox.Show($"You selected {selectedMode}. The capture mode is now set.");
            Logger.Log("Capture mode set to: " + selectedMode, Logger.LogLevel.Info);
            // settingsForm.Close();
        }

        /// <summary>
        /// Starts automatic snapshot capturing.
        /// </summary>
        private async void btnStartCapture_Click(object sender, EventArgs e)
        {
            btnStartCapture.Enabled = false;
            btnStopCapture.Enabled = true;

            if (cancellationTokenSource != null)
            {
                MessageBox.Show("Snapshot capturing is already running!");
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();
            MessageBox.Show("Automatic snapshot capturing started!");

            // Start capturing snapshots and run the description process in parallel
            await SnapshotsManager.CaptureSnapshotAsync(cancellationTokenSource.Token);
        }

        /// <summary>
        /// Stops the automatic snapshot capturing process.
        /// </summary>
        private void btnStopCapture_Click(object sender, EventArgs e)
        {
            btnStartCapture.Enabled = true;
            btnStopCapture.Enabled = false;

            if (cancellationTokenSource == null)
            {
                MessageBox.Show("No active capturing process!");
                return;
            }

            // Cancel the task by using the cancellation token
            cancellationTokenSource.Cancel();
            cancellationTokenSource = null;

            MessageBox.Show("Snapshot capturing stopped!");
            Logger.Log("Snapshot capturing process was manually stopped.");
        }

        /// <summary>
        /// Searches the database for snapshots containing the specified text.
        /// </summary>
        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = textSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return;
            }

            // Await the async search method
            var results = await databaseManager.SearchSnapshotsAsync(searchQuery);

            // Display the results as thumbnails in the FlowLayoutPanel
            await snapshotDisplayManager.DisplaySearchResultsAsThumbnailsAsync(results);
        }

        // Event handler for SnapshotCountUpdated event
        private void OnSnapshotCountUpdated(int newCount)
        {
            snapshotCount = newCount;
            if (btnStartCapture.InvokeRequired)
            {
                btnStartCapture.Invoke(new Action(() => UpdateCaptureButton()));
            }
            else
            {
                UpdateCaptureButton();
            }
        }

        // Update the capture button text based on the snapshot count
        private void UpdateCaptureButton()
        {
            btnStartCapture.Text = $"Capture ({snapshotCount})";
        }

        /// <summary>
        /// Loads snapshots from the database and updates the TrackBar accordingly.
        /// </summary>
        private async void LoadSnapshots()
        {
            snapshotList = await databaseManager.LoadSnapshotsAsync();

            if (snapshotList.Count > 0)
            {
                trackBarHistory.Minimum = 0; // Set the minimum value of the TrackBar
                trackBarHistory.Maximum = snapshotList.Count - 1; // Set the maximum value of the TrackBar
                trackBarHistory.Value = snapshotList.Count - 1; // Default to the most recent snapshot
                currentIndex = snapshotList.Count - 1; // Set the current index to the latest screenshot

                await ShowSnapshotAsync(currentIndex); // Display the most recent snapshot asynchronously
            }
        }

        /// <summary>
        ///  Show the snapshot corresponding to the specified index in the history.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private async Task ShowSnapshotAsync(int index)
        {
            if (snapshotList != null && snapshotList.Count > 0 && index >= 0 && index < snapshotList.Count)
            {
                string filePath = snapshotList[index].filePath;
                DateTime timestamp = snapshotList[index].timestamp;

                if (File.Exists(filePath))
                {
                    try
                    {
                        // Load the encrypted image bytes from the file asynchronously
                        byte[] encryptedImageBytes = await Task.Run(() => File.ReadAllBytes(filePath));

                        // Decrypt the image bytes using the ImageEncryptionHelper
                        byte[] decryptedImageBytes = ImageEncryptionHelper.Decrypt(encryptedImageBytes);

                        // Create the image from the decrypted byte array asynchronously
                        using (MemoryStream ms = new MemoryStream(decryptedImageBytes))
                        {
                            pictureBoxResult.Image = Image.FromStream(ms);  // Display the image in PictureBox
                            pictureBoxResult.Tag = filePath;  // Store the file path in the Tag property for reference
                        }

                        lblTimestamp.Text = "Timeline: " + timestamp.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    catch (Exception ex)
                    {
                      //  MessageBox.Show($"An error occurred while loading the snapshot: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The snapshot file could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid snapshot index.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles TrackBar scrolling to navigate through the snapshot history.
        /// </summary>
        private async void trackBarHistory_Scroll(object sender, EventArgs e)
        {
            currentIndex = trackBarHistory.Value;
            await ShowSnapshotAsync(currentIndex);  // Display the snapshot corresponding to the new index
        }

        // Open the full image in the default viewer when clicking on the PictureBox
        private void pictureBoxResult_Click(object sender, EventArgs e)
        {
            if (pictureBoxResult.Image != null)
            {
                try
                {
                    // Get the encrypted image path
                    string encryptedFilePath = pictureBoxResult.Tag as string;

                    if (!string.IsNullOrEmpty(encryptedFilePath) && File.Exists(encryptedFilePath))
                    {
                        // Decrypt the image
                        byte[] encryptedImage = File.ReadAllBytes(encryptedFilePath);
                        byte[] decryptedImage = ImageEncryptionHelper.Decrypt(encryptedImage);

                        // Save the decrypted image temporarily
                        string tempFilePath = Path.Combine(Path.GetTempPath(), $"decrypted_{Guid.NewGuid()}.jpg");
                        File.WriteAllBytes(tempFilePath, decryptedImage);

                        Process.Start(tempFilePath);
                    }
                    else
                    {
                        MessageBox.Show("Image file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void comboBoxSizeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sizeMode = comboBoxSizeMode.SelectedItem.ToString();

            if (sizeMode == "Normal")
                pictureBoxResult.SizeMode = PictureBoxSizeMode.Normal;
            else if (sizeMode == "Zoom")
                pictureBoxResult.SizeMode = PictureBoxSizeMode.Zoom;
            else if (sizeMode == "AutoSize")
                pictureBoxResult.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void btnClearSession_Click(object sender, EventArgs e)
        {
            // Prepare for cleanup
            pictureBoxResult.Image = null;
            if (snapshotList.Count > 0)
            {
                snapshotList.Clear();
            }
            CleanupHelper cleanup = new CleanupHelper();
            cleanup.PromptToDeleteSession();

        }  
        
        private void linkSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowSettingsForm();
        }

        private void linkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/builtbybel/Winrecall");
        }

        private void linkOpenScreenshotsFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SnapshotsManager.OpenSnapshotFolder();
        }

        private void textSearch_Click(object sender, EventArgs e)
        {
            textSearch.Text = "";
        }

   
    }
}

// Store the file path and description as a single object
public class ListBoxItemWithDescription
{
    public string FilePath { get; }
    public string Description { get; }

    public ListBoxItemWithDescription(string filePath, string description)
    {
        FilePath = filePath;
        Description = description;
    }

    public override string ToString()
    {
        return $"{Description} (Path: {FilePath})";
    }
}