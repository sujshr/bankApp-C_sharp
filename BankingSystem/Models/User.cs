using BankingSystem.Utils;

namespace BankingSystem.Models
{
    public class User
    {
        // Basic information properties for each user including account information and contact details
        public string Username { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }

        // Constructor for initializing a new user with their details
        public User(string username, string email, int age, string phone, string password)
        {
            Username = username;
            Email = email;
            Age = age;
            Phone = phone;
            Password = PasswordHelper.HashPassword(password);
            Balance = 0; //balance to zero for a new user
        }

        public bool ValidatePassword(string enteredPassword)
        {
            // Hash the entered password to  compare with stored hashed password
            string hashedEnteredPassword = PasswordHelper.HashPassword(enteredPassword);

            return hashedEnteredPassword == Password;
        }

        public bool Deposit(double amount) // Method to add funds to the user's account account
        {
            if (amount > 0)//Check if the deposit amount is positive
            {
                Balance += amount;
                return true;
            }
            else
            {
                Console.WriteLine("Deposit amount must be greater than 0.");//Error if deposit is not positive
                return false;
            }
        }

            // Method to withdraw funds from the user's account balance if sufficient funds are available
            public bool Withdraw(double amount)

        {
            if (amount > 0)// Check if the withdrawal amount is positive
            {
                if (Balance >= amount)
                {
                    Balance -= amount;
                    return true;
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");//Error if balance is insufficient
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Withdrawal amount must be greater than 0.");
                return false;
            }
        }

        public string DisplayInformation() // method to provide a summary of user information
        {
            return $"Username: {Username}, Email: {Email}, Age: {Age}, Phone: {Phone}\n Balance: {Balance:C}";
        }
    }
}
