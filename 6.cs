public class NumberUtils
{
    // Method to check if a number is even
    public bool IsEven(int number)
    {
        return number % 2 == 0;
    }
}





.Nunit Test Cases 
using NUnit.Framework;

namespace NumberUtilsTests
{
    [TestFixture]
    public class NumberUtilsTests
    {
        private NumberUtils _numberUtils;

        [SetUp]
        public void Setup()
        {
            _numberUtils = new NumberUtils();
        }

        // Using NUnit's [TestCase] to test multiple values
        [TestCase(2, true)]
        [TestCase(4, true)]
        [TestCase(6, true)]
        [TestCase(7, false)]
        [TestCase(9, false)]
        public void IsEven_TestMultipleValues(int number, bool expected)
        {
            bool result = _numberUtils.IsEven(number);
            Assert.AreEqual(expected, result);
        }
    }
}




