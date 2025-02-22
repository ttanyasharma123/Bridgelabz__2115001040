using System;
using System.Text.RegularExpressions;

public class CreditCardValidator
{
    // Validates Visa and MasterCard numbers
    public bool IsValidCreditCard(string cardNumber)
    {
        if (string.IsNullOrWhiteSpace(cardNumber))
            return false;

        // Visa: Starts with 4, exactly 16 digits
        string visaPattern = @"^4\d{15}$";

        // MasterCard: Starts with 5, exactly 16 digits
        string masterCardPattern = @"^5\d{15}$";

        return Regex.IsMatch(cardNumber, visaPattern) || Regex.IsMatch(cardNumber, masterCardPattern);
    }
}





.TestCalss


using NUnit.Framework;

namespace CreditCardValidatorTests
{
    [TestFixture]
    public class CreditCardValidatorTests
    {
        private CreditCardValidator _creditCardValidator;

        [SetUp]
        public void Setup()
        {
            _creditCardValidator = new CreditCardValidator();
        }

        [Test]
        public void IsValidCreditCard_ValidVisa_ReturnsTrue()
        {
            Assert.IsTrue(_creditCardValidator.IsValidCreditCard("4111111111111111")); // Valid Visa
        }

        [Test]
        public void IsValidCreditCard_ValidMasterCard_ReturnsTrue()
        {
            Assert.IsTrue(_creditCardValidator.IsValidCreditCard("5111111111111111")); // Valid MasterCard
        }

        [Test]
        public void IsValidCreditCard_InvalidLength_ReturnsFalse()
        {
            Assert.IsFalse(_creditCardValidator.IsValidCreditCard("41111111111111"));  // 14 digits
            Assert.IsFalse(_creditCardValidator.IsValidCreditCard("511111111111111111")); // 18 digits
        }

        [Test]
        public void IsValidCreditCard_InvalidPrefix_ReturnsFalse()
        {
            Assert.IsFalse(_creditCardValidator.IsValidCreditCard("3111111111111111")); // Starts with 3
            Assert.IsFalse(_creditCardValidator.IsValidCreditCard("6111111111111111")); // Starts with 6
        }

        [Test]
        public void IsValidCreditCard_NonNumeric_ReturnsFalse()
        {
            Assert.IsFalse(_creditCardValidator.IsValidCreditCard("4111-1111-1111-1111")); // Contains hyphens
            Assert.IsFalse(_creditCardValidator.IsValidCreditCard("5111a11111111111"));   // Contains letters
        }

        [Test]
        public void IsValidCreditCard_NullOrEmpty_ReturnsFalse()
        {
            Assert.IsFalse(_creditCardValidator.IsValidCreditCard(null));
            Assert.IsFalse(_creditCardValidator.IsValidCreditCard(""));
        }
    }
}



