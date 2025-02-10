using System;
using System.Collections.Generic;

// Abstract class BankAccount
abstract class BankAccount
{
    protected string accountNumber;
    protected string holderName;
    protected double balance;

    public BankAccount(string accountNumber, string holderName, double balance)
    {
        this.accountNumber = accountNumber;
        this.holderName = holderName;
        this.balance = balance;
    }

    public void Deposit(double amount)
    {
        balance += amount;
        Console.WriteLine($"Deposited {amount:C} into {accountNumber}. New Balance: {balance:C}");
    }

    public virtual void Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrew {amount:C} from {accountNumber}. New Balance: {balance:C}");
        }
        else
        {
            Console.WriteLine("Insufficient balance!");
        }
    }

    public abstract double CalculateInterest();

    public virtual void DisplayAccountDetails()
    {
        Console.WriteLine($"Account Number: {accountNumber}, Holder: {holderName}, Balance: {balance:C}");
    }
}

// Interface ILoanable
interface ILoanable
{
    void ApplyForLoan(double amount);
    bool CalculateLoanEligibility();
}

// SavingsAccount class
class SavingsAccount : BankAccount, ILoanable
{
    private double interestRate = 0.04; // 4% annual interest

    public SavingsAccount(string accountNumber, string holderName, double balance)
        : base(accountNumber, holderName, balance) { }

    public override double CalculateInterest()
    {
        return balance * interestRate;
    }

    public void ApplyForLoan(double amount)
    {
        Console.WriteLine($"Loan of {amount:C} applied for Savings Account {accountNumber}.");
    }

    public bool CalculateLoanEligibility()
    {
        return balance >= 5000; // Eligible if balance >= 5000
    }
}

// CurrentAccount class
class CurrentAccount : BankAccount
{
    public CurrentAccount(string accountNumber, string holderName, double balance)
        : base(accountNumber, holderName, balance) { }

    public override double CalculateInterest()
    {
        return 0; // No interest for current accounts
    }

    public override void Withdraw(double amount)
    {
        if (amount <= balance + 10000) // Overdraft limit of 10,000
        {
            balance -= amount;
            Console.WriteLine($"Withdrew {amount:C} from {accountNumber}. New Balance: {balance:C}");
        }
        else
        {
            Console.WriteLine("Overdraft limit exceeded!");
        }
    }
}

// Main program
class Program
{
    static void ProcessAccounts(List<BankAccount> accounts)
    {
        foreach (var account in accounts)
        {
            account.DisplayAccountDetails();
            double interest = account.CalculateInterest();
            Console.WriteLine($"Interest Earned: {interest:C}\n");
        }
    }

    static void Main()
    {
        List<BankAccount> accounts = new List<BankAccount>
        {
            new SavingsAccount("SA123", "Abhi", 10000),
            new CurrentAccount("CA456", "Bobby", 5000)
        };

        ProcessAccounts(accounts);
    }
}
