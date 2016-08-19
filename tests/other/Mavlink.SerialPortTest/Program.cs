using Mavlink.Messages;
using Mavlink.Messages.Models;
using System;
using System.IO.Ports;

namespace Mavlink.SerialPortTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var serialPort = new SerialPort("COM7", 115200);
            serialPort.Open();

            MavlinkCommunicatorFactory mavlinkCommunicatorFactory = new MavlinkCommunicatorFactory();
            IMavlinkCommunicator mavlinkCommunicator = mavlinkCommunicatorFactory.Create(serialPort.BaseStream);
            IMessageNotifier heartbeatNotifier =
                mavlinkCommunicator.SubscribeForReceive(m => m.Id == MessageId.Heartbeat);

            //            IMessageNotifier systemTimeNotifier =
            //               mavlinkCommunicator.SubscribeForReceive(m => m.Id == MessageId.SystemTime);
            //
            //            IMessageNotifier sysStatusNotifier =
            //               mavlinkCommunicator.SubscribeForReceive(m => m.Id == MessageId.SysStatus);

            heartbeatNotifier.MessageReceived += (sender, eventArgs) =>
            {
                HeartbeatMessage heartbeatMessage = (HeartbeatMessage)eventArgs.Message;
                Console.WriteLine($"Autopilot type: {heartbeatMessage.Autopilot}");
                Console.WriteLine($"Vehicle type: {heartbeatMessage.Type}");
                Console.WriteLine($"Base mode type: {heartbeatMessage.BaseMode}");
            };

            //            systemTimeNotifier.MessageReceived += (sender, eventArgs) =>
            //            {
            //                SystemTimeMessage heartbeatMessage = (SystemTimeMessage)eventArgs.Message;
            //                Console.WriteLine($"TimeBootMs: {heartbeatMessage.TimeBootMs}");
            //                Console.WriteLine($"Time Unix uSec: {heartbeatMessage.TimeUnixUsec}");
            //            };
            //
            //            sysStatusNotifier.MessageReceived += (sender, eventArgs) =>
            //            {
            //                SysStatusMessage heartbeatMessage = (SysStatusMessage)eventArgs.Message;
            //                Console.WriteLine($"Sensors enabled: {heartbeatMessage.SensorsEnabled}");
            //            };

            while (true)
                ;
        }
    }
}