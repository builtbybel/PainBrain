using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

public class SnapshotDisplayManager
{
    private FlowLayoutPanel flowLayoutPanel;
    private PictureBox pictureBoxResult;

    public SnapshotDisplayManager(FlowLayoutPanel flowLayoutPanel, PictureBox pictureBoxResult)
    {
        this.flowLayoutPanel = flowLayoutPanel;
        this.pictureBoxResult = pictureBoxResult;
    }

    /// <summary>
    /// Asynchronously clears the FlowLayoutPanel and displays the search results as thumbnails.
    /// </summary>
    /// <param name="results">The list of snapshot results containing file paths and descriptions.</param>
    public async Task DisplaySearchResultsAsThumbnailsAsync(List<(string filePath, string description)> results)
    {
        // Clear the panel first 
        flowLayoutPanel.Invoke((Action)(() => flowLayoutPanel.Controls.Clear()));

        ToolTip toolTip = new ToolTip();

        if (results.Count > 0)
        {
            string firstFilePath = results[0].filePath;

            // Load and decrypt the first image asynchronously
            Image firstImage = await Task.Run(() => LoadAndDecryptImage(firstFilePath));

            pictureBoxResult.Invoke((Action)(() =>
            {
                pictureBoxResult.Image = firstImage;
                pictureBoxResult.Tag = firstFilePath;
            }));
        }
        else
        {
            pictureBoxResult.Invoke((Action)(() =>
            {
                pictureBoxResult.Image = null;
                pictureBoxResult.Tag = null;
            }));
        }

        // Process thumbnails asynchronously
        await Task.Run(() =>
        {
            List<PictureBox> thumbnails = new List<PictureBox>();

            foreach (var result in results)
            {
                Image thumbnail = CreateThumbnail(result.filePath);
                if (thumbnail == null)
                    continue;

                var pictureBoxThumbnail = new PictureBox
                {
                    Image = thumbnail,
                    Width = thumbnail.Width,
                    Height = thumbnail.Height,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Tag = result.filePath,
                    Cursor = Cursors.Hand
                };

                toolTip.SetToolTip(pictureBoxThumbnail, result.description);

                pictureBoxThumbnail.Click += (sender, e) =>
                {
                    Task.Run(async () =>
                    {
                        Image fullImage = await Task.Run(() => LoadAndDecryptImage(result.filePath));
                        pictureBoxResult.Invoke((Action)(() =>
                        {
                            pictureBoxResult.Image = fullImage;
                            pictureBoxResult.Tag = result.filePath;
                        }));
                    });
                };

                thumbnails.Add(pictureBoxThumbnail);
            }

            // Add thumbnails to the UI on the main thread!
            flowLayoutPanel.Invoke((Action)(() =>
            {
                foreach (var pb in thumbnails)
                {
                    flowLayoutPanel.Controls.Add(pb);
                }
            }));
        });
    }

    /// <summary>
    /// Creates a thumbnail for the given image asynchronously.
    /// </summary>
    /// <param name="filePath">The file path of the image.</param>
    /// <returns>The generated thumbnail image.</returns>
    private Image CreateThumbnail(string filePath)
    {
        try
        {
            Image decryptedImage = LoadAndDecryptImage(filePath); // Load and decrypt the image
            if (decryptedImage != null)
            {
                return decryptedImage.GetThumbnailImage(150, 150, () => false, IntPtr.Zero);
            }
            return null;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Loads and decrypts an image from the file path.
    /// </summary>
    /// <param name="filePath">The file path of the image.</param>
    /// <returns>The decrypted image.</returns>
    private Image LoadAndDecryptImage(string filePath)
    {
        try
        {
            if (!ImageEncryptionHelper.CheckKeyAndShowMessage())
                return null;

            byte[] encryptedImageBytes = File.ReadAllBytes(filePath);
            byte[] decryptedImageBytes = ImageEncryptionHelper.Decrypt(encryptedImageBytes);

            using (MemoryStream ms = new MemoryStream(decryptedImageBytes))
            {
                return Image.FromStream(ms);
            }
        }
        catch
        {
            return null;
        }
    }
}
