using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ProgrammingLanguageExtractor
{
    private readonly HashSet<string> _programmingLanguages;

    public ProgrammingLanguageExtractor()
    {
        // Define a set of common programming languages
        _programmingLanguages = new HashSet<string>
        {
            "Java", "Python", "JavaScript", "C", "C++", "C#", "Ruby", "Go", "Swift", "Kotlin",
            "PHP", "TypeScript", "Rust", "Perl", "Scala", "Dart", "Haskell", "Lua", "Objective-C"
        };
    }

    // Extracts programming language names from text
    public List<string> ExtractLanguages(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return new List<string>();

        List<string> foundLanguages = new List<string>();

        foreach (string language in _programmingLanguages)
        {
            string pattern = $@"\b{Regex.Escape(language)}\b";
            if (Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase))
            {
                foundLanguages.Add(language);
            }
        }

        return foundLanguages;
    }
}





.TestClass

using NUnit.Framework;
using System.Collections.Generic;

namespace ProgrammingLanguageExtractorTests
{
    [TestFixture]
    public class ProgrammingLanguageExtractorTests
    {
        private ProgrammingLanguageExtractor _languageExtractor;

        [SetUp]
        public void Setup()
        {
            _languageExtractor = new ProgrammingLanguageExtractor();
        }

        [Test]
        public void ExtractLanguages_ValidText_ReturnsProgrammingLanguages()
        {
            string text = "I love Java, Python, and JavaScript, but I haven't tried Go yet.";
            List<string> result = _languageExtractor.ExtractLanguages(text);

            List<string> expected = new List<string> { "Java", "Python", "JavaScript", "Go" };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ExtractLanguages_NoProgrammingLanguages_ReturnsEmptyList()
        {
            string text = "I love painting and playing chess.";
            List<string> result = _languageExtractor.ExtractLanguages(text);

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void ExtractLanguages_MixedCaseLanguages_ReturnsCorrectLanguages()
        {
            string text = "My favorites are PYTHON, jAvA, and rubY.";
            List<string> result = _languageExtractor.ExtractLanguages(text);

            List<string> expected = new List<string> { "Python", "Java", "Ruby" };
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ExtractLanguages_PartialWordMatch_DoesNotExtract()
        {
            string text = "I enjoy Javascripted and Ruster.";
            List<string> result = _languageExtractor.ExtractLanguages(text);

            Assert.AreEqual(0, result.Count); // Should not match "Javascripted" or "Ruster"
        }

        [Test]
        public void ExtractLanguages_NullOrEmpty_ReturnsEmptyList()
        {
            List<string> result1 = _languageExtractor.ExtractLanguages(null);
            List<string> result2 = _languageExtractor.ExtractLanguages("");

            Assert.AreEqual(0, result1.Count);
            Assert.AreEqual(0, result2.Count);
        }
    }
}

