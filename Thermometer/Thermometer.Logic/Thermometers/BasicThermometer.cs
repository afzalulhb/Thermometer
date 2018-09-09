using System;
using Thermometer.Logic.Interfaces;

namespace Thermometer.Logic
{ 
    /// <summary>
    /// BasicThermometer class
    /// </summary>
    public class BasicThermometer : IThermometer
    {
        public Unit ThermometerUnit { get; set; }
        public ITemperature Temperature { get; private set; }


        public BasicThermometer(Unit unit)
        {
            ThermometerUnit = unit;
            Temperature = new Temperature(0.0m,unit);
        }

        /// <summary>
        /// Updates current temparature
        /// </summary>
        /// <param name="temperature"></param>
        public virtual void UpdateTemperature(ITemperature temperature)
        {
            Temperature = temperature;
        }
    }

}
