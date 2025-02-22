using System;
using System.Globalization;

public class DateFormatter
{
    // Converts yyyy-MM-dd to dd-MM-yyyy
    public string FormatDate(string inputDate)
    {
        if (string.IsNullOrWhiteSpace(inputDate))
            throw new ArgumentException("Date cannot be null or empty.");

        if (!DateTime.TryParseExact(inputDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            throw new FormatException("Invalid date format. Expected yyyy-MM-dd.");

        return date.ToString("dd-MM-yyyy");
    }
}






.Net Unit Test 


using NUnit.Framework;
using System;

namespace DateFormatterTests
{
    [TestFixture]
    public class DateFormatterTests
    {
        private DateFormatter _dateFormatter;

        [SetUp]
        public void Setup()
        {
            _dateFormatter = new DateFormatter();
        }

        [Test]
        public void FormatDate_ValidDate_ReturnsFormattedDate()
        {
            string result = _dateFormatter.FormatDate("2024-02-20");
            Assert.AreEqual("20-02-2024", result);
        }

        [Test]
        public void FormatDate_AnotherValidDate_ReturnsFormattedDate()
        {
            string result = _dateFormatter.FormatDate("1999-12-31");
            Assert.AreEqual("31-12-1999", result);
        }

        [Test]
        public void FormatDate_EmptyString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _dateFormatter.FormatDate(""));
        }

        [Test]
        public void FormatDate_InvalidFormat_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => _dateFormatter.FormatDate("20/02/2024"));
        }

        [Test]
        public void FormatDate_NonDateString_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => _dateFormatter.FormatDate("random-text"));
        }

        [Test]
        public void FormatDate_NullInput_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _dateFormatter.FormatDate(null));
        }
    }
}

