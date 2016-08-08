﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkCommunicator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for communication via mavlink protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages;
using Mavlink.Packets;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Mavlink
{
    /// <summary>
    /// Component which is responsible for communication via mavlink protocol
    /// </summary>
    internal sealed class MavlinkCommunicator : IMavlinkCommunicator
    {
        private readonly IPacketHandler _packetHandler;
        private readonly IMessageFactory _messageFactory;
        private readonly IDictionary<Func<IMessage, bool>, MessageNotifier> _messageNotifiers;
        private readonly Stream _stream;
        private readonly BinaryReader _binaryReader;
        private readonly BinaryWriter _binaryWriter;
        private readonly Task _streamReadingTaks;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private bool _disposed;
        private const int BufferSize = 1024;

        internal MavlinkCommunicator(Stream stream, IPacketHandler packetHandler, IMessageFactory messageFactory)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (packetHandler == null)
                throw new ArgumentNullException(nameof(packetHandler));
            if (messageFactory == null)
                throw new ArgumentNullException(nameof(messageFactory));

            _stream = stream;
            _packetHandler = packetHandler;
            _messageFactory = messageFactory;
            _binaryReader = new BinaryReader(stream);
            _binaryWriter = new BinaryWriter(stream);
            _messageNotifiers = new ConcurrentDictionary<Func<IMessage, bool>, MessageNotifier>();
            _cancellationTokenSource = new CancellationTokenSource();
            _streamReadingTaks = Task.Factory.StartNew(ProcessReading, _cancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        /// <summary>
        /// Subscribes for notification of received message from mavlink protocol
        /// </summary>
        /// <param name="condition">A condition which must meet the message</param>
        /// <returns>Component which will notify an incoming message</returns>
        public IMessageNotifier SubscribeForReceive(Func<IMessage, bool> condition)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));

            if (_messageNotifiers.ContainsKey(condition))
                return _messageNotifiers[condition];

            MessageNotifier messageNotifier = new MessageNotifier();
            _messageNotifiers.Add(condition, messageNotifier);

            return messageNotifier;
        }

        /// <summary>
        /// Sends message via mavlink protocol asynchronously
        /// </summary>
        /// <param name="message">Message to be sent asynchronously</param>
        /// <returns>Value which indicates whether operation completed successfully</returns>
        public async Task<bool> SendMessageAsync(IMessage message)
        {
            return await Task.FromResult(true);
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
                _stream.Dispose();
                _binaryReader.Dispose();
                _binaryWriter.Dispose();
            }
            _disposed = true;
        }

        private void ProcessReading()
        {
            while (true)
            {
                byte[] bytesRead = _binaryReader.ReadBytes(BufferSize);
                IEnumerable<Packet> packets = _packetHandler.HandlePackets(bytesRead);

                foreach (Packet packet in packets)
                {
                    IMessage message = _messageFactory.Create(packet.Payload, packet.MessageId);
                    NotifyForMessage(message);
                }
            }
        }

        private void NotifyForMessage(IMessage message)
        {
            foreach (var messageNotifier in _messageNotifiers)
            {
                if (messageNotifier.Key(message))
                    messageNotifier.Value.OnMessageReceived(new MessageReceivedEventArgs(message));
            }
        }

        ~MavlinkCommunicator()
        {
            Dispose(false);
        }
    }
}