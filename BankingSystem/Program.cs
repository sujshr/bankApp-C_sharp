using System;
using BankingSystem.Models;
using BankingSystem.Services;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Holds the currently logged-in user which is to be  null when no user is logged in
            User? loggedInUser = null;

            Bank bank = new Bank();// Create an instance of the bank to manage user accounts
            // startup services needed for user signup, login, and transactions

            SignupService signupService = new SignupService(bank);
            LoginService loginService = new LoginService(bank);
            TransactionService transactionService = new TransactionService(bank);
            MenuService menuService = new MenuService(signupService, loginService, transactionService, ref loggedInUser);

            menuService.DisplayMenu();  // Display the main menu to interact with the banking system
        }
    }
}
