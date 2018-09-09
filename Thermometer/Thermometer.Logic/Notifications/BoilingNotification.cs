
using System;
using Thermometer.Logic.Interfaces;

namespace Thermometer.Logic.Notifications
{
    /// <summary>
    /// BoilingNotification class
    /// </summary>
    public class BoilingNotification : NotificationBase, INotification
    {
        public BoilingNotification(string name, 
            decimal threshold, 
            decimal fluctuation,
            Action action)
            : base(name, threshold, fluctuation, action) { }


        /// <summary>
        /// Test the current temparature against boiling threshold
        /// </summary>
        /// <param name="tempererature"></param>
        public override void Check(decimal temperature)
        {
            var fluctuation = temperature - previousTemperature;
            previousTemperature = temperature;

            if (temperature < ThresholdTemperature)
            {
                if (!IsNotificationOn)
                {
                    return;
                }
                if (ThresholdTemperature - MinimumReleventFluctuation > temperature)
                {
                    IsNotificationOn = false;
                }
                return;
            }

            if (IsNotificationOn || fluctuation <= 0)
            {
                return;
            }
            IsNotificationOn = true;
            Notify();
        }
    }
}
