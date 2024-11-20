using BankingSystem.Models;

namespace BankingSystem.Services
{
    public class MenuService
    {
        private readonly SignupService signupService;// Manages user registration
        private readonly LoginService loginService;//Manages Login/Logout 
        private readonly TransactionService transactionService;//Takes care of transactions like deposit,withdraw,transfer
        private User? loggedInUser;

        public MenuService(SignupService signupService, LoginService loginService, TransactionService transactionService, ref User? loggedInUser)
        {
            this.signupService = signupService;
            this.loginService = loginService;
            this.transactionService = transactionService;
            this.loggedInUser = loggedInUser;
        }

        //Method to display menu options and get user selection
        public void DisplayMenu()
        {
            while (true)
            {
                if (loggedInUser == null)
                {
                    Console.WriteLine("\nMain Menu:");
                    Console.WriteLine("1. Sign Up");
                    Console.WriteLine("2. Log In");
                    Console.WriteLine("3. Exit");

                    Console.Write("Select an option: ");
                    var choice = Console.ReadLine();

                    switch (choice)// Select user selection from the main menu
                    {
                        case "1":
                            signupService.RegisterUser();// Code to register a new user
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "2":
                            // Get user to login , if successful,the screen is cleared for the Logged-in menu
                            bool loginSuccess = loginService.LoginUser(ref loggedInUser);
                            if (!loginSuccess)
                            {
                                Console.WriteLine("Login failed.");
                            }
                            else
                            {
                                Console.Clear();
                            }
                            break;

                        case "3":
                            Console.WriteLine("Exiting the application.");// Exit option
                            return;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");// Take care of invalid input
                            break;
                    }
                }
                else// If the user logged in, show the account options
                {
                    Console.WriteLine($"\nMain Menu (Logged In as {loggedInUser.Username})");
                    Console.WriteLine("1. View Account & Check Balance");
                    Console.WriteLine("2. Deposit");
                    Console.WriteLine("3. Withdraw");
                    Console.WriteLine("4. Transfer");
                    Console.WriteLine("5. Log Out");
                    Console.WriteLine("6. Exit");

                    Console.Write("Select an option: ");
                    var choice = Console.ReadLine();

                    switch (choice)// Take user selection from the above options
                    {
                        case "1":
                            Console.WriteLine($"Welcome, {loggedInUser.Username}!");// Display account details
                            Console.WriteLine(loggedInUser.DisplayInformation());
                            break;

                        case "2":
                            transactionService.Deposit(loggedInUser);// Get deposit form the user
                            break;

                        case "3":
                            transactionService.Withdraw(loggedInUser);// Get withdrawal service for the user
                            break;

                        case "4":
                            transactionService.Transfer(loggedInUser);// Get transfer service for the user
                            break;

                        case "5":
                            loginService.Logout(ref loggedInUser);// Logout the user
                            Console.Clear();
                            break;

                        case "6":
                            Console.WriteLine("Exiting the application.");// Exit the application
                            return;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");// Taking care of invalid input
                            break;
                    }
                }
            }
        }
    }
}
