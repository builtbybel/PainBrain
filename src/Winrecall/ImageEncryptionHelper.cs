using System;
using System.Windows.Forms;


/// <summary>
///  !Will have to switch to a more secure encryption method in the future, e.g. AES.!"
/// </summary>
/// 

public static class ImageEncryptionHelper
{
    private static byte[] userKeyBytes;
    private static bool hasShownMessage = false; 

    // Property to get the user key
    public static string UserKey => userKeyBytes == null ? string.Empty : System.Text.Encoding.UTF8.GetString(userKeyBytes);

    // Set the encryption key
    public static void SetUserKey(string userKey)
    {
        userKeyBytes = System.Text.Encoding.UTF8.GetBytes(userKey);
        hasShownMessage = false;  // Reset message flag when a new key is set
    }

    // Check if key is set and show message if needed
    public static bool CheckKeyAndShowMessage()
    {
        if (string.IsNullOrEmpty(UserKey) && !hasShownMessage)
        {
            MessageBox.Show("Please enter your encryption key in the Settings to view the snapshots. Without the key, the snapshots cannot be decrypted.",
                            "Encryption Key Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            hasShownMessage = true;  // Set the flag so the message is shown only once
            return false;
        }
        return true;  // Return true if the key is set
    }

    /// <summary>
    /// Encrypts the image data using a custom XOR operation.
    /// </summary>
    /// <param name="data">The image data as a byte array.</param>
    /// <returns>Encrypted (obfuscated) image data.</returns>
    public static byte[] Encrypt(byte[] data)
    {
        if (userKeyBytes == null || userKeyBytes.Length == 0)
        {
            throw new InvalidOperationException("Encryption key is not set.");
        }

        // Use the user key for XOR encryption
        for (int i = 0; i < data.Length; i++)
        {
            data[i] ^= userKeyBytes[i % userKeyBytes.Length];  // XOR with key bytes
        }
        return data;
    }

    /// <summary>
    /// Decrypts the image data by applying the same XOR operation as encryption.
    /// </summary>
    /// <param name="data">The encrypted image data as a byte array.</param>
    /// <returns>The decrypted (original) image data.</returns>
    public static byte[] Decrypt(byte[] data)
    {
        if (userKeyBytes == null || userKeyBytes.Length == 0)
        {
            throw new InvalidOperationException("Encryption key is not set.");
        }

        // Decrypting is the same as encrypting since XOR is symmetric
        return Encrypt(data);  // Reapply XOR operation to revert to the original data
    }
}
