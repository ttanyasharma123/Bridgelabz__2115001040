using System;

// Custom Exception for Insufficient Funds
class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message) { }
}

class BankAccount
{
    private double balance;

    // Constructor to initialize balance
    public BankAccount(double initialBalance)
    {
        balance = initialBalance;
    }

    // Method to withdraw money
    public void Withdraw(double amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Invalid amount!");
        }
        if (amount > balance)
        {
            throw new InsufficientFundsException("Insufficient balance!");
        }

        balance -= amount;
        Console.WriteLine($"Withdrawal successful, new balance: {balance}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Initializing account with some balance
            BankAccount account = new BankAccount(5000); // Assume initial balance is 5000

            // Taking user input for withdrawal
            Console.Write("Enter amount to withdraw: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            // Attempting withdrawal
            account.Withdraw(amount);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a valid numeric amount.");
        }
        finally
        {
            Console.WriteLine("Transaction completed.");
        }
    }
}
