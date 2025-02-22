using System;

public class StringUtils
{
    // Method to reverse a string
    public string Reverse(string str)
    {
        if (str == null) throw new ArgumentNullException(nameof(str));
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    // Method to check if a string is a palindrome
    public bool IsPalindrome(string str)
    {
        if (str == null) throw new ArgumentNullException(nameof(str));
        string reversed = Reverse(str);
        return string.Equals(str, reversed, StringComparison.OrdinalIgnoreCase);
    }

    // Method to convert a string to uppercase
    public string ToUpperCase(string str)
    {
        if (str == null) throw new ArgumentNullException(nameof(str));
        return str.ToUpper();
    }
}



.Nunit Test Cases 

using NUnit.Framework;
using System;

namespace StringUtilsTests
{
    [TestFixture]
    public class StringUtilsTests
    {
        private StringUtils _stringUtils;

        [SetUp]
        public void Setup()
        {
            _stringUtils = new StringUtils();
        }

        [Test]
        public void Reverse_ValidString_ReturnsReversedString()
        {
            string result = _stringUtils.Reverse("hello");
            Assert.AreEqual("olleh", result);
        }

        [Test]
        public void Reverse_EmptyString_ReturnsEmptyString()
        {
            string result = _stringUtils.Reverse("");
            Assert.AreEqual("", result);
        }

        [Test]
        public void Reverse_NullString_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stringUtils.Reverse(null));
        }

        [Test]
        public void IsPalindrome_PalindromeString_ReturnsTrue()
        {
            bool result = _stringUtils.IsPalindrome("madam");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindrome_NonPalindromeString_ReturnsFalse()
        {
            bool result = _stringUtils.IsPalindrome("hello");
            Assert.IsFalse(result);
        }

        [Test]
        public void IsPalindrome_CaseInsensitivePalindrome_ReturnsTrue()
        {
            bool result = _stringUtils.IsPalindrome("MadAm");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsPalindrome_NullString_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stringUtils.IsPalindrome(null));
        }

        [Test]
        public void ToUpperCase_ValidString_ReturnsUpperCaseString()
        {
            string result = _stringUtils.ToUpperCase("hello");
            Assert.AreEqual("HELLO", result);
        }

        [Test]
        public void ToUpperCase_AlreadyUpperCase_ReturnsSameString()
        {
            string result = _stringUtils.ToUpperCase("HELLO");
            Assert.AreEqual("HELLO", result);
        }

        [Test]
        public void ToUpperCase_NullString_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stringUtils.ToUpperCase(null));
        }
    }
}




