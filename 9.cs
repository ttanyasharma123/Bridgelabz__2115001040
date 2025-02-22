using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class BadWordFilter
{
    private HashSet<string> _badWords;

    public BadWordFilter(List<string> badWords)
    {
        _badWords = new HashSet<string>(badWords, StringComparer.OrdinalIgnoreCase);
    }

    // Censors bad words in the given sentence
    public string CensorBadWords(string sentence)
    {
        if (string.IsNullOrWhiteSpace(sentence))
            return sentence;

        // Replace each bad word with "****"
        foreach (string badWord in _badWords)
        {
            string pattern = $@"\b{Regex.Escape(badWord)}\b";
            sentence = Regex.Replace(sentence, pattern, "****", RegexOptions.IgnoreCase);
        }

        return sentence;
    }
}





.TestCase


using NUnit.Framework;
using System.Collections.Generic;

namespace BadWordFilterTests
{
    [TestFixture]
    public class BadWordFilterTests
    {
        private BadWordFilter _badWordFilter;

        [SetUp]
        public void Setup()
        {
            List<string> badWords = new List<string> { "damn", "stupid" };
            _badWordFilter = new BadWordFilter(badWords);
        }

        [Test]
        public void CensorBadWords_SentenceWithBadWords_CensorsThem()
        {
            string input = "This is a damn bad example with some stupid words.";
            string result = _badWordFilter.CensorBadWords(input);
            Assert.AreEqual("This is a **** bad example with some **** words.", result);
        }

        [Test]
        public void CensorBadWords_NoBadWords_ReturnsSameSentence()
        {
            string input = "This is a clean sentence.";
            string result = _badWordFilter.CensorBadWords(input);
            Assert.AreEqual("This is a clean sentence.", result);
        }

        [Test]
        public void CensorBadWords_BadWordsWithDifferentCases_CensorsThem()
        {
            string input = "This is a DAMN stupid case.";
            string result = _badWordFilter.CensorBadWords(input);
            Assert.AreEqual("This is a **** **** case.", result);
        }

        [Test]
        public void CensorBadWords_PartialWordMatch_DoesNotCensor()
        {
            string input = "This is an undamned situation, not stupidly bad.";
            string result = _badWordFilter.CensorBadWords(input);
            Assert.AreEqual("This is an undamned situation, not stupidly bad.", result);
        }

        [Test]
        public void CensorBadWords_NullOrEmpty_ReturnsSameString()
        {
            Assert.AreEqual("", _badWordFilter.CensorBadWords(""));
            Assert.AreEqual(null, _badWordFilter.CensorBadWords(null));
        }
    }
}







