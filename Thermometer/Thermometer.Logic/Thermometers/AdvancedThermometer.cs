using System;
using System.Collections.Generic;
using Thermometer.Logic.Notifications;
using Thermometer.Logic.Interfaces;

namespace Thermometer.Logic
{
    /// <summary>
    /// AdvancedThermometer class
    /// </summary>
    public class AdvancedThermometer: BasicThermometer, IAdvancedThermometer
    {
        public INotification FreezingNotification { get; set; }
        public INotification BoilingNotification { get; set; }

        private  event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

        public AdvancedThermometer(Unit unit, 
            INotification freezingNotification, 
            INotification boilingNotification) :base(unit)
        {
                TemperatureChanged += freezingNotification.HandleTemperatureChanged;
                TemperatureChanged += boilingNotification.HandleTemperatureChanged;
        }

        /// <summary>
        /// Updates the current temparature
        /// </summary>
        /// <param name="temperature"></param>
        public override void UpdateTemperature(ITemperature temperature)
        {

            var temp = temperature.Unit != ThermometerUnit
                    ? temperature.Convert(ThermometerUnit)
                    : temperature;


            base.UpdateTemperature(temp);
            TemperatureChanged?.Invoke(null, new TemperatureChangedEventArgs(Temperature));
        }
    }
}