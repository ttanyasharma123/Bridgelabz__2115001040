using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class EmailExtractor
{
    // Extracts all email addresses from a given text
    public List<string> ExtractEmails(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return new List<string>();

        // Regex Explanation:
        // [a-zA-Z0-9._%+-]+ → Username part (allows letters, numbers, and special characters)
        // @ → Must contain "@" symbol
        // [a-zA-Z0-9.-]+ → Domain name part (allows letters, numbers, dots, and dashes)
        // \.[a-zA-Z]{2,} → TLD (must start with a dot and have at least 2 letters)
        string pattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";

        MatchCollection matches = Regex.Matches(text, pattern);
        List<string> emails = new List<string>();

        foreach (Match match in matches)
        {
            emails.Add(match.Value);
        }

        return emails;
    }
}


.testCase


using NUnit.Framework;
using System.Collections.Generic;

namespace EmailExtractorTests
{
    [TestFixture]
    public class EmailExtractorTests
    {
        private EmailExtractor _emailExtractor;

        [SetUp]
        public void Setup()
        {
            _emailExtractor = new EmailExtractor();
        }

        [Test]
        public void ExtractEmails_ValidEmails_ReturnsListOfEmails()
        {
            string text = "Contact us at support@example.com and info@company.org";
            List<string> result = _emailExtractor.ExtractEmails(text);

            Assert.AreEqual(2, result.Count);
            Assert.Contains("support@example.com", result);
            Assert.Contains("info@company.org", result);
        }

        [Test]
        public void ExtractEmails_NoEmails_ReturnsEmptyList()
        {
            string text = "No emails here, just a random text.";
            List<string> result = _emailExtractor.ExtractEmails(text);

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void ExtractEmails_MultipleEmails_ReturnsAllEmails()
        {
            string text = "Emails: john.doe@gmail.com, admin@site.net, user123@mycompany.com";
            List<string> result = _emailExtractor.ExtractEmails(text);

            Assert.AreEqual(3, result.Count);
            Assert.Contains("john.doe@gmail.com", result);
            Assert.Contains("admin@site.net", result);
            Assert.Contains("user123@mycompany.com", result);
        }

        [Test]
        public void ExtractEmails_InvalidEmails_IgnoresInvalidEmails()
        {
            string text = "Valid: user@valid.com Invalid: notAnEmail@com, @missingpart.com, name@.com";
            List<string> result = _emailExtractor.ExtractEmails(text);

            Assert.AreEqual(1, result.Count);
            Assert.Contains("user@valid.com", result);
        }

        [Test]
        public void ExtractEmails_NullOrEmpty_ReturnsEmptyList()
        {
            List<string> result1 = _emailExtractor.ExtractEmails(null);
            List<string> result2 = _emailExtractor.ExtractEmails("");

            Assert.AreEqual(0, result1.Count);
            Assert.AreEqual(0, result2.Count);
        }
    }
}







