using System;

public class Calculator
{
    public int Add(int a, int b) => a + b;

    public int Subtract(int a, int b) => a - b;

    public int Multiply(int a, int b) => a * b;

    public double Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        return (double)a / b;
    }
}


.Nunit Test Cases

using NUnit.Framework;
using System;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Add_TwoNumbers_ReturnsSum()
    {
        Assert.AreEqual(5, _calculator.Add(2, 3));
    }

    [Test]
    public void Subtract_TwoNumbers_ReturnsDifference()
    {
        Assert.AreEqual(2, _calculator.Subtract(5, 3));
    }

    [Test]
    public void Multiply_TwoNumbers_ReturnsProduct()
    {
        Assert.AreEqual(15, _calculator.Multiply(5, 3));
    }

    [Test]
    public void Divide_TwoNumbers_ReturnsQuotient()
    {
        Assert.AreEqual(2.5, _calculator.Divide(5, 2));
    }

    [Test]
    public void Divide_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(5, 0));
    }
}



