using System;
using System.Collections.Generic;
using System.Text;
using Thermometer.Logic.Interfaces;

namespace Thermometer.Logic
{
    public static class TemparatureConverterExtensions
    {
        /// <summary>
        /// Converts the temparature to the unit specified
        /// </summary>
        /// <param name="temperature"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static ITemperature Convert(this ITemperature temperature, Unit unit)
        {
            if (temperature.Unit == unit)
            {
                return temperature;
            }

            if (temperature.Unit == Unit.Kelvin)
            {
                return FromKelvin(temperature, unit);
            }
            if (unit == Unit.Kelvin)
            {
                return ToKelvin(temperature, unit);
            }

            var tempratureInKelvin = ToKelvin(temperature, temperature.Unit);
            return FromKelvin(tempratureInKelvin, unit);
        }

        /// <summary>
        /// Converts the temparature from kelvin to specified unit
        /// </summary>
        /// <param name="temperature"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        private static ITemperature FromKelvin(ITemperature temperature, Unit unit)
        {
            if (unit == Unit.Fahrenheit)
            {
                return new Temperature(temperature.Value * 9 / 5 - 459.67m, Unit.Fahrenheit);
            }
            if (unit == Unit.Celsius)
            {
                return new Temperature(temperature.Value - 273.15m, Unit.Celsius);
            }

            throw new Exception("There is no convertion defined.");
        }

        /// <summary>
        /// Converts the temparature to kelvin
        /// </summary>
        /// <param name="temperature"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        private static ITemperature ToKelvin(ITemperature temperature, Unit unit)
        {
            if (unit == Unit.Fahrenheit)
            {
                return new Temperature((temperature.Value + 459.67m) * 5 / 9, Unit.Fahrenheit);
            }
            if (unit == Unit.Celsius)
            {
                return new Temperature(temperature.Value + 273.15m, Unit.Celsius);
            }
            throw new Exception("There is no convertion defined.");
        }
    }
}
