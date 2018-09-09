namespace Thermometer.Logic.Interfaces
{
    /// <summary>
    /// IThermometer interface
    /// </summary>
    public interface IThermometer
    {
        /// <summary>
        /// Temparature unit
        /// </summary>
        Unit ThermometerUnit { get; set; }
        /// <summary>
        /// Temparature
        /// </summary>
        ITemperature Temperature { get; }
        /// <summary>
        /// Update current temparature
        /// </summary>
        /// <param name="temperature"></param>
        void UpdateTemperature(ITemperature temperature);
    }
}