using Mavlink.Messages;
using Mavlink.Messages.Models;
using System;
using System.Runtime.InteropServices;

namespace Mavlink.Playground
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //            FileStream file = File.Open(@"E:\Desktop\Test.txt", FileMode.Open);
            //
            //            var mavlinkcommunicatorFactory = new MavlinkCommunicatorFactory();
            //
            //            IMavlinkCommunicator mavlinkCommunicator = mavlinkcommunicatorFactory.Create(file);
            //
            //            IMessageNotifier messageNotifier = mavlinkCommunicator.SubscribeForReceive(m => m.Id == 0);
            //            messageNotifier.MessageReceived += MessageReceived;

            // 00  00  00  00  02  03  51  04  03
            var bytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x02, 0x03, 0x51, 0x04, 0x03 };
            IMessage heartbeatMessage = ByteArrayToStructure(bytes, typeof(HeartbeatMessage));

            Console.ReadKey();
        }

        private static IMessage ByteArrayToStructure(byte[] bytes, Type messageType)
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            object stuff = Marshal.PtrToStructure(handle.AddrOfPinnedObject(), messageType);
            handle.Free();
            return (IMessage)stuff;
        }
    }
}