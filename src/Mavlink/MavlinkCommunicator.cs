// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkCommunicator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for communication via mavlink protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Mavlink
{
    /// <summary>
    /// Component which is responsible for communication via mavlink protocol
    /// </summary>
    internal sealed class MavlinkCommunicator : IMavlinkCommunicator
    {
        private readonly Stream _stream;
        private readonly StreamReader _streamReader;
        private readonly StreamWriter _streamWriter;
        private readonly IDictionary<Func<Message, bool>, IMessageNotifier> _messageNotifiers;
        private bool _disposed;

        internal MavlinkCommunicator(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            _stream = stream;
            _streamReader = new StreamReader(stream);
            _streamWriter = new StreamWriter(stream);
            _messageNotifiers = new ConcurrentDictionary<Func<Message, bool>, IMessageNotifier>();
        }

        /// <summary>
        /// Subscribes for notification of received message from mavlink protocol
        /// </summary>
        /// <param name="condition">A condition which must meet the message</param>
        /// <returns>Component which will notify an incoming message</returns>
        public IMessageNotifier SubscribeForReceive(Func<Message, bool> condition)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));

            if (_messageNotifiers.ContainsKey(condition))
                return _messageNotifiers[condition];

            IMessageNotifier messageNotifier = new MessageNotifier();
            _messageNotifiers.Add(condition, messageNotifier);

            return messageNotifier;
        }

        /// <summary>
        /// Sends message via mavlink protocol asynchronously
        /// </summary>
        /// <param name="message">Message to be sent asynchronously</param>
        /// <returns>Value which indicates whether operation completed successfully</returns>
        public async Task<bool> SendMessageAsync(Message message)
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
                _stream.Dispose();
                _streamReader.Dispose();
                _streamWriter.Dispose();
            }
            _disposed = true;
        }

        ~MavlinkCommunicator()
        {
            Dispose(false);
        }
    }
}