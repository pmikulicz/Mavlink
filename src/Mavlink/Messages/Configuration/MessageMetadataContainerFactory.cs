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
       
        public IMessageMetadataContainer Create<TMessage>() where TMessage : MavlinkMessage
        {
            var baseConfigurationType = typeof(MessageConfiguration<TMessage>);
            var assembly = Assembly.GetAssembly(baseConfigurationType);
            var configurationTypes = assembly
                .GetTypes()
                .Where(x =>
                    !x.IsAbstract &&
                    !x.IsInterface &&
                    x.BaseType != null &&
                    x.BaseType.IsGenericType &&
                    x.BaseType.GetGenericTypeDefinition() == typeof(MessageConfiguration<>) &&
                    x.BaseType.GenericTypeArguments[0].BaseType == typeof(TMessage));

            IEnumerable<IMessageConfiguration> configurations =
                configurationTypes.Select(t => (IMessageConfiguration)Activator.CreateInstance(t));

            return new MessageMetadataContainer(CreateMessageMetadataCollection(configurations));

        }

        private static IEnumerable<MessageMetadata> CreateMessageMetadataCollection(IEnumerable<IMessageConfiguration> configurations)
        {
            foreach (var messageConfiguration in configurations)
            {
                messageConfiguration.Configure();
                yield return ((IMessageMetadataProvider) messageConfiguration).Provide();
            }
        }
    }
}