using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class PythonChecker
{
    /// <summary>
    /// Checks if Python is installed by running "python --version".
    /// </summary>
    public static async Task<bool> IsPythonInstalledAsync()
    {
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = "--version",
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
                process.WaitForExit();

                // Does the output contain the Python version number?
                return System.Text.RegularExpressions.Regex.IsMatch(output + error, @"Python\s+\d+\.\d+\.\d+");
            }
        }
        catch (Exception)
        {
            return false;
        }
    }


    /// <summary>
    /// Ensures Python is installed. If not, starts setup.bat.
    /// </summary>
    public static async Task EnsurePythonEnvironmentAsync(Form parentForm)
    {
        bool pythonInstalled = await IsPythonInstalledAsync();

        if (!pythonInstalled)
        {
            parentForm.Invoke(new Action(() =>
            {
                MessageBox.Show("Python is not installed. The setup process will now start.",
                    "Python Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));

            StartSetupProcess();
        }
        else
        {
            parentForm.Invoke(new Action(() =>
            {
                MessageBox.Show("Environment is ready. Python is installed!",
                    "Check Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));
            StartSetupProcess();
        }
    }

    /// <summary>
    /// Starts the setup.bat process.
    /// </summary>
    private static void StartSetupProcess()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = "/c start setup.bat",
            WorkingDirectory = Application.StartupPath,
            UseShellExecute = true,
            CreateNoWindow = false
        };

        Process process = new Process { StartInfo = startInfo };
        process.Start();
    }
}
