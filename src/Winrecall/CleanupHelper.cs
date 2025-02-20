using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

public class CleanupHelper
{
    private string snapshotFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "snapshots");
    private string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "snapshots.db");

    /// <summary>
    /// Asks the user if they want to delete the current snapshot session.
    /// </summary>
    public void PromptToDeleteSession()
    {
        var result = MessageBox.Show(
            "This will permanently delete all snapshots and the database. Continue?",
            "Session Cleanup Reminder",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information);

        if (result == DialogResult.Yes)
        {
            ForceFullCleanup();
        }
    }

    /// <summary>
    /// Full cleanup: Closes database connections, deletes snapshots, and wipes the database.
    /// </summary>
    public void ForceFullCleanup()
    {
        try
        {
            // Step 1: Delete all snapshots
            DeleteAllSnapshots();

            // Step 2: Close database connection
            SQLiteConnection.ClearAllPools();

            // Step 3: Delete the database file;
            if (File.Exists(dbFilePath))
            {
                File.Delete(dbFilePath);
                //  MessageBox.Show("Database file deleted successfully!");
            }

            // MessageBox.Show("Full cleanup completed!");

            // Step 4: Restart the application
            Application.Restart();
        }
        catch (Exception ex)
        {
            Logger.Log($"Error during full cleanup: {ex.Message}", Logger.LogLevel.Error);
        }
    }

    /// <summary>
    /// Deletes all snapshot files in the designated folder safely.
    /// </summary>
    private void DeleteAllSnapshots()
    {
        try
        {
            if (Directory.Exists(snapshotFolder))
            {
                var files = Directory.GetFiles(snapshotFolder);
                foreach (var file in files)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log($"Error deleting file {file}: {ex.Message}");
                    }
                }
            }

            // MessageBox.Show("All snapshots deleted successfully!");
        }
        catch (Exception ex)
        {
            Logger.Log($"Error deleting snapshots: {ex.Message}", Logger.LogLevel.Error);
        }
    }
}