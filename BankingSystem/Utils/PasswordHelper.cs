using System.Security.Cryptography;
using System.Text;

namespace BankingSystem.Utils
{
    public class PasswordHelper
    {
        // Method to hash a plain-text password using SHA-256
        public static string HashPassword(string password)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password); // Convert the password string into a byte array

            byte[] hashBytes = sha256.ComputeHash(passwordBytes); // Generate the hash from the password bytes

            return Convert.ToBase64String(hashBytes); // Convert the hashed byte array into a Base64 string for storage
        }   
    }
}
