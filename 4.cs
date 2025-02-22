using System;

public class MathOperations
{
    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new ArithmeticException("Cannot divide by zero.");
        return a / b;
    }
}





.Nunit test Cases 

using NUnit.Framework;
using System;

namespace MathOperationsTests
{
    [TestFixture]
    public class MathOperationsTests
    {
        private MathOperations _mathOperations;

        [SetUp]
        public void Setup()
        {
            _mathOperations = new MathOperations();
        }

        [Test]
        public void Divide_ByNonZero_ReturnsQuotient()
        {
            int result = _mathOperations.Divide(10, 2);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Divide_ByZero_ThrowsArithmeticException()
        {
            Assert.Throws<ArithmeticException>(() => _mathOperations.Divide(10, 0));
        }
    }
}



