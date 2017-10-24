// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkEngineFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Factory for creating engine for the mavlink protocol
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Common.Converters;
using Mavlink.Messages;
using Mavlink.Messages.Configuration;
using Mavlink.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mavlink
{
    /// <summary>
    /// Factory for creating engine for the mavlink protocol
    /// </summary>
    internal sealed class MavlinkEngineFactory : IMavlinkEngineFactory
    {
        private static IList<IConverter> _cachedByteConverters;

        public MavlinkEngineFactory()
        {
            if (_cachedByteConverters == null)
                InitializeByteConverters();
        }

        private static void InitializeByteConverters()
        {
            var assembly = Assembly.GetAssembly(typeof(IConverter));
            List<Type> converterTypes = assembly.GetTypes()
                .Where(t =>
                    !t.IsAbstract &&
                    !t.IsInterface &&
                    t.IsClass &&
                    typeof(IConverter).IsAssignableFrom(t))
                .ToList();

            _cachedByteConverters = new List<IConverter>(converterTypes.Count);

            foreach (var type in converterTypes)
            {
                _cachedByteConverters.Add((IConverter)Activator.CreateInstance(type));
            }
        }

        /// <inheritdoc />
        public IMavlinkEngine<TMessage> Create<TMessage>() where TMessage : MavlinkMessage
        {
            return new MavlinkEngine<TMessage>(new PacketHandler(), new MessageFactory<TMessage>(new MessageMetadataContainerFactory(),
                type =>
                {
                    return _cachedByteConverters.FirstOrDefault(c => c.Type == type);
                }));
        }
    }
}