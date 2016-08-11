// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Factory which is responsible for creating mavlink messages
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Mavlink.Messages
{
    /// <summary>
    /// Factory which is responsible for creating mavlink messages
    /// </summary>
    internal sealed class MessageFactory : IMessageFactory
    {
        /// <summary>
        /// Creates mavlink message based on passed payload and message id
        /// </summary>
        /// <param name="payload">Payload from which message will be created</param>
        /// <param name="messageId">Id of created message</param>
        /// <returns>Mavlink message</returns>
        public IMessage CreateMessage(byte[] payload, MessageId messageId)
        {
            if (payload == null)
                throw new ArgumentNullException(nameof(payload));

            if (!Enum.IsDefined(typeof(MessageId), messageId))
                throw new ArgumentOutOfRangeException(nameof(messageId),
                    "Value should be defined in the MessageId enum.");

            TypeInfo typeInfo = typeof(MessageId).GetTypeInfo();
            MemberInfo enumField = typeInfo.DeclaredMembers.FirstOrDefault(m => m.Name.Equals(messageId.ToString()));

            if (enumField == null)
                throw new InvalidOperationException(
                    $"Cannot find field of {typeof(MessageId).Name} type with name {messageId}");

            MessageStructAttribute messageStructAttribute = enumField.GetCustomAttribute<MessageStructAttribute>();

            if (messageStructAttribute == null)
                throw new InvalidOperationException(
                    $"Message id {messageId} is not decorated with attribute {typeof(MessageStructAttribute).Name}");

            Type messageType = messageStructAttribute.Type;

            return CastAsMessage(payload, messageType);
        }

        /// <summary>
        /// Creates array of bytes based on passed mavlink message
        /// </summary>
        /// <typeparam name="TMessage">Mavlink message</typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public byte[] CreateBytes<TMessage>(TMessage message) where TMessage
            : struct, IMessage
        {
            int structureSize = Marshal.SizeOf(typeof(TMessage));
            byte[] messageBytes = new byte[structureSize];

            IntPtr pointerToStructure = Marshal.AllocHGlobal(structureSize);
            Marshal.StructureToPtr(message, pointerToStructure, true);
            Marshal.Copy(pointerToStructure, messageBytes, 0, structureSize);
            Marshal.FreeHGlobal(pointerToStructure);
            return messageBytes;
        }

        private static IMessage CastAsMessage(byte[] payload, Type messageType)
        {
            GCHandle handle = GCHandle.Alloc(payload, GCHandleType.Pinned);
            object obj = Marshal.PtrToStructure(handle.AddrOfPinnedObject(), messageType);
            handle.Free();
            return (IMessage)obj;
        }
    }
}