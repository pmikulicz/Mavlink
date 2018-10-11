// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkEngine.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Engine of the mavlink protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.EventArgs;
using Mavlink.Messages;
using Mavlink.Packets;
using System;
using System.Collections.Generic;

namespace Mavlink
{
    /// <summary>
    /// Engine of the mavlink protocol
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    internal sealed class MavlinkEngine<TMessage> : IMavlinkEngine<TMessage> where TMessage : IMavlinkMessage
    {
        private readonly Dictionary<Func<TMessage, bool>, MessageNotifier<TMessage>> _messageNotifiers;

        private readonly IMessageProcessor<TMessage> _messageProcessor;
        private readonly IPacketBuilderDirector _packetBuilderDirector;

        public MavlinkEngine(IMessageProcessor<TMessage> messageProcessor, IPacketBuilderDirector packetBuilderDirector)
        {
            _packetBuilderDirector = packetBuilderDirector ?? throw new ArgumentNullException(nameof(packetBuilderDirector));
            _messageProcessor = messageProcessor ?? throw new ArgumentNullException(nameof(messageProcessor));
            _messageNotifiers = new Dictionary<Func<TMessage, bool>, MessageNotifier<TMessage>>(10);
        }

        /// <inheritdoc />
        public Packet CreatePacket(TMessage message, byte systemId, byte componentId, byte sequenceNumber = 1)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            byte[] packetPayload = _messageProcessor.CreateBytes(message);

            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void ProcessBytes(byte[] packetBytes)
        {
            foreach (var packetByte in packetBytes)
            {
                bool nextByte = _packetBuilderDirector.AddByte(packetByte);

                if (nextByte)
                    continue;

                IPacketBuilder packetBuilder = _packetBuilderDirector.Construct();
                packetBuilder.Build(new BuildEvents(p =>
                {
                    PacketReceived?.Invoke(this, new PacketReceivedEventArgs(p));
                    TMessage message = _messageProcessor.CreateMessage(p.Payload, p.MessageId);
                    NotifyForMessage(message, p.ComponentId, p.SystemId);
                }, bytes =>
                {
                    InvalidPacketReceived?.Invoke(this, new InvalidPacketReceivedEventArgs(bytes));
                }));
            }
        }

        /// <inheritdoc />
        public event EventHandler<PacketReceivedEventArgs> PacketReceived;

        /// <inheritdoc />
        public event EventHandler<InvalidPacketReceivedEventArgs> InvalidPacketReceived;

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