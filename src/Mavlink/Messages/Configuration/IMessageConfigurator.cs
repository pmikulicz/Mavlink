// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageConfigurator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//  Component which allows to configure message details
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    /// Component which allows to configure message details
    /// </summary>
    public interface IMessageConfigurator
    {
        /// <summary>
        /// Sets original mavlink name of a message
        /// </summary>
        /// <param name="name">Name to be set</param>
        /// <returns>Instance of message configurator for fluet api</returns>
        IMessageConfigurator SetName(string name);

        /// <summary>
        /// Sets id of a message
        /// </summary>
        /// <param name="id">Id to be set</param>
        /// <returns>Instance of message configurator for fluet api</returns>
        IMessageConfigurator SetId(int id);
    }
}