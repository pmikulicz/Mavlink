// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMavlinkEngineFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a component which creates engine for the mavlink protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages;

namespace Mavlink
{
    /// <summary>
    /// Interface of a component which creates engine for the mavlink protocol
    /// </summary>
    internal interface IMavlinkEngineFactory
    {
        /// <summary>
        /// Creates new instance of engine for the mavlink protocol
        /// </summary>
        /// <typeparam name="TMessage">Type of mavlink message</typeparam>
        /// <returns>New instance of engine for the mavlink protocol</returns>
        IMavlinkEngine<TMessage> Create<TMessage>() where TMessage : IMavlinkMessage;
    }
}