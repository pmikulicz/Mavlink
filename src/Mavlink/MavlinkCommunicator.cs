﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkCommunicator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for handling communication via mavlink protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Connection;
using Mavlink.Messages;
using Mavlink.Packets;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mavlink
{
    /// <summary>
    /// Component which is responsible for handling communication via mavlink protocol
    /// </summary>
    internal sealed class MavlinkCommunicator<TMessage> : IMavlinkCommunicator<TMessage> where TMessage : MavlinkMessage
    {
        private readonly IMavlinkEngine<TMessage> _mavlinkEngine;
        private readonly IConnectionService _connectionService;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly object _syncRoot = new object();
        private bool _disposed;

        internal MavlinkCommunicator(IConnectionService connectionService, MavlinkVersion mavlinkVersion, IMavlinkEngineFactory mavlinkEngineFactory)
        {
            if (mavlinkEngineFactory == null)
                throw new ArgumentNullException(nameof(mavlinkEngineFactory));

            _mavlinkEngine = mavlinkEngineFactory.Create<TMessage>();
            _connectionService = connectionService ?? throw new ArgumentNullException(nameof(connectionService));
            _cancellationTokenSource = new CancellationTokenSource();
            Task.Factory.StartNew(ProcessReading, _cancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            MavlinkVersion = mavlinkVersion;
        }

        /// <inheritdoc />
        public IMessageNotifier<TMessage> SubscribeMessage(Func<TMessage, bool> condition)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));

            return _mavlinkEngine.RegisterMessageSubscriber(condition);
        }

        /// <inheritdoc />
        public bool SendMessage(TMessage message, byte systemId, byte componentId, byte sequenceNumber = 1)
        {
            Packet packet = _mavlinkEngine.CreatePacket(message, systemId, componentId, sequenceNumber);

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

        /// <inheritdoc />
        public MavlinkVersion MavlinkVersion { get; }

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
                _mavlinkEngine.ProcessBytes(packetBytes);
            }
        }

        ~MavlinkCommunicator()
        {
            Dispose(false);
        }
    }
}