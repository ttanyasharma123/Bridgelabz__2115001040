using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

public class DateExtractor
{
    // Extracts all valid dates in dd/mm/yyyy format from a given text
    public List<string> ExtractDates(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return new List<string>();

        // Regex pattern to match dd/mm/yyyy format
        string pattern = @"\b(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/(19|20)\d{2}\b";
        MatchCollection matches = Regex.Matches(text, pattern);
        List<string> validDates = new List<string>();

        foreach (Match match in matches)
        {
            if (IsValidDate(match.Value))
            {
                validDates.Add(match.Value);
            }
        }

        return validDates;
    }

    // Validates whether a date is real (e.g., avoids 30th Feb)
    private bool IsValidDate(string date)
    {
        return DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
    }
}





.TestCase

using NUnit.Framework;
using System.Collections.Generic;

namespace DateExtractorTests
{
    [TestFixture]
    public class DateExtractorTests
    {
        private DateExtractor _dateExtractor;

        [SetUp]
        public void Setup()
        {
            _dateExtractor = new DateExtractor();
        }

        [Test]
        public void ExtractDates_ValidDates_ReturnsAllDates()
        {
            string text = "The events are scheduled for 12/05/2023, 15/08/2024, and 29/02/2020.";
            List<string> result = _dateExtractor.ExtractDates(text);

            List<string> expected = new List<string> { "12/05/2023", "15/08/2024", "29/02/2020" };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ExtractDates_NoDates_ReturnsEmptyList()
        {
            string text = "There are no valid dates in this sentence.";
            List<string> result = _dateExtractor.ExtractDates(text);

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void ExtractDates_MixedTextWithDates_ReturnsOnlyValidDates()
        {
            string text = "Today is 01/01/2025. The meeting was on 30/02/2022 (invalid date) and 15/07/2021.";
            List<string> result = _dateExtractor.ExtractDates(text);

            List<string> expected = new List<string> { "01/01/2025", "15/07/2021" };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ExtractDates_InvalidFormats_IgnoresIncorrectFormats()
        {
            string text = "Valid: 05/06/2022 Invalid: 5/6/2022, 32/01/2023, 15-07-2021";
            List<string> result = _dateExtractor.ExtractDates(text);

            Assert.AreEqual(1, result.Count);
            Assert.Contains("05/06/2022", result);
        }

        [Test]
        public void ExtractDates_NullOrEmpty_ReturnsEmptyList()
        {
            List<string> result1 = _dateExtractor.ExtractDates(null);
            List<string> result2 = _dateExtractor.ExtractDates("");

            Assert.AreEqual(0, result1.Count);
            Assert.AreEqual(0, result2.Count);
        }
    }
}



