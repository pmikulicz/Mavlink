// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageMetadataConfigurator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//  Interface of component which allows to configure mavlink message metadata
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    /// Interface of component which allows to configure mavlink message metadata
    /// </summary>
    public interface IMessageMetadataConfigurator
    {
        /// <summary>
        /// Sets original mavlink name of a message
        /// </summary>
        /// <param name="name">Name to be set</param>
        /// <returns>Instance of message metadata configurator for fluet api</returns>
        IMessageMetadataConfigurator SetName(string name);

        /// <summary>
        /// Sets id of a message
        /// </summary>
        /// <param name="id">Id to be set</param>
        /// <returns>Instance of message metadata configurator for fluet api</returns>
        IMessageMetadataConfigurator SetId(int id);
    }
}