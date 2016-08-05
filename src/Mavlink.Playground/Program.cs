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

            var bytes = new byte[] { 0x00, 0x01, 0x03 };

            HeartbeatMessage message = ByteArrayToStructure<HeartbeatMessage>(bytes);

            Console.ReadKey();
        }

        private static T ByteArrayToStructure<T>(byte[] bytes)
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T stuff = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return stuff;
        }
    }

    public abstract class Message
    {
        public abstract int Id { get; }
    }

    [StructLayout(LayoutKind.Sequential)]
    public class HeartbeatMessage : Message
    {
        public override int Id => 0;

        public byte SystemId { get; set; }

        public SomeType SomeType { get; set; }
    }

    public enum SomeType : byte
    {
        T1 = 0,
        T2 = 3
    }
}