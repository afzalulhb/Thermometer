using System;
using Thermometer.Logic.Interfaces;

namespace Thermometer.Logic.Notifications
{
    /// <summary>
    /// NotificationBase class
    /// </summary>
    public abstract class NotificationBase: INotification
    {
        /// <summary>
        /// Name of the notification
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Threshold Temperature
        /// </summary>
        public decimal ThresholdTemperature { get; }

        /// <summary>
        /// MinimumReleventFluctuation
        /// </summary>
        public decimal MinimumReleventFluctuation { get; }

        /// <summary>
        /// If the notification is on or off
        /// </summary>
        public bool IsNotificationOn { get; protected set; }

        protected decimal previousTemperature;

        protected Action Notify;

        protected NotificationBase(string name, 
            decimal threshold, 
            decimal fluctuation,
            Action notify)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            ThresholdTemperature = threshold;
            MinimumReleventFluctuation = fluctuation;
            IsNotificationOn = false;
            Notify = notify;
        }

        /// <summary>
        /// Temperature change event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public  void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            Check(e.Temperature.Value);
        }

        /// <summary>
        /// Test the current temparature against freezing and boiling threshold
        /// </summary>
        /// <param name="tempererature"></param>
        public virtual void Check(decimal tempererature)
        {
        }
    }
}
