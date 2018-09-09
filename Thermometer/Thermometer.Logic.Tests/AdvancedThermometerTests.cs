using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thermometer.Logic.Interfaces;

namespace Thermometer.Logic.Tests
{
    [TestClass]
    public class AdvancedThermometerTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var unit = Unit.Celsius;
            var freezingNotificationMock = NSubstitute.Substitute.For<INotification>();
            var boilingNotificationMock = NSubstitute.Substitute.For<INotification>();

            var thermometer = new AdvancedThermometer(unit,
                freezingNotificationMock, boilingNotificationMock);

            Assert.AreEqual(unit, thermometer.ThermometerUnit);
            Assert.AreEqual(unit, thermometer.Temperature.Unit);
            Assert.AreEqual(0.0m, thermometer.Temperature.Value);
        }

        [TestMethod]
        public void HandleTemperatureChangedWithSameUnit()
        {
            var unit = Unit.Celsius;
            var freezingNotificationMock = NSubstitute.Substitute.For<INotification>();
            var boilingNotificationMock = NSubstitute.Substitute.For<INotification>();

            var thermometer = new AdvancedThermometer(unit,
                freezingNotificationMock, boilingNotificationMock);

            thermometer.UpdateTemperature(new Temperature(10.5m, unit));

            Assert.AreEqual(10.5m, thermometer.Temperature.Value);
            Assert.AreEqual(unit, thermometer.Temperature.Unit);

            thermometer.UpdateTemperature(new Temperature(5.5m, unit));
            Assert.AreEqual(5.5m, thermometer.Temperature.Value);
            Assert.AreEqual(unit, thermometer.Temperature.Unit);
        }


        [TestMethod]
        public void HandleTemperatureChangedWithDifferentUnit()
        {
            var unit = Unit.Fahrenheit;
            var freezingNotificationMock = NSubstitute.Substitute.For<INotification>();
            var boilingNotificationMock = NSubstitute.Substitute.For<INotification>();

            var thermometer = new AdvancedThermometer(Unit.Celsius,
                freezingNotificationMock, boilingNotificationMock);


            thermometer.UpdateTemperature(new Temperature(32.0m, unit));
            Assert.AreEqual(0.0m, thermometer.Temperature.Value);
            Assert.AreEqual(Unit.Celsius, thermometer.Temperature.Unit);
        }
    }
}
