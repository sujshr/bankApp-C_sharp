using BankingSystem.Models;
using BankingSystem.Utils;

namespace BankingSystem.Services
{
    public class SignupService
    {
        private readonly Bank bank;

        //Constructor to start Signup service with Bank object
        public SignupService(Bank bank)
        {
            this.bank = bank;
        }

        // Registers a new user by creating them with the provided details and adding them to the bank
        public bool Register(string username, string email, int age, string phone, string password)
        {
            var newUser = new User(username, email, age, phone, password);//Creating new user
            return bank.AddUser(newUser);// Adding the user to the bank
        }

        public void RegisterUser()//Setting a step by step process for signup
        {
            Console.WriteLine("Register a new user");
            //Setting up string variables to store user details.
            string username = null;
            string email = null;
            int? age = null;
            string phone = null;
            string password = null;

            while (username == null)// Loop to get valid username
            {
                Console.Write("Enter username (type 'exit' to cancel): ");
                var input = GetInput();
                if (input == null) return;

                if (!ValidationHelper.IsValidUsername(input))// Check if the username meets the rules
                {
                    Console.WriteLine("Invalid username. It must be at least 3 characters long.");
                }
                else
                {
                    username = input;// Saving username if valid 
                }
            }

            while (email == null)//Loop to get valid Email
            {
                Console.Write("Enter email (type 'exit' to cancel): ");
                var input = GetInput();
                if (input == null) return;

                if (!ValidationHelper.IsValidEmail(input))// Check if the format is correct
                {
                    Console.WriteLine("Invalid email format.");
                }
                else
                {
                    email = input;// Saving the email if its valid
                }
            }

            while (age == null)//loop for getting a valid age
            {
                Console.Write("Enter age (type 'exit' to cancel): ");
                var input = GetInput();//Get user input
                if (input == null) return;

                //Check if the input meets the minimum age requirement
                if (!int.TryParse(input, out int parsedAge) || !ValidationHelper.IsValidAge(parsedAge))
                {
                    Console.WriteLine("Invalid age. You must be at least 18 years old.");
                }
                else
                {
                    age = parsedAge;//Save if it's valid
                }
            }

            while (phone == null)//Loop to get valid phone number 
            {
                Console.Write("Enter phone number (type 'exit' to cancel): ");
                var input = GetInput();//Get user input 
                if (input == null) return;

                //Check if the format is valid 
                if (!ValidationHelper.IsValidPhone(input))
                {
                    Console.WriteLine("Invalid phone number format.");
                }
                else
                {
                    phone = input;//Saving the phone number if it's valid 
                }
            }

            while (password == null)//Loop to get valid password
            {
                Console.Write("Enter password (type 'exit' to cancel): ");
                var input = GetInput();//Get iser input
                if (input == null) return;

                //check if password meets the minimum length 
                if (!ValidationHelper.IsValidPassword(input))
                {
                    Console.WriteLine("Password must be at least 6 characters long.");
                }
                else
                {
                    Console.Write("Confirm password: ");//Get password confirmation 
                    var confirmPassword = GetInput();
                    if (confirmPassword == null) return;

                    if (input != confirmPassword)//Check if the password matches 
                    {
                        Console.WriteLine("Passwords do not match. Please try again.");
                    }
                    else
                    {
                        password = input;//Save if it matches 
                    }
                }
            }
            //All details are now valid, so we now register the user 
            var success = Register(username, email, age.Value, phone, password);

            if (success)
            {
                Console.WriteLine("Registration successful!");
            }
            else
            {
                Console.WriteLine("Registration failed. Please try again.");
            }

        }

        private string GetInput()//Handling exit command 
        {
            var input = Console.ReadLine();
            if (input.Equals("exit"))
            {
                Console.WriteLine("Registration canceled.");
                return null; 
            }
            return input;
        }
    }
}
