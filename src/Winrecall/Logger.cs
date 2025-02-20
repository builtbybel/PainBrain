using System;
using System.IO;
using System.Windows.Forms;

public static class Logger
{
    private static TextBox logTextBox;

    public enum LogLevel
    {
        Info,
        Error,
        Warning
    }

    /// <summary>
    /// Initializes the Logger class with a TextBox for displaying log messages.
    /// </summary>
    public static void Initialize(TextBox textBox)
    {
        logTextBox = textBox;
    }

    /// <summary>
    /// Appends a log message to the TextBox with a specified log level.
    /// </summary>
    public static void Log(string message, LogLevel level = LogLevel.Info)
    {
        if (logTextBox == null) return;

        string formattedMessage = $"[{DateTime.Now:HH:mm:ss}] [{level}] {message}";

        if (logTextBox.InvokeRequired)
        {
            logTextBox.Invoke(new Action(() => logTextBox.AppendText(formattedMessage + "\r\n")));
        }
        else
        {
            logTextBox.AppendText(formattedMessage + "\r\n");
        }
    }
}
