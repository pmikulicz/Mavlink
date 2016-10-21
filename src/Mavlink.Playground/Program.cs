using Mavlink.Messages.Definitions;
using Mavlink.Messages.Implementations.Common;
using Mavlink.Messages.Implementations.Common.Types;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Mavlink.Playground
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FileStream file = File.Open(@"E:\Desktop\Test.txt", FileMode.Open);

            var mavlinkcommunicatorFactory = new MavlinkCommunicatorFactory();

            IMavlinkCommunicator<ICommonMessage> mavlinkCommunicator = mavlinkcommunicatorFactory.Create<ICommonMessage>(file);
            mavlinkCommunicator.SendMessage(new HeartbeatMessage
            {
                Autopilot = MavAutopilot.Aerob,
                BaseMode = MavModeFlag.AutoEnabled,
                CustomMode = 1,
                MavlinkVersion = 2,
                SystemStatus = MavState.Active,
                Type = MavType.Airship
            }, 1, 1);

            // 00  00  00  00  02  03  51  04  03
            var bytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x02, 0x03, 0x51, 0x04, 0x03 };
            ICommonMessage heartbeatMessage = ByteArrayToStructure(bytes, typeof(HeartbeatMessage));

            Console.ReadKey();
        }

        private static ICommonMessage ByteArrayToStructure(byte[] bytes, Type messageType)
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            object stuff = Marshal.PtrToStructure(handle.AddrOfPinnedObject(), messageType);
            handle.Free();
            return (ICommonMessage)stuff;
        }
    }
}