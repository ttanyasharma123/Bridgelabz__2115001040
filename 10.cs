using System;
using System.Text.RegularExpressions;

public class PasswordValidator
{
    // Method to validate password strength
    public bool IsValid(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return false;

        // Must be at least 8 characters long
        if (password.Length < 8)
            return false;

        // Must contain at least one uppercase letter
        if (!Regex.IsMatch(password, "[A-Z]"))
            return false;

        // Must contain at least one digit
        if (!Regex.IsMatch(password, "\\d"))
            return false;

        return true;
    }
}




.NetUnit Test 

using NUnit.Framework;

namespace PasswordValidatorTests
{
    [TestFixture]
    public class PasswordValidatorTests
    {
        private PasswordValidator _passwordValidator;

        [SetUp]
        public void Setup()
        {
            _passwordValidator = new PasswordValidator();
        }

        [Test]
        public void IsValid_ValidPassword_ReturnsTrue()
        {
            Assert.IsTrue(_passwordValidator.IsValid("StrongPass1"));
        }

        [Test]
        public void IsValid_PasswordTooShort_ReturnsFalse()
        {
            Assert.IsFalse(_passwordValidator.IsValid("Short1"));
        }

        [Test]
        public void IsValid_PasswordWithoutUppercase_ReturnsFalse()
        {
            Assert.IsFalse(_passwordValidator.IsValid("weakpassword1"));
        }

        [Test]
        public void IsValid_PasswordWithoutDigit_ReturnsFalse()
        {
            Assert.IsFalse(_passwordValidator.IsValid("NoNumberHere"));
        }

        [Test]
        public void IsValid_EmptyPassword_ReturnsFalse()
        {
            Assert.IsFalse(_passwordValidator.IsValid(""));
        }

        [Test]
        public void IsValid_NullPassword_ReturnsFalse()
        {
            Assert.IsFalse(_passwordValidator.IsValid(null));
        }
    }
}



