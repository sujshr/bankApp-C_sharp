using BankingSystem.Models;

namespace BankingSystem.Services
{
    public class TransactionService
    {
        private readonly Bank bank;//Declaring the bank object

        public TransactionService(Bank bank)//Constructor that initialize the bank instance
        {
            this.bank = bank;
        }

        public void Deposit(User user)// Taking deposits int the user account 
        {
            try
            {
                Console.Write("Enter deposit amount (or type 'exit' to cancel): ");//Getting user to input amoount to deposit
                var input = Console.ReadLine()?.Trim();

                if (input?.ToLower() == "exit")
                {
                    Console.WriteLine("Deposit transaction cancelled.");
                    return;
                }

                //Checking if input is a positive number
                if (double.TryParse(input, out double amount) && amount > 0)
                {
                    user.Deposit(amount);//Depositing the amount 
                    Console.WriteLine($"Deposited {amount:C} into {user.Username}'s account.");
                }
                else
                {
                    Console.WriteLine("Invalid amount. Deposit must be a positive number.");//Error if invalid amount
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the deposit: {ex.Message}");
            }
        }

        public void Withdraw(User user)// Method to handle withdrawals from a user's account
        {
            try
            {
                // Getting the user to enter an amount to withdraw
                Console.Write("Enter withdrawal amount (or type 'exit' to cancel): ");
                var input = Console.ReadLine()?.Trim();


                // Exit code if the user types exit
                if (input?.ToLower() == "exit")
                {
                    Console.WriteLine("Withdrawal transaction cancelled.");
                    return;
                
                }
                // Check if the input is a valid positive number
                if (double.TryParse(input, out double amount) && amount > 0)
                {
                    bool success = user.Withdraw(amount); //Getting to withdraw the amount
                    if (success)
                    {
                        Console.WriteLine($"Withdrew {amount:C} from {user.Username}'s account.");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds.");//Showing error if insufficient funds
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount. Withdrawal must be a positive number.");// Invalid withdrawel amount
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during the withdrawal: {ex.Message}");//Error message for any exception
            }
        }

        public void Transfer(User sender)//Code for handling funds transfers between users
        {
            try
            {
                Console.Write("Enter receiver's username (or type 'exit' to cancel): ");//Getting sender to type recepient's name
                var receiverUsername = Console.ReadLine()?.Trim();

                if (receiverUsername == sender.Username)
                {
                    Console.WriteLine("Cannot transefer balance to same account."); // Prevent transfer to the same account
                    return ;
                }

                if (receiverUsername?.ToLower() == "exit")
                {
                    Console.WriteLine("Transfer transaction cancelled.");
                    return;
                }

                User? receiver = bank.GetUserByUsername(receiverUsername);// Retrieve the receiver's account using the given username
                if (receiver == null)
                {
                    Console.WriteLine("Receiver not found.");// Error: Receiver not found

                    return;
                }

                Console.Write("Enter transfer amount (or type 'exit' to cancel): ");// getting the sender to enter the transfer amount
                var input = Console.ReadLine()?.Trim();

                if (input?.ToLower() == "exit")
                {
                    Console.WriteLine("Transfer transaction cancelled.");
                    return;
                }

                if (double.TryParse(input, out double amount) && amount > 0)//Checking if input is valid
                {
                    bool withdrawalSuccess = sender.Withdraw(amount);// Attempt to withdraw the given amount from the sender's account
                    if (!withdrawalSuccess)
                    {
                        Console.WriteLine("Insufficient funds, transfer failed.");
                        return;
                    }

                    receiver.Deposit(amount);//Deposit the transferred amount into the receiver's account

                    Console.WriteLine($"Transferred {amount:C} from {sender.Username} to {receiver.Username}.");//Deposit success
                }
                else
                {
                    Console.WriteLine("Invalid amount. Transfer must be a positive number.");//response for a invalid number 
                }
            }
            catch (Exception ex)//Error handling message
            {
                Console.WriteLine($"An error occurred during the transfer: {ex.Message}");
            }
        }
    }
}
