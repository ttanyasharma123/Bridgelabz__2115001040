using System;

public class BankAccount
{
    private double _balance;

    public BankAccount(double initialBalance = 0)
    {
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative.");
        _balance = initialBalance;
    }

    // Method to deposit money
    public void Deposit(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive.");
        _balance += amount;
    }

    // Method to withdraw money
    public void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive.");
        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds.");
        _balance -= amount;
    }

    // Method to check balance
    public double GetBalance()
    {
        return _balance;
    }
}






.Net Unit Test Case

using NUnit.Framework;
using System;

namespace BankAccountTests
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount _account;

        [SetUp]
        public void Setup()
        {
            _account = new BankAccount(100); // Initial balance = 100
        }

        [Test]
        public void Deposit_PositiveAmount_IncreasesBalance()
        {
            _account.Deposit(50);
            Assert.AreEqual(150, _account.GetBalance());
        }

        [Test]
        public void Deposit_NegativeAmount_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _account.Deposit(-10));
        }

        [Test]
        public void Withdraw_ValidAmount_DecreasesBalance()
        {
            _account.Withdraw(40);
            Assert.AreEqual(60, _account.GetBalance());
        }

        [Test]
        public void Withdraw_AmountGreaterThanBalance_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _account.Withdraw(200));
        }

        [Test]
        public void Withdraw_NegativeAmount_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _account.Withdraw(-20));
        }

        [Test]
        public void GetBalance_ReturnsCorrectBalance()
        {
            Assert.AreEqual(100, _account.GetBalance());
        }
    }
}



