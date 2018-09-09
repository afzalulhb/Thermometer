namespace Thermometer.Logic.Interfaces
{
    /// <summary>
    /// INotification interface
    /// </summary>
    public interface INotification
    {
        /// <summary>
        /// Name of the notification
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Check the temparature
        /// </summary>
        /// <param name="tempererature"></param>
        void Check(decimal tempererature);
        /// <summary>
        /// HandleTemperatureChanged event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandleTemperatureChanged(object sender, TemperatureChangedEventArgs e);
    }
}