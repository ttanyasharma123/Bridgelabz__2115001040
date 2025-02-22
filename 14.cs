using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class CurrencyExtractor
{
    // Extracts currency values from a given text
    public List<string> ExtractCurrencyValues(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return new List<string>();

        // Regex Pattern for Currency Extraction:
        // \$\s*\d+(\.\d{2})? → Matches "$", optional space, then numbers (e.g., "$45.99", "$ 10.50")
        string pattern = @"\$\s*\d+(\.\d{2})?";

        MatchCollection matches = Regex.Matches(text, pattern);
        List<string> currencyValues = new List<string>();

        foreach (Match match in matches)
        {
            // Remove extra spaces before numbers
            currencyValues.Add(match.Value.Replace(" ", ""));
        }

        return currencyValues;
    }
}





.TestCase

using NUnit.Framework;
using System.Collections.Generic;

namespace CurrencyExtractorTests
{
    [TestFixture]
    public class CurrencyExtractorTests
    {
        private CurrencyExtractor _currencyExtractor;

        [SetUp]
        public void Setup()
        {
            _currencyExtractor = new CurrencyExtractor();
        }

        [Test]
        public void ExtractCurrencyValues_ValidCurrencyValues_ReturnsAllValues()
        {
            string text = "The price is $45.99, and the discount is $ 10.50.";
            List<string> result = _currencyExtractor.ExtractCurrencyValues(text);

            List<string> expected = new List<string> { "$45.99", "$10.50" };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ExtractCurrencyValues_NoCurrencyValues_ReturnsEmptyList()
        {
            string text = "There are no currency values in this text.";
            List<string> result = _currencyExtractor.ExtractCurrencyValues(text);

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void ExtractCurrencyValues_MultipleCurrencies_ReturnsCorrectValues()
        {
            string text = "Item A costs $5, Item B costs $ 100.00, and Item C is priced at $25.50.";
            List<string> result = _currencyExtractor.ExtractCurrencyValues(text);

            List<string> expected = new List<string> { "$5", "$100.00", "$25.50" };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ExtractCurrencyValues_InvalidFormats_IgnoresIncorrectFormats()
        {
            string text = "Valid: $45.99 Invalid: 45.99$, $45,99";
            List<string> result = _currencyExtractor.ExtractCurrencyValues(text);

            Assert.AreEqual(1, result.Count);
            Assert.Contains("$45.99", result);
        }

        [Test]
        public void ExtractCurrencyValues_NullOrEmpty_ReturnsEmptyList()
        {
            List<string> result1 = _currencyExtractor.ExtractCurrencyValues(null);
            List<string> result2 = _currencyExtractor.ExtractCurrencyValues("");

            Assert.AreEqual(0, result1.Count);
            Assert.AreEqual(0, result2.Count);
        }
    }
}

