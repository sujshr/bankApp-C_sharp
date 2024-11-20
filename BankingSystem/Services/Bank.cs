using BankingSystem.Models;

namespace BankingSystem.Services
{
    public class Bank
    {
        // Dictionary to store user accounts with usernames as key
        private readonly Dictionary<string, User> users = [];

        public bool AddUser(User user) //This to add a new user to the bank
        {
            if (users.ContainsKey(user.Username)) // Check if the username already exists in  system
            {
                Console.WriteLine("User with this username already exists."); // Error to show if Usernames conflict
                return false;
            }

            users[user.Username] = user; // Add the user to the system with their username as the key
            return true;
        }

        public User? GetUserByUsername(string username) // Search a user by their usernames
        {
            users.TryGetValue(username, out User user); // Attempt to find and return the user
            return user; //return null if not found
        }
    }
}
