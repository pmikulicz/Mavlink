// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMavlinkConfigurationProvider.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a component which creates container for mavlink message metadata collection for appropriate type of mavlink message
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    /// Interface of a component which creates container for mavlink message metadata collection for appropriate type of mavlink message
    /// </summary>
    internal interface IMessageMetadataContainerFactory
    {
        /// <summary>
        /// Creates container for mavlink message metadata collection for appropriate type of mavlink message
        /// </summary>
        /// <typeparam name="TMessage">Type of mavlink message</typeparam>
        /// <returns>Instance of a container for mavlink message metadata collection</returns>
        IMessageMetadataContainer Create<TMessage>() where TMessage : MavlinkMessage;
    }
}