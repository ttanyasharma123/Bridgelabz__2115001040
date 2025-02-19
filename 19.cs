using System;
using System.Collections.Generic;
using System.Linq;

class BankingSystem
{
    private Dictionary<int, double> accountBalances = new Dictionary<int, double>();  // Stores account balances
    private SortedDictionary<double, List<int>> sortedBalances = new SortedDictionary<double, List<int>>();  // Sorts by balance
    private Queue<Tuple<int, double>> withdrawalQueue = new Queue<Tuple<int, double>>();  // Stores withdrawal requests

    // Method to add an account
    public void AddAccount(int accountNumber, double balance)
    {
        if (!accountBalances.ContainsKey(accountNumber))
        {
            accountBalances[accountNumber] = balance;
            UpdateSortedBalances(accountNumber, balance);
        }
        else
        {
            Console.WriteLine(string.Format("Account {0} already exists.", accountNumber));
        }
    }

    // Method to deposit money
    public void Deposit(int accountNumber, double amount)
    {
        if (accountBalances.ContainsKey(accountNumber))
        {
            double oldBalance = accountBalances[accountNumber];
            accountBalances[accountNumber] += amount;
            UpdateSortedBalances(accountNumber, oldBalance, accountBalances[accountNumber]);
        }
        else
        {
            Console.WriteLine(string.Format("Account {0} not found.", accountNumber));
        }
    }

    // Method to request a withdrawal
    public void RequestWithdrawal(int accountNumber, double amount)
    {
        if (accountBalances.ContainsKey(accountNumber))
        {
            withdrawalQueue.Enqueue(new Tuple<int, double>(accountNumber, amount));
            Console.WriteLine(string.Format("Withdrawal request of ${0:F2} for account {1} added to queue.", amount, accountNumber));
        }
        else
        {
            Console.WriteLine(string.Format("Account {0} not found.", accountNumber));
        }
    }

    // Method to process withdrawals
    public void ProcessWithdrawals()
    {
        while (withdrawalQueue.Count > 0)
        {
            Tuple<int, double> request = withdrawalQueue.Dequeue();
            int accountNumber = request.Item1;
            double amount = request.Item2;

            if (accountBalances.ContainsKey(accountNumber) && accountBalances[accountNumber] >= amount)
            {
                double oldBalance = accountBalances[accountNumber];
                accountBalances[accountNumber] -= amount;
                UpdateSortedBalances(accountNumber, oldBalance, accountBalances[accountNumber]);

                Console.WriteLine(string.Format("Withdrawal of ${0:F2} from account {1} processed successfully.", amount, accountNumber));
            }
            else
            {
                Console.WriteLine(string.Format("Insufficient funds for withdrawal of ${0:F2} from account {1}.", amount, accountNumber));
            }
        }
    }

    // Method to display all account balances
    public void DisplayBalances()
    {
        Console.WriteLine("\nAccount Balances:");
        foreach (var entry in accountBalances)
        {
            Console.WriteLine(string.Format("Account {0}: ${1:F2}", entry.Key, entry.Value));
        }
    }

    // Method to display accounts sorted by balance
    public void DisplaySortedBalances()
    {
        Console.WriteLine("\nAccounts Sorted by Balance:");
        foreach (var entry in sortedBalances)
        {
            foreach (var account in entry.Value)
            {
                Console.WriteLine(string.Format("Account {0}: ${1:F2}", account, entry.Key));
            }
        }
    }

    // Helper method to update sorted balances
    private void UpdateSortedBalances(int accountNumber, double oldBalance, double newBalance = -1)
    {
        if (newBalance == -1)
        {
            newBalance = oldBalance;
        }

        if (sortedBalances.ContainsKey(oldBalance))
        {
            sortedBalances[oldBalance].Remove(accountNumber);
            if (sortedBalances[oldBalance].Count == 0)
            {
                sortedBalances.Remove(oldBalance);
            }
        }

        if (!sortedBalances.ContainsKey(newBalance))
        {
            sortedBalances[newBalance] = new List<int>();
        }
        sortedBalances[newBalance].Add(accountNumber);
    }
}

class Program
{
    static void Main()
    {
        BankingSystem bank = new BankingSystem();

        // Add sample accounts
        bank.AddAccount(101, 5000.00);
        bank.AddAccount(102, 3000.00);
        bank.AddAccount(103, 7000.00);
        bank.AddAccount(104, 1000.00);

        // Display balances
        bank.DisplayBalances();
        bank.DisplaySortedBalances();

        // Deposit money
        bank.Deposit(101, 2000.00);
        bank.Deposit(102, 500.00);

        // Request withdrawals
        bank.RequestWithdrawal(103, 2000.00);
        bank.RequestWithdrawal(104, 1500.00); // Insufficient funds

        // Process withdrawals
        bank.ProcessWithdrawals();

        // Display updated balances
        bank.DisplayBalances();
        bank.DisplaySortedBalances();
    }
}
