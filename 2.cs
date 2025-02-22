using System;
using System.Text.RegularExpressions;

public class UsernameValidator
{
    // Validates a username based on given rules
    public bool IsValidUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            return false;

        // Regex Explanation:
        // ^[A-Za-z]   → Must start with a letter
        // [A-Za-z0-9_]{4,14}$ → Can contain letters, numbers, underscores, and be 5-15 characters long
        string pattern = "^[A-Za-z][A-Za-z0-9_]{4,14}$";
        return Regex.IsMatch(username, pattern);
    }
}






.testCase




using NUnit.Framework;

namespace UsernameValidatorTests
{
    [TestFixture]
    public class UsernameValidatorTests
    {
        private UsernameValidator _usernameValidator;

        [SetUp]
        public void Setup()
        {
            _usernameValidator = new UsernameValidator();
        }

        [Test]
        public void IsValidUsername_ValidUsername_ReturnsTrue()
        {
            Assert.IsTrue(_usernameValidator.IsValidUsername("user_123"));
        }

        [Test]
        public void IsValidUsername_StartsWithNumber_ReturnsFalse()
        {
            Assert.IsFalse(_usernameValidator.IsValidUsername("123user"));
        }

        [Test]
        public void IsValidUsername_TooShort_ReturnsFalse()
        {
            Assert.IsFalse(_usernameValidator.IsValidUsername("us"));
        }

        [Test]
        public void IsValidUsername_TooLong_ReturnsFalse()
        {
            Assert.IsFalse(_usernameValidator.IsValidUsername("ThisIsAVeryLongUsername123"));
        }

        [Test]
        public void IsValidUsername_ContainsInvalidCharacters_ReturnsFalse()
        {
            Assert.IsFalse(_usernameValidator.IsValidUsername("user@123"));
        }

        [Test]
        public void IsValidUsername_NullOrEmpty_ReturnsFalse()
        {
            Assert.IsFalse(_usernameValidator.IsValidUsername(null));
            Assert.IsFalse(_usernameValidator.IsValidUsername(""));
        }
    }
}

