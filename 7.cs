using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class LinkExtractor
{
    // Extracts all valid URLs from a given text
    public List<string> ExtractLinks(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return new List<string>();

        // Regex Pattern for URL extraction
        // https? → Matches "http" or "https"
        // :\/\/ → Matches "://"
        // [\w.-]+ → Matches domain name (e.g., google, example)
        // \.[a-z]{2,} → Matches top-level domain (.com, .org, .net, etc.)
        // (\/\S*)? → Matches optional path after the domain
        string pattern = @"https?:\/\/[\w.-]+\.[a-z]{2,}(/\S*)?";

        MatchCollection matches = Regex.Matches(text, pattern);
        List<string> links = new List<string>();

        foreach (Match match in matches)
        {
            links.Add(match.Value);
        }

        return links;
    }
}


.Testcase




using NUnit.Framework;
using System.Collections.Generic;

namespace LinkExtractorTests
{
    [TestFixture]
    public class LinkExtractorTests
    {
        private LinkExtractor _linkExtractor;

        [SetUp]
        public void Setup()
        {
            _linkExtractor = new LinkExtractor();
        }

        [Test]
        public void ExtractLinks_ValidLinks_ReturnsAllLinks()
        {
            string text = "Visit https://www.google.com and http://example.org for more info.";
            List<string> result = _linkExtractor.ExtractLinks(text);

            List<string> expected = new List<string> { "https://www.google.com", "http://example.org" };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ExtractLinks_NoLinks_ReturnsEmptyList()
        {
            string text = "There are no links in this sentence.";
            List<string> result = _linkExtractor.ExtractLinks(text);

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void ExtractLinks_MultipleLinksWithPaths_ReturnsAllLinks()
        {
            string text = "Check out https://www.example.com/page and http://blog.site.net/articles/123.";
            List<string> result = _linkExtractor.ExtractLinks(text);

            List<string> expected = new List<string> { "https://www.example.com/page", "http://blog.site.net/articles/123" };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ExtractLinks_InvalidLinks_IgnoresIncorrectLinks()
        {
            string text = "Valid: https://site.com Invalid: www.example.com, ftp://files.net";
            List<string> result = _linkExtractor.ExtractLinks(text);

            Assert.AreEqual(1, result.Count);
            Assert.Contains("https://site.com", result);
        }

        [Test]
        public void ExtractLinks_NullOrEmpty_ReturnsEmptyList()
        {
            List<string> result1 = _linkExtractor.ExtractLinks(null);
            List<string> result2 = _linkExtractor.ExtractLinks("");

            Assert.AreEqual(0, result1.Count);
            Assert.AreEqual(0, result2.Count);
        }
    }
}







