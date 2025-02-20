using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using System;
using System.Linq;

public class DatabaseManager
{
    private string dbPath = "Data Source=snapshots.db;Version=3;";

    public DatabaseManager()
    {
        InitializeDatabase();
    }

    /// <summary>
    /// Initializes the SQLite database and ensures the required table and columns exist.
    /// </summary>
    private void InitializeDatabase()
    {
        using (var conn = new SQLiteConnection(dbPath))
        {
            conn.Open();
            string createTable = @"CREATE TABLE IF NOT EXISTS Snapshots (
                id INTEGER PRIMARY KEY,
                filepath TEXT,
                description TEXT,
                timestamp DATETIME DEFAULT CURRENT_TIMESTAMP)";
            using (var cmd = new SQLiteCommand(createTable, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// Saves the snapshot file path and description into the database.
    /// </summary>
    public static async Task SaveSnapshotToDatabaseAsync(string filePath, string description)
    {
        try
        {
            using (var conn = new SQLiteConnection("Data Source=snapshots.db;Version=3;"))
            {
                await conn.OpenAsync().ConfigureAwait(false);

                string insertQuery = "INSERT INTO Snapshots (filepath, description, timestamp) VALUES (@filepath, @description, @timestamp)";
                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@filepath", filePath);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);

                    await cmd.ExecuteNonQueryAsync().ConfigureAwait(false);
                }
            }

            Logger.Log($"Saved to DB: {filePath}");
        }
        catch (Exception ex)
        {
            Logger.Log("Error saving to database: " + ex.Message, Logger.LogLevel.Error);
        }
    }

    /// <summary>
    /// Loads all snapshots from the database and stores them in a list (Trackbar).
    /// Updates the TrackBar range accordingly.
    /// </summary>
    public async Task<List<(string filePath, DateTime timestamp)>> LoadSnapshotsAsync()
    {
        List<(string filePath, DateTime timestamp)> snapshotList = new List<(string, DateTime)>();

        using (var conn = new SQLiteConnection(dbPath))
        {
            await conn.OpenAsync().ConfigureAwait(false);
            string query = "SELECT filepath, timestamp FROM Snapshots ORDER BY timestamp ASC";

            using (var cmd = new SQLiteCommand(query, conn))
            using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
            {
                while (await reader.ReadAsync().ConfigureAwait(false))
                {
                    snapshotList.Add((reader["filepath"].ToString(), Convert.ToDateTime(reader["timestamp"])));
                }
            }
        }

        return snapshotList;
    }

    /// <summary>
    /// Searches the database asynchronously for snapshots with descriptions containing the search query.
    /// </summary>
    /// <param name="searchQuery"></param>
    /// <returns></returns>
    public async Task<List<(string filePath, string description)>> SearchSnapshotsAsync(string searchQuery)
    {
        var results = new List<(string filePath, string description)>();

        // Split the search query into individual words
        var searchWords = searchQuery.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (searchWords.Length == 0)
        {
            return results; // Return empty list if no valid search terms
        }

        using (var conn = new SQLiteConnection(dbPath))
        {
            await conn.OpenAsync().ConfigureAwait(false);

            // Build SQL query dynamically
            string searchQuerySQL = "SELECT filepath, description FROM Snapshots WHERE ";
            searchQuerySQL += string.Join(" AND ", searchWords.Select((_, i) => $"description LIKE @searchText{i}"));

            using (var cmd = new SQLiteCommand(searchQuerySQL, conn))
            {
                // Add each search word as a parameter with wildcard search
                for (int i = 0; i < searchWords.Length; i++)
                {
                    cmd.Parameters.AddWithValue($"@searchText{i}", $"%{searchWords[i]}%");
                }

                using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                {
                    while (await reader.ReadAsync().ConfigureAwait(false))
                    {
                        results.Add((reader["filepath"].ToString(), reader["description"].ToString()));
                    }
                }
            }
        }

        return results;
    }

}