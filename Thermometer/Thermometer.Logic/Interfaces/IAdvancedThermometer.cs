using System.Collections.Generic;

namespace Thermometer.Logic.Interfaces
{
    /// <summary>
    /// Interface for Advanced thermometer
    /// </summary>
    public interface IAdvancedThermometer
    {
        /// <summary>
        /// Gets or sets the FreezingNotification
        /// </summary>
        INotification FreezingNotification { get; set; }
        /// <summary>
        /// Gets or sets the BoilingNotification
        /// </summary>
        INotification BoilingNotification { get; set; }
    }
}
