namespace Thermometer.Logic.Interfaces
{
    /// <summary>
    /// ITemperature interface
    /// </summary>
    public interface ITemperature
    {
        /// <summary>
        /// Value of the temparature
        /// </summary>
        decimal Value {get; set;}
        /// <summary>
        /// Unit of the temparature
        /// </summary>
        Unit Unit {get;}
    }
}