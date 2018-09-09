using System;
using Thermometer.Logic.Interfaces;

namespace Thermometer.Logic
{

    public class TemperatureChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Temparature
        /// </summary>
        public ITemperature Temperature { get; }

        /// <summary>
        /// TemperatureChangedEventArgs
        /// </summary>
        /// <param name="temperature"></param>
        public TemperatureChangedEventArgs(ITemperature temperature)
        {
            Temperature = temperature;
        }
    }
}
