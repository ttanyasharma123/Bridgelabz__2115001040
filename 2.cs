using System;
using System.Collections.Generic;

// Class representing a Bank
class Bank
{
    public string Name { get; private set; }
    public List<Customer> Customers { get; private set; }

    public Bank(string name)
    {
        Name = name;
        Customers = new List<Customer>();
    }
    // Method to open a new account for a customer
    public Account OpenAccount(Customer customer, decimal initialBalance)
    {
        Account account = new Account(this, customer, initialBalance);
        customer.Accounts.Add(account);
        if (!Customers.Contains(customer))
        {
            Customers.Add(customer);
        }
        Console.WriteLine("Account opened for " + customer.Name + " at " + Name + " with balance " + initialBalance);
        return account;
    }
}
// Class representing a Customer
class Customer
{
    public string Name { get; private set; }
    public List<Account> Accounts { get; private set; }

    public Customer(string name)
    {
        Name = name;
        Accounts = new List<Account>();
    }

    public void ViewBalance()
    {
        foreach (var account in Accounts)
        {
            Console.WriteLine("Account at " + account.Bank.Name + ": Balance " + account.Balance);
        }
    }
}

// Class representing a Bank Account
class Account
{
    public Bank Bank { get; private set; }
    public Customer Customer { get; private set; }
    public decimal Balance { get; private set; }

    public Account(Bank bank, Customer customer, decimal balance)
    {
        Bank = bank;
        Customer = customer;
        Balance = balance;
    }
}

class Program
{
    static void Main()
    {
        // Creating a new bank
        Bank bank1 = new Bank("HDFC Bank");
        // Creating a new customer
        Customer customer1 = new Customer("Aman");
        // Opening an account for the customer in the bank with an initial balance
        Account account1 = bank1.OpenAccount(customer1, 1500);
        // Viewing the balance of the customer's accounts
        customer1.ViewBalance();
    }
}
