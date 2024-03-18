using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleATM
{
    public class DebitCard
    {
        
        public string CardNum { get; private set; }
        public int Pin { get; private set; }
        public string Name { get; private set; }
        public double Balance { get; private set; }

       
        public DebitCard(string cardNum, int pin, string name, double balance)
        {
            CardNum = cardNum;
            Pin = pin;
            Name = name;
            Balance = balance;
        }

        //  methods  using delegates and events
        public delegate void TransactionHandler(DebitCard sender, double amount);
        public event TransactionHandler Deposited;
        public event TransactionHandler Withdrawn;
        public event TransactionHandler Transferred;

        public void Deposit(double amount)
        {
            Balance += amount;
            Deposited?.Invoke(this, amount);
        }

        public void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Withdrawn?.Invoke(this, amount);
            }
            else
            {
                Console.WriteLine("Insufficient funds");
            }
        }

        public void Transfer(DebitCard receiver, double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                receiver.Balance += amount;
                Transferred?.Invoke(this, amount);
            }
            else
            {
                Console.WriteLine("Insufficient funds for transfer");
            }
        }
    }
}
