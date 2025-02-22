using System;
using System.Text.RegularExpressions;

public class SSNValidator
{
    // Validates a Social Security Number (SSN) in the format XXX-XX-XXXX
    public bool IsValidSSN(string ssn)
    {
        if (string.IsNullOrWhiteSpace(ssn))
            return false;

        // Regex Pattern for SSN Validation:
        // ^\d{3}-\d{2}-\d{4}$ → Matches "XXX-XX-XXXX" format (digits only)
        string pattern = @"^\d{3}-\d{2}-\d{4}$";

        return Regex.IsMatch(ssn, pattern);
    }
}


.TestCase 

using NUnit.Framework;

namespace SSNValidatorTests
{
    [TestFixture]
    public class SSNValidatorTests
    {
        private SSNValidator _ssnValidator;

        [SetUp]
        public void Setup()
        {
            _ssnValidator = new SSNValidator();
        }

        [Test]
        public void IsValidSSN_ValidSSN_ReturnsTrue()
        {
            Assert.IsTrue(_ssnValidator.IsValidSSN("123-45-6789")); // Valid SSN
        }

        [Test]
        public void IsValidSSN_MissingDashes_ReturnsFalse()
        {
            Assert.IsFalse(_ssnValidator.IsValidSSN("123456789")); // Missing dashes
        }

        [Test]
        public void IsValidSSN_IncorrectFormat_ReturnsFalse()
        {
            Assert.IsFalse(_ssnValidator.IsValidSSN("123-456-789")); // Incorrect groupings
            Assert.IsFalse(_ssnValidator.IsValidSSN("12-345-6789")); // Incorrect first group
        }

        [Test]
        public void IsValidSSN_ContainsLettersOrSpecialChars_ReturnsFalse()
        {
            Assert.IsFalse(_ssnValidator.IsValidSSN("123-AB-6789")); // Letters
            Assert.IsFalse(_ssnValidator.IsValidSSN("123_45_6789")); // Underscores instead of dashes
        }

        [Test]
        public void IsValidSSN_NullOrEmpty_ReturnsFalse()
        {
            Assert.IsFalse(_ssnValidator.IsValidSSN(null));
            Assert.IsFalse(_ssnValidator.IsValidSSN(""));
        }
    }
}



