using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Thermometer.Logic.Notifications;

namespace Thermometer.Logic.Tests
{
    [TestClass]
    public class FreezingNotificationTests
    {
        private readonly FreezingNotification freezingNotification;
        private const string notificationName = "freezingNotification";
        private bool notificationRaised;

        public FreezingNotificationTests()
        {
            freezingNotification = new FreezingNotification(notificationName, 10.0m, 0.5m, () => notificationRaised = true);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            Assert.AreEqual(notificationName, freezingNotification.Name);
            Assert.AreEqual(10.0M, freezingNotification.ThresholdTemperature);
            Assert.AreEqual(0.5M, freezingNotification.MinimumReleventFluctuation);
            Assert.AreEqual(false, freezingNotification.IsNotificationOn);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorTestWithNullString()
        {
            var notification =  new FreezingNotification(null, -50, -50, null);
        }

        [TestMethod]
        public void TemperatureRaisedToThresholdValueShouldReturnFalse()
        {
            notificationRaised = false;
            freezingNotification.Check(10.0M);
            Assert.IsFalse(notificationRaised);
        }

        [TestMethod]
        public void TemperatureDropToThresholdValueShouldReturnTrue()
        {
            notificationRaised = false;
            freezingNotification.Check(15.0M);
            freezingNotification.Check(10.0M);
            Assert.IsTrue(notificationRaised);
        }

        [TestMethod]
        public void TemperatureDropBelowThresholdValueShouldReturnTrue()
        {
            notificationRaised = false;
            freezingNotification.Check(15.0M);
            freezingNotification.Check(5.0M);
            Assert.IsTrue(notificationRaised);
        }

        [TestMethod]
        public void TemperatureDropToThresholdValueOnceShouldReturnTrue()
        {
            notificationRaised = false;
            freezingNotification.Check(20.0m);
            Assert.IsFalse(notificationRaised);
            freezingNotification.Check(10.0M);
            Assert.IsTrue(notificationRaised);
            notificationRaised = false;
            freezingNotification.Check(9.0M);
            Assert.IsFalse(notificationRaised);
            notificationRaised = false;
            freezingNotification.Check(0.0M);
            Assert.IsFalse(notificationRaised);
            notificationRaised = false;
            freezingNotification.Check(9.9M);
            Assert.IsFalse(notificationRaised);
            notificationRaised = false;
            freezingNotification.Check(5.0M);
            Assert.IsFalse(notificationRaised);
        }

        [TestMethod]
        public void TemperatureDidNotReachThresholdValueShouldReturnFalse()
        {
            notificationRaised = false;
            freezingNotification.Check(11.0M);
            Assert.IsFalse(notificationRaised);
        }

        [TestMethod]
        public void TemperatureReachedThresholdMutlipleTimeWithInsignificantFluctuationUpShouldReturnOneAlert()
        {
            notificationRaised = false;
            freezingNotification.Check(15m);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(10.0M);
            Assert.IsTrue(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(9.8M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(10.0M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(9.5M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(10.0M);
            Assert.IsFalse(notificationRaised);
        }

        [TestMethod]
        public void TemperatureReachedThresholdMutlipleTimeWithInsignificantFluctuationDownShouldReturnOneAlert()
        {
            notificationRaised = false;
            freezingNotification.Check(20.0M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(10.0M);
            Assert.IsTrue(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(10.2M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(10.0M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(10.5M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(10.0M);
            Assert.IsFalse(notificationRaised);
        }

        [TestMethod]
        public void TemperatureReachedThresholdValueAndFluctuateUpMoreThanFluctuationAllowedShouldReturnOneAlert()
        {
            notificationRaised = false;
            freezingNotification.Check(20.0M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(10.0M);
            Assert.IsTrue(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(9.0M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(10.0M);
            Assert.IsFalse(notificationRaised);
        }

        [TestMethod]
        public void TemperatureReachedThresholdValueAndFluctuateDownMoreThanFluctuationAllowedShouldReturnMultipleAlert()
        {
            notificationRaised = false;
            freezingNotification.Check(20.0M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(10.0M);
            Assert.IsTrue(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(11.0M);
            Assert.IsFalse(notificationRaised);

            notificationRaised = false;
            freezingNotification.Check(10.0M);
            Assert.IsTrue(notificationRaised);
        }
    }
}
