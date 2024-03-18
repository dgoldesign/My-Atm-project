using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleATM
{
    public class ATMSystem
    {
        private DebitCard user;

        public ATMSystem(string cardNum, int pin, string name, double balance)
        {
            user = new DebitCard(cardNum, pin, name, balance);

            // Subscribe to events
            user.Deposited += (sender, amount) => Console.WriteLine($"{sender.Name} deposited {amount}. New balance: {sender.Balance}");
            user.Withdrawn += (sender, amount) => Console.WriteLine($"{sender.Name} withdrew {amount}. New balance: {sender.Balance}");
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the ATM!");
            bool continueTransactions = true;

            while (continueTransactions)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter the amount you want to deposit: ");
                        double depositAmount = Convert.ToDouble(Console.ReadLine());
                        user.Deposit(depositAmount);
                        break;
                    case "2":
                        Console.Write("Enter the amount you want to withdraw: ");
                        double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                        user.Withdraw(withdrawAmount);
                        break;
                    case "3":
                        Console.WriteLine($"Your current balance is: {user.Balance}");
                        break;
                    case "4":
                        continueTransactions = false;
                        Console.WriteLine("Thank you for using the ATM!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
