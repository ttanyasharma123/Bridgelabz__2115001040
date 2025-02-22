using System;

public class DatabaseConnection
{
    public bool IsConnected { get; private set; }

    // Simulating database connection
    public void Connect()
    {
        IsConnected = true;
        Console.WriteLine("Database Connected.");
    }

    // Simulating disconnecting the database
    public void Disconnect()
    {
        IsConnected = false;
        Console.WriteLine("Database Disconnected.");
    }
}



.Nunit Test cases


using NUnit.Framework;
using System;

namespace DatabaseConnectionTests
{
    [TestFixture]
    public class DatabaseConnectionTests
    {
        private DatabaseConnection _dbConnection;

        [SetUp] // Runs before each test
        public void Setup()
        {
            _dbConnection = new DatabaseConnection();
            _dbConnection.Connect();
        }

        [Test]
        public void Connect_ConnectionIsEstablished()
        {
            Assert.IsTrue(_dbConnection.IsConnected, "Database should be connected after calling Connect().");
        }

        [Test]
        public void Disconnect_ConnectionIsClosed()
        {
            _dbConnection.Disconnect();
            Assert.IsFalse(_dbConnection.IsConnected, "Database should be disconnected after calling Disconnect().");
        }

        [TearDown] // Runs after each test
        public void Cleanup()
        {
            _dbConnection.Disconnect();
        }
    }
}




