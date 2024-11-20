using System.Text.RegularExpressions;

namespace BankingSystem.Utils
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            // Regular  pattern for a basic email validation
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        public static bool IsValidPassword(string password) // Checks if the password meets minimum length requirement
        {
            return password.Length >= 6;
        }

        public static bool IsValidUsername(string username)// Ensures username is not empty and meets minimum length requirement
        {
            return !string.IsNullOrWhiteSpace(username) && username.Length >= 3;
        }

        public static bool IsValidAge(int age) //makes sure that age falls within adult range 18 to 110 years
        {
            return age >= 18 && age <= 110;
        }

        public static bool IsValidPhone(string phone) //It makes sure that phone number format to be exactly 10 digits
        {
            var phonePattern = @"^\d{10}$";
            return Regex.IsMatch(phone, phonePattern);
        }
    }
}
