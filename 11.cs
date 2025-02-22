public class TemperatureConverter
{
    // Converts Celsius to Fahrenheit
    public double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    // Converts Fahrenheit to Celsius
    public double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }
}




.Net Unit Test


using NUnit.Framework;

namespace TemperatureConverterTests
{
    [TestFixture]
    public class TemperatureConverterTests
    {
        private TemperatureConverter _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new TemperatureConverter();
        }

        [Test]
        public void CelsiusToFahrenheit_ZeroCelsius_Returns32Fahrenheit()
        {
            double result = _converter.CelsiusToFahrenheit(0);
            Assert.AreEqual(32, result, 0.001); // Allow minor precision errors
        }

        [Test]
        public void CelsiusToFahrenheit_HundredCelsius_Returns212Fahrenheit()
        {
            double result = _converter.CelsiusToFahrenheit(100);
            Assert.AreEqual(212, result, 0.001);
        }

        [Test]
        public void FahrenheitToCelsius_ZeroFahrenheit_ReturnsNegative17Point78Celsius()
        {
            double result = _converter.FahrenheitToCelsius(0);
            Assert.AreEqual(-17.7778, result, 0.001);
        }

        [Test]
        public void FahrenheitToCelsius_212Fahrenheit_Returns100Celsius()
        {
            double result = _converter.FahrenheitToCelsius(212);
            Assert.AreEqual(100, result, 0.001);
        }

        [Test]
        public void CelsiusToFahrenheit_Negative40Celsius_ReturnsNegative40Fahrenheit()
        {
            double result = _converter.CelsiusToFahrenheit(-40);
            Assert.AreEqual(-40, result, 0.001);
        }

        [Test]
        public void FahrenheitToCelsius_Negative40Fahrenheit_ReturnsNegative40Celsius()
        {
            double result = _converter.FahrenheitToCelsius(-40);
            Assert.AreEqual(-40, result, 0.001);
        }
    }
}



