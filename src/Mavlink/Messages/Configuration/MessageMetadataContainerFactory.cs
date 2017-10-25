// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageMetadataContainerFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which creates container for mavlink message metadata collection for appropriate type of mavlink message
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    /// Component which creates container for mavlink message metadata collection for appropriate type of mavlink message
    /// </summary>
    internal sealed class MessageMetadataContainerFactory : IMessageMetadataContainerFactory
    {
        public IMessageMetadataContainer Create<TMessage>() where TMessage : IMavlinkMessage
        {
            var baseConfigurationType = typeof(MessageConfiguration<TMessage>);
            var assembly = Assembly.GetAssembly(baseConfigurationType);
            var configurationTypes = assembly
                .GetTypes()
                .Where(x =>
                    IsClass(x) &&
                    DerivesFromMessageConfiguration(x) &&
                    GenericArgumentImplementsInterface<TMessage>(x));

            IEnumerable<IMessageConfiguration> configurations =
                configurationTypes.Select(t => (IMessageConfiguration)Activator.CreateInstance(t));

            return new MessageMetadataContainer(CreateMessageMetadataCollection(configurations));
        }

        private static bool GenericArgumentImplementsInterface<TMessage>(Type type) where TMessage : IMavlinkMessage
        {
            Type[] implementedInterfaces = typeof(TMessage).GetInterfaces();

            if (implementedInterfaces.Length == 0)
                return false;

            return type.BaseType.GenericTypeArguments[0].GetInterfaces()
                .Except(implementedInterfaces).Contains(typeof(TMessage));
        }

        private static bool DerivesFromMessageConfiguration(Type type)
        {
            return type.BaseType != null &&
                   type.BaseType.IsGenericType &&
                   type.BaseType.GetGenericTypeDefinition() == typeof(MessageConfiguration<>);
        }

        private static bool IsClass(Type type)
        {
            return !type.IsAbstract && !type.IsInterface;
        }

        private static IEnumerable<MessageMetadata> CreateMessageMetadataCollection(IEnumerable<IMessageConfiguration> configurations)
        {
            foreach (var messageConfiguration in configurations)
            {
                messageConfiguration.Configure();
                yield return ((IMessageMetadataProvider)messageConfiguration).Provide();
            }
        }
    }
}