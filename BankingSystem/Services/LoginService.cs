using BankingSystem.Models;

namespace BankingSystem.Services
{
    public class LoginService
    {
        private readonly Bank bank;

        //Start Loginservice with a bank instance
        public LoginService(Bank bank)
        {
            this.bank = bank;
        }

        //Function to manage user login,returns true if successfull or given false 
        public bool LoginUser(ref User? loggedInUser)
        {
            Console.WriteLine("Login");

            Console.Write("Enter username: ");//code to get the username 
            var username = Console.ReadLine();

            var user = bank.GetUserByUsername(username);//checking to get the user by their username 
            if (user == null)
            {
                Console.WriteLine("User not found. Please check your email or sign up if you don't have an account.");// Inform user 'no user found'
                return false;
            }

            int attempts = 0;// Track number of login attempts
            const int maxAttempts = 3;//max login attempts

            while (attempts < maxAttempts)
            {
                Console.Write("Enter password: ");
                var password = Console.ReadLine();

                if (user.ValidatePassword(password))//Check if the password is correct
                {
                    loggedInUser = user; 
                    Console.WriteLine("Welcome back!");
                    return true;
                }
                else
                {
                    attempts++;
                    Console.WriteLine(attempts < maxAttempts
                        ? $"Login failed. You have {maxAttempts - attempts} attempts left."
                        : "Login failed. You have exceeded the maximum number of attempts.");
                }
            }
            return false;
        }

        public void Logout(ref User? loggedInUser)
        {
            loggedInUser = null;// Reset LoggedInUser to null
            Console.WriteLine("You have been logged out.");
        }
    }
}
