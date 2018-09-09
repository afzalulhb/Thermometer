using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Thermometer.Logic.Tests
{
    [TestClass]
    public class BasicThermometerTests
    {
       [TestMethod]
        public void ConstructorTest()
        {
            var unit = Unit.Celsius;
            var thermometer = new BasicThermometer(unit);

            Assert.AreEqual(unit, thermometer.ThermometerUnit);
            Assert.AreEqual(unit,thermometer.Temperature.Unit);
            Assert.AreEqual(0.0m, thermometer.Temperature.Value);
        }

        [TestMethod]
        public void HandleTemperatureChangedWithSameUnit()
        {
            var unit = Unit.Celsius;
            var thermometer = new BasicThermometer(unit);

            thermometer.UpdateTemperature(new Temperature(10.5m,unit));

            Assert.AreEqual(10.5m, thermometer.Temperature.Value);
            Assert.AreEqual(unit, thermometer.Temperature.Unit);

            thermometer.UpdateTemperature(new Temperature(5.5m, unit));
            Assert.AreEqual(5.5m, thermometer.Temperature.Value);
            Assert.AreEqual(unit, thermometer.Temperature.Unit);
        }
        

    }
}
