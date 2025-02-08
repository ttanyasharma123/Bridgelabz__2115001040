using System;

// Base class: BankAccount
class BankAccount
{
    public int AccountNumber { get; set; }
    public double Balance { get; set; }

    public BankAccount(int accountNumber, double balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }

    public virtual void DisplayAccountType()
    {
        Console.WriteLine("This is a general bank account.");
    }
}

// Subclass: SavingsAccount
class SavingsAccount : BankAccount
{
    public double InterestRate { get; set; }

    public SavingsAccount(int accountNumber, double balance, double interestRate)
        : base(accountNumber, balance)
    {
        InterestRate = interestRate;
    }

    public override void DisplayAccountType()
    {
        Console.WriteLine("This is a Savings Account with an interest rate of " + InterestRate + "%.");
    }
}

// Subclass: CheckingAccount
class CheckingAccount : BankAccount
{
    public double WithdrawalLimit { get; set; }

    public CheckingAccount(int accountNumber, double balance, double withdrawalLimit)
        : base(accountNumber, balance)
    {
        WithdrawalLimit = withdrawalLimit;
    }

    public override void DisplayAccountType()
    {
        Console.WriteLine("This is a Checking Account with a withdrawal limit of $" + WithdrawalLimit);
    }
}

// Subclass: FixedDepositAccount
class FixedDepositAccount : BankAccount
{
    public int MaturityPeriod { get; set; } // in months

    public FixedDepositAccount(int accountNumber, double balance, int maturityPeriod)
        : base(accountNumber, balance)
    {
        MaturityPeriod = maturityPeriod;
    }

    public override void DisplayAccountType()
    {
        Console.WriteLine("This is a Fixed Deposit Account with a maturity period of " + MaturityPeriod + " months.");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        SavingsAccount savings = new SavingsAccount(1001, 5000, 4.5);
        CheckingAccount checking = new CheckingAccount(1002, 3000, 1000);
        FixedDepositAccount fixedDeposit = new FixedDepositAccount(1003, 10000, 12);

        savings.DisplayAccountType();
        checking.DisplayAccountType();
        fixedDeposit.DisplayAccountType();
    }
}
