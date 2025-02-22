using System;
using System.Text.RegularExpressions;

public class StringModifier
{
    // Replaces multiple spaces with a single space
    public string ReplaceMultipleSpaces(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        // Regex Explanation:
        // \s+ → Matches one or more spaces (whitespace)
        return Regex.Replace(input, @"\s+", " ").Trim();
    }
}




.TestCase




using NUnit.Framework;

namespace StringModifierTests
{
    [TestFixture]
    public class StringModifierTests
    {
        private StringModifier _stringModifier;

        [SetUp]
        public void Setup()
        {
            _stringModifier = new StringModifier();
        }

        [Test]
        public void ReplaceMultipleSpaces_InputWithExtraSpaces_ReturnsCleanString()
        {
            string input = "This   is   an   example   with   multiple    spaces.";
            string result = _stringModifier.ReplaceMultipleSpaces(input);
            Assert.AreEqual("This is an example with multiple spaces.", result);
        }

        [Test]
        public void ReplaceMultipleSpaces_StringWithLeadingAndTrailingSpaces_ReturnsTrimmedString()
        {
            string input = "   Hello   World!  ";
            string result = _stringModifier.ReplaceMultipleSpaces(input);
            Assert.AreEqual("Hello World!", result);
        }

        [Test]
        public void ReplaceMultipleSpaces_SingleSpaces_ReturnsSameString()
        {
            string input = "This is fine.";
            string result = _stringModifier.ReplaceMultipleSpaces(input);
            Assert.AreEqual("This is fine.", result);
        }

        [Test]
        public void ReplaceMultipleSpaces_OnlySpaces_ReturnsEmptyString()
        {
            string input = "       ";
            string result = _stringModifier.ReplaceMultipleSpaces(input);
            Assert.AreEqual("", result);
        }

        [Test]
        public void ReplaceMultipleSpaces_NullOrEmpty_ReturnsEmptyString()
        {
            string result1 = _stringModifier.ReplaceMultipleSpaces(null);
            string result2 = _stringModifier.ReplaceMultipleSpaces("");
            
            Assert.AreEqual("", result1);
            Assert.AreEqual("", result2);
        }
    }
}

