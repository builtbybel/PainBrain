using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Winrecall
{
    public partial class SettingsForm : Form

    {
        private string userKey;

        // Event triggered when the user selects a capture mode
        public event Action<string> ModeSelected;

        public SettingsForm()
        {
            InitializeComponent();
  
        }

        private void btnOcrOnly_Click(object sender, EventArgs e)
        {
            // Invoke the ModeSelected event with the selected mode
            ModeSelected?.Invoke(nameof(UIEnums.CaptureModeOptions.OCROnly));
            this.Close();
        }

        private void btnAiAndOcr_Click(object sender, EventArgs e)
        {
            ModeSelected?.Invoke(nameof(UIEnums.CaptureModeOptions.AIAndOCR));
            this.Close();
        }

        private async void btnIsEnvironmentReady_Click(object sender, EventArgs e)
        {
            await PythonChecker.EnsurePythonEnvironmentAsync(this);
        }

        private void btnSetUserKey_Click(object sender, EventArgs e)
        {
            string inputKey = textUserKey.Text.Trim();

            if (!string.IsNullOrEmpty(inputKey))
            {
                // Set the user-defined key in the encryption helper
                ImageEncryptionHelper.SetUserKey(inputKey);

                userKey = inputKey;  // Now we could store the key for session use, if needed

                MessageBox.Show("User key set successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter a valid key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkEnvironmentCheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/builtbybel/Winrecall#installation");
        }
    }
}