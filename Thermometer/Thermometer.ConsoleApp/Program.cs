using System;
using System.Collections.Generic;
using System.Threading;
using Thermometer.Logic;
using Thermometer.Logic.Interfaces;
using Thermometer.Logic.Notifications;

namespace Thermometer.ConsoleApp
{

    class Program
    {

        static void Main(string[] args)
        {
            IThermometer thermometer;
            var freezingNotification = new FreezingNotification("Freezing notification", 0.0m, 0.5m, () => Console.WriteLine("----Freezing!!!------"));
            var boilingNotification = new BoilingNotification("Boiling notification", 100, 0.5m, () => Console.WriteLine("----Boiling Alert!!!----"));

            thermometer = new AdvancedThermometer(Unit.Celsius, freezingNotification, boilingNotification);


            for (var i = 0; i < 2; i++)
            {
                foreach (var temperature in GetTemperatures())
                {
                    Console.WriteLine($"new temp received {temperature}");
                    try
                    {
                        thermometer.UpdateTemperature(temperature);
                        Console.WriteLine($" -- >temp in Thermometer {thermometer.Temperature}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine(ex.Message);
                    }

                    Thread.Sleep(1000);
                }
            }
        }

        private static List<ITemperature> GetTemperatures()
        {

            return new List<ITemperature>
            {
                new Temperature(15.0m, Unit.Kelvin),
                new Temperature(12.0m, Unit.Celsius),
                new Temperature(32.0m, Unit.Fahrenheit),
                new Temperature(0.1m, Unit.Celsius),
                new Temperature(0.0m,Unit.Celsius),
                new Temperature(0.0m,Unit.Celsius),
                new Temperature(0.0m,Unit.Celsius),
                new Temperature(0.0m,Unit.Celsius),
                new Temperature(23.0m,Unit.Celsius),
                new Temperature(27.9m,Unit.Celsius),
                new Temperature(28.0m,Unit.Celsius),
                new Temperature(28.3m,Unit.Celsius),
                new Temperature(28.0m,Unit.Celsius),
                new Temperature(35.0m,Unit.Celsius),
                new Temperature(28.0m,Unit.Celsius),
                new Temperature(70.0m,Unit.Celsius),
                new Temperature(100.0m,Unit.Celsius),
                new Temperature(110.0m,Unit.Celsius),
                new Temperature(10.0m,Unit.Celsius),
                new Temperature(35.0m,Unit.Kelvin),
                new Temperature(28.0m,Unit.Kelvin),
                new Temperature(70.0m,Unit.Kelvin),
                new Temperature(100.0m,Unit.Fahrenheit),
                new Temperature(110.0m,Unit.Fahrenheit)

            };
        }
    }
}
