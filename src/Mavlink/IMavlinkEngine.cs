// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMavlinkEngine.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a component which is the engine fo the mavlink protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using Mavlink.Messages;
using Mavlink.Packets;

namespace Mavlink
{
    /// <summary>
    /// Interface of a component which is the engine fo the mavlink protocol
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    internal interface IMavlinkEngine<TMessage> where TMessage : IMavlinkMessage
    {
        /// <summary>
        /// Creates mavlink packet
        /// </summary>
        /// <param name="message">Mavlink message which will be includeud in the packet</param>
        /// <param name="systemId">Id of the destination system</param>
        /// <param name="componentId">Id of the destination component</param>
        /// <param name="sequenceNumber">Sequence number of the packet</param>
        /// <returns>Mavlink packet</returns>
        Packet CreatePacket(TMessage message, byte systemId, byte componentId, byte sequenceNumber = 1);

        /// <summary>
        /// Register subsriber for mavlink message which fulfills given condition
        /// </summary>
        /// <param name="condition">Condition to be fulfilled that subsriber was informed</param>
        /// <returns>Instance of message notifier which will notify about new incoming message</returns>
        IMessageNotifier<TMessage> RegisterMessageSubscriber(Func<TMessage, bool> condition);

        /// <summary>
        /// Process incoming packet bytes
        /// </summary>
        /// <param name="packetBytes"></param>
        void ProcessBytes(byte[] packetBytes);
    }
}