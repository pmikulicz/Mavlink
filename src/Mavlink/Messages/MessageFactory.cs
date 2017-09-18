// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Factory which is responsible for creating mavlink messages
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Messages.Definitions;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Mavlink.Messages
{
    /// <summary>
    /// Factory which is responsible for creating mavlink messages
    /// </summary>
    internal sealed class MessageFactory<TMessage> : IMessageFactory<TMessage> where TMessage : MavlinkMessage
    {
        /// <inheritdoc />
        public TMessage CreateMessage(byte[] payload, MessageIdOld messageIdOld)
        {
            if (payload == null)
                throw new ArgumentNullException(nameof(payload));

            TypeInfo typeInfo = typeof(MessageIdOld).GetTypeInfo();
            MemberInfo enumField = typeInfo.DeclaredMembers.FirstOrDefault(m => m.Name.Equals(messageIdOld.ToString()));

            if (enumField == null)
                throw new InvalidOperationException(
                    $"Cannot find field of {typeof(MessageIdOld).Name} type with name {messageIdOld}");

            MessageDefinitionAttribute messageDefinitionAttribute = enumField.GetCustomAttribute<MessageDefinitionAttribute>();

            if (messageDefinitionAttribute == null)
                throw new InvalidOperationException(
                    $"Message id {messageIdOld} is not decorated with attribute {typeof(MessageDefinitionAttribute).Name}");

            Type messageType = messageDefinitionAttribute.Type;
            return CastAsMessage(payload, messageType);
        }

        /// <inheritdoc />
        public byte[] CreateBytes(TMessage message)
        {
            int structureSize = Marshal.SizeOf(message.GetType());
            byte[] messageBytes = new byte[structureSize];

            IntPtr pointerToStructure = Marshal.AllocHGlobal(structureSize);
            Marshal.StructureToPtr(message, pointerToStructure, true);
            Marshal.Copy(pointerToStructure, messageBytes, 0, structureSize);
            Marshal.FreeHGlobal(pointerToStructure);
            return messageBytes;
        }

        private static TMessage CastAsMessage(byte[] payload, Type messageType)
        {
            GCHandle handle = GCHandle.Alloc(payload, GCHandleType.Pinned);
            object obj = Marshal.PtrToStructure(handle.AddrOfPinnedObject(), messageType);
            handle.Free();
            return (TMessage)obj;
        }
    }
}