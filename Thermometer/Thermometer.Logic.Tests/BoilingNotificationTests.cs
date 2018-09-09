using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Thermometer.Logic.Notifications;

namespace Thermometer.Logic.Tests
{
    [TestClass]
    public class BoilingNotificationTests
    {
        private readonly BoilingNotification boilingNotification;
        private const string notificationName = "BoilingNotification";
        private bool notificationRaised;

        public BoilingNotificationTests()
        {
            boilingNotification = new BoilingNotification(notificationName, 10.0m, 0.5m, () => { notificationRaised = true; });
        }

        [TestMethod]
        public void ConstructorTest()
        {
            Assert.AreEqual(notificationName, boilingNotification.Name);
            Assert.AreEqual(10.0M, boilingNotification.ThresholdTemperature);
            Assert.AreEqual(0.5M, boilingNotification.MinimumReleventFluctuation);
            Assert.AreEqual(false, boilingNotification.IsNotificationOn);
        }

        [TestMethod]
        public void TemperatureRaisedToThresholdValueShouldReturnTrue()
        {
            notificationRaised = false;
            boilingNotification.Check(10.0M);
            Assert.IsTrue(notificationRaised);
        }

        [TestMethod]
        public void TemperatureDropsToThresholdValueShouldReturnFalse()
        {
            boilingNotification.Check(11.0M);
            notificationRaised = false;
            boilingNotification.Check(10.0M);
            Assert.IsFalse(notificationRaised);
        }

        [TestMethod]
        public void TemperaturemWentAboveThresholdValueShouldReturnTrue()
        {
            notificationRaised = false;
            boilingNotification.Check(11.0M);
            Assert.IsTrue(notificationRaised);
        }

        [TestMethod]
        public void TemperatureReachedThresholdValueMutlipleTimesWithInsignificantDropFluctuationShouldReturnOneAlert()
        {
            notificationRaised = false;
            boilingNotification.Check(10.0M);
            Assert.IsTrue(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(9.8M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(10.0M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(9.5M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(10.0M);
            Assert.IsFalse(notificationRaised);
        }

        [TestMethod]
        public void TemperatureReachedThresholdValueMutlipleTimesWithInsignificantRaiseFluctuationShouldReturnOneAlert()
        {
            notificationRaised = false;
            boilingNotification.Check(10.0M);
            Assert.IsTrue(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(10.2M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(10.0M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(10.5M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(10.0M);
            Assert.IsFalse(notificationRaised);
        }

        [TestMethod]
        public void TemperatureReachesThresholdValueMutlipleTimesWithSignificantDropFluctuationShouldReturnMultipleAlert()
        {
            notificationRaised = false;
            boilingNotification.Check(10.0M);
            Assert.IsTrue(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(9.0M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(10.0M);
            Assert.IsTrue(notificationRaised);
        }

        [TestMethod]
        public void TemperatureReachesThresholdValueMutlipleTimesWithSignificantRaiseFluctuationShouldReturnOneAlert()
        {
            notificationRaised = false;
            boilingNotification.Check(10.0M);
            Assert.IsTrue(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(11.0M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(10.0M);
            Assert.IsFalse(notificationRaised);
        }

        /// <summary>
        /// In this test I assume that if the temperature reaches the threshold value and continues to rise and then the temperature drops
        /// directly below the threshold value and returns to the threshold value it should return true only if the temperature 
        /// exceded the minimum relevent fluctuation. 
        /// </summary>
        [TestMethod]
        public void TemperatureReachesThresholdValueAndContinuesToRiseAndDropDirectlyUnderThresholdValue()
        {
            notificationRaised = false;
            boilingNotification.Check(10.0M);
            Assert.IsTrue(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(100.0M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(9.8M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(10M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(100.0M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(9M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            boilingNotification.Check(10M);
            Assert.IsTrue(notificationRaised);
        }
    }
}
