// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkCommunicator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for communication via mavlink protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages;
using Mavlink.Messages.Definitions;
using Mavlink.Packets;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mavlink.Connection;

namespace Mavlink
{
    /// <summary>
    /// Component which is responsible for communication via mavlink protocol
    /// </summary>
    internal sealed class MavlinkCommunicator<TMessage> : IMavlinkCommunicator<TMessage> where TMessage : ICommonMessage
    {
        private readonly IPacketHandler _packetHandler;
        private readonly IMessageFactory<TMessage> _messageFactory;
        private readonly Dictionary<Func<TMessage, bool>, MessageNotifier<TMessage>> _messageNotifiers;
        private readonly IConnectionService _connectionService;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly object _syncRoot = new object();
        private bool _disposed;

        internal MavlinkCommunicator(IConnectionService connectionService, IPacketHandler packetHandler, IMessageFactory<TMessage> messageFactory)
        {
            if (connectionService == null)
                throw new ArgumentNullException(nameof(connectionService));
            if (packetHandler == null)
                throw new ArgumentNullException(nameof(packetHandler));
            if (messageFactory == null)
                throw new ArgumentNullException(nameof(messageFactory));

            _connectionService = connectionService;
            _packetHandler = packetHandler;
            _messageFactory = messageFactory;
            _messageNotifiers = new Dictionary<Func<TMessage, bool>, MessageNotifier<TMessage>>();
            _cancellationTokenSource = new CancellationTokenSource();
            Task.Factory.StartNew(ProcessReading, _cancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        /// <inheritdoc />
        public IMessageNotifier<TMessage> SubscribeMessage(Func<TMessage, bool> condition)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));

            if (_messageNotifiers.ContainsKey(condition))
                return _messageNotifiers[condition];

            MessageNotifier<TMessage> messageNotifier = new MessageNotifier<TMessage>();
            _messageNotifiers.Add(condition, messageNotifier);

            return messageNotifier;
        }

        /// <inheritdoc />
        public bool SendMessage(TMessage message, byte systemId, byte componentId, byte sequenceNumber = 1)
        {
            byte[] packetPayload = _messageFactory.CreateBytes(message);
            Packet packet = _packetHandler.GetPacket(systemId, componentId, sequenceNumber, message.Id, packetPayload);

            if (packet == null)
                return false;

            try
            {
                lock (_syncRoot)
                    _connectionService.Write(packet.RawBytes);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _cancellationTokenSource.Cancel();

                lock (_syncRoot)
                    _connectionService.Dispose();
            }
            _disposed = true;
        }

        private void ProcessReading()
        {
            while (true)
            {
                byte[] buffer = new byte[_connectionService.BufferSize];
                int bytesRead;

                lock (_syncRoot)
                    bytesRead = _connectionService.Read(buffer);

                if (bytesRead == 0)
                    continue;

                byte[] packetBytes = new byte[bytesRead];
                Array.Copy(buffer, 0, packetBytes, 0, bytesRead);
                IEnumerable<Packet> packets = _packetHandler.HandlePackets(packetBytes);

                foreach (Packet packet in packets)
                {
                    TMessage message = _messageFactory.CreateMessage(packet.Payload, packet.MessageId);
                    NotifyForMessage(message, packet.ComponentId, packet.SystemId);
                }
            }
        }

        private void NotifyForMessage(TMessage message, int componentId, int systemId)
        {
            foreach (var messageNotifier in _messageNotifiers)
            {
                if (messageNotifier.Key(message))
                    messageNotifier.Value.OnMessageReceived(new MessageReceivedEventArgs<TMessage>(message, componentId,
                        systemId));
            }
        }

        ~MavlinkCommunicator()
        {
            Dispose(false);
        }
    }
}