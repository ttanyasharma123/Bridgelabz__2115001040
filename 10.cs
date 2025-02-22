using System;
using System.Text.RegularExpressions;

public class IPAddressValidator
{
    // Validates an IPv4 address
    public bool IsValidIPv4(string ipAddress)
    {
        if (string.IsNullOrWhiteSpace(ipAddress))
            return false;

        // Regex Explanation:
        // ^ → Start of the string
        // (25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]?|0) → Matches 0-255
        // (\.(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]?|0)){3} → Ensures three more dot-separated groups
        // $ → End of the string
        string pattern = @"^(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]?|0)(\.(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9][0-9]?|0)){3}$";

        return Regex.IsMatch(ipAddress, pattern);
    }
}




.TestCase



using NUnit.Framework;

namespace IPAddressValidatorTests
{
    [TestFixture]
    public class IPAddressValidatorTests
    {
        private IPAddressValidator _ipValidator;

        [SetUp]
        public void Setup()
        {
            _ipValidator = new IPAddressValidator();
        }

        [Test]
        public void IsValidIPv4_ValidIP_ReturnsTrue()
        {
            Assert.IsTrue(_ipValidator.IsValidIPv4("192.168.1.1"));
            Assert.IsTrue(_ipValidator.IsValidIPv4("0.0.0.0"));
            Assert.IsTrue(_ipValidator.IsValidIPv4("255.255.255.255"));
        }

        [Test]
        public void IsValidIPv4_InvalidIP_OutOfRangeNumbers_ReturnsFalse()
        {
            Assert.IsFalse(_ipValidator.IsValidIPv4("256.100.50.25")); // 256 is out of range
            Assert.IsFalse(_ipValidator.IsValidIPv4("192.300.1.1"));  // 300 is out of range
        }

        [Test]
        public void IsValidIPv4_InvalidIP_WrongFormat_ReturnsFalse()
        {
            Assert.IsFalse(_ipValidator.IsValidIPv4("192.168.1"));      // Missing last octet
            Assert.IsFalse(_ipValidator.IsValidIPv4("192.168.1.1.5")); // Extra octet
            Assert.IsFalse(_ipValidator.IsValidIPv4("192,168,1,1"));  // Commas instead of dots
        }

        [Test]
        public void IsValidIPv4_InvalidIP_LeadingZeros_ReturnsFalse()
        {
            Assert.IsFalse(_ipValidator.IsValidIPv4("192.168.01.1")); // Leading zero in octet
            Assert.IsFalse(_ipValidator.IsValidIPv4("192.168.1.01"));
        }

        [Test]
        public void IsValidIPv4_NullOrEmpty_ReturnsFalse()
        {
            Assert.IsFalse(_ipValidator.IsValidIPv4(null));
            Assert.IsFalse(_ipValidator.IsValidIPv4(""));
        }
    }
}

