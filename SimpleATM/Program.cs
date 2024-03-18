namespace SimpleATM
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize and start the ATM system
            ATMSystem atmSystem = new ATMSystem("123456789", 1234, "John Smith", 1000.00);
            atmSystem.Start();
        }
    }
}