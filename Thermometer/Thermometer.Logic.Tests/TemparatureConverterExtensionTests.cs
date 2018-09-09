using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thermometer.Logic.Interfaces;

namespace Thermometer.Logic.Tests
{
    [TestClass]
    public class TemparatureConverterExtensionTests
    {
        [TestMethod]
        public void ConverterTestSameUnit()
        {
            var unitCelsius = Unit.Celsius;
            var unitFahrenheit = Unit.Fahrenheit;
            var unitKelvin = Unit.Kelvin;
            var tempCelcius = new Temperature(10.0m, Unit.Celsius);
            var tempFarenheit = new Temperature(20.0m, Unit.Fahrenheit);
            var tempKelvin = new Temperature(30.0m, Unit.Kelvin);

            var celsiusResult = tempCelcius.Convert(unitCelsius);
            var fahrenheitResult = tempFarenheit.Convert(unitFahrenheit);
            var kelvinResult = tempKelvin.Convert(unitKelvin);

            Assert.AreEqual(10.0m, celsiusResult.Value);
            Assert.AreEqual(unitCelsius, celsiusResult.Unit);
            Assert.AreEqual(20.0m, fahrenheitResult.Value);
            Assert.AreEqual(unitFahrenheit, fahrenheitResult.Unit);
            Assert.AreEqual(30.0m, kelvinResult.Value);
            Assert.AreEqual(unitKelvin, kelvinResult.Unit);
        }

        [TestMethod]
        public void ConverterTestToCelsius()
        {
            var unitCelsius = Unit.Celsius;
            var tempFahrenheit = new Temperature(32.0m, Unit.Fahrenheit);
            var tempKelvin = new Temperature(0.0m, Unit.Kelvin);

            var tempFromFahrenheit = tempFahrenheit.Convert(unitCelsius);
            var tempFromKelvin = tempKelvin.Convert(unitCelsius);

            Assert.AreEqual(0.0m, tempFromFahrenheit.Value);
            Assert.AreEqual(unitCelsius, tempFromFahrenheit.Unit);
            Assert.AreEqual(-273.15m, tempFromKelvin.Value);
            Assert.AreEqual(unitCelsius, tempFromKelvin.Unit);
        }

        [TestMethod]
        public void ConverterTestToFahrenheit()
        {
            var unitFahrenheit = Unit.Fahrenheit;
            var tempCelsius = new Temperature(0.0m, Unit.Celsius);
            var tempKelvin = new Temperature(0.0m, Unit.Kelvin);

            var tempFromCelsius = tempCelsius.Convert(unitFahrenheit);
            var tempFromKelvin = tempKelvin.Convert(unitFahrenheit);

            Assert.AreEqual(32.0m, tempFromCelsius.Value);
            Assert.AreEqual(unitFahrenheit, tempFromCelsius.Unit);
            Assert.AreEqual(-459.67m, tempFromKelvin.Value);
            Assert.AreEqual(unitFahrenheit, tempFromKelvin.Unit);
        }
    }
}
