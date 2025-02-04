using System;

class BankAccount
{
    // Static variable shared across all accounts
    private static string bankName = "SBI";
    private static int totalAccounts = 0;

    // Readonly property for AccountNumber (can only be set in constructor)
    public int AccountNumber { get; private set; }

    // Public properties for AccountHolderName and Balance
    public string AccountHolderName { get; private set; }
    public double Balance { get; private set; }

    // Constructor using 'this' to resolve ambiguity
    public BankAccount(string accountHolderName, int accountNumber, double initialBalance)
    {
        this.AccountHolderName = accountHolderName;
        this.AccountNumber = accountNumber;
        this.Balance = initialBalance;
        totalAccounts++; // Increment total account count
    }

    // Static method to get total number of accounts
    public static void GetTotalAccounts()
    {
        Console.WriteLine("Total Bank Accounts: " + totalAccounts);
    }

    // Method to deposit money
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine("Deposited: " + amount);
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    // Method to withdraw money
    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine("Withdrawn: " + amount);
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount or insufficient balance.");
        }
    }

    // Method to display account details
    public void DisplayAccountDetails()
    {
        // Using 'is' operator to check instance type
        if (this is BankAccount)
        {
            Console.WriteLine("Bank: " + bankName);
            Console.WriteLine("Account Holder: " + AccountHolderName);
            Console.WriteLine("Account Number: " + AccountNumber);
            Console.WriteLine("Balance: " + Balance);
            Console.WriteLine();
        }
    }

    static void Main()
    {
        // Creating bank accounts
        BankAccount acc1 = new BankAccount("John Doe", 1001, 5000);
        BankAccount acc2 = new BankAccount("Jane Smith", 1002, 10000);

        // Performing transactions
        acc1.Deposit(2000);
        acc1.Withdraw(1000);
        acc2.Withdraw(500);

        // Displaying details
        acc1.DisplayAccountDetails();
        acc2.DisplayAccountDetails();

        // Display total accounts
        BankAccount.GetTotalAccounts();
    }
}