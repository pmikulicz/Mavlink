// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkEngine.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Engine fo the mavlink protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages;
using Mavlink.Packets;
using System;
using System.Collections.Generic;

namespace Mavlink
{
    /// <summary>
    /// Engine fo the mavlink protocol
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    internal sealed class MavlinkEngine<TMessage> : IMavlinkEngine<TMessage> where TMessage : IMavlinkMessage
    {
        private readonly Dictionary<Func<TMessage, bool>, MessageNotifier<TMessage>> _messageNotifiers;

        private readonly IPacketHandler _packetHandler;
        private readonly IMessageFactory<TMessage> _messageFactory;

        public MavlinkEngine(IPacketHandler packetHandler, IMessageFactory<TMessage> messageFactory)
        {
            _packetHandler = packetHandler ?? throw new ArgumentNullException(nameof(packetHandler));
            _messageFactory = messageFactory ?? throw new ArgumentNullException(nameof(messageFactory));
            _messageNotifiers = new Dictionary<Func<TMessage, bool>, MessageNotifier<TMessage>>(10);
        }

        /// <inheritdoc />
        public Packet CreatePacket(TMessage message, byte systemId, byte componentId, byte sequenceNumber = 1)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            byte[] packetPayload = _messageFactory.CreateBytes(message);
            return _packetHandler.HandlePacket(systemId, componentId, sequenceNumber, message.Id.Value, packetPayload);
        }

        /// <inheritdoc />
        public void ProcessBytes(byte[] packetBytes)
        {
            IEnumerable<Packet> packets = _packetHandler.HandlePackets(packetBytes);

            foreach (Packet packet in packets)
            {
                TMessage message = _messageFactory.CreateMessage(packet.Payload, packet.MessageId);
                NotifyForMessage(message, packet.ComponentId, packet.SystemId);
            }
        }

        /// <inheritdoc />
        public IMessageNotifier<TMessage> RegisterMessageSubscriber(Func<TMessage, bool> condition)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));

            if (_messageNotifiers.ContainsKey(condition))
                return _messageNotifiers[condition];

            MessageNotifier<TMessage> messageNotifier = new MessageNotifier<TMessage>();
            _messageNotifiers.Add(condition, messageNotifier);

            return messageNotifier;
        }

        private void NotifyForMessage(TMessage message, int componentId, int systemId)
        {
            foreach (var messageNotifier in _messageNotifiers)
            {
                if (messageNotifier.Key(message))
                    messageNotifier.Value.OnMessageReceived(new MessageReceivedEventArgs<TMessage>(message, componentId, systemId));
            }
        }
    }
}