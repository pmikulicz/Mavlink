using Mavlink.Messages;
using Mavlink.Messages.Definitions;
using Mavlink.Messages.Implementations.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using Mavlink.Messages.Implementations.Common.Types;

namespace Mavlink.SerialPortTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Process();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }

        private static void Process()
        {
            List<ParamValueMessage> parameters = new List<ParamValueMessage>();
            byte seq = 0;
            //            var serialPort = new SerialPort("COM1", 115200);
            //            serialPort.Open();
            //            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            TcpClient client = new TcpClient("127.0.0.1", 5760);
            MavlinkCommunicatorFactory mavlinkCommunicatorFactory = new MavlinkCommunicatorFactory();
            //            IMavlinkCommunicator<ICommonMessage> mavlinkCommunicator = mavlinkCommunicatorFactory.Create<ICommonMessage>(serialPort.BaseStream);
            IMavlinkCommunicator<ICommonMessage> mavlinkCommunicator =
                mavlinkCommunicatorFactory.Create<ICommonMessage>(client.GetStream());

            IMessageNotifier<ICommonMessage> heartbeatNotifier =
                mavlinkCommunicator.SubscribeForReceive(m => m.Id == MessageId.Heartbeat);
            IMessageNotifier<ICommonMessage> sysNotifier =
                mavlinkCommunicator.SubscribeForReceive(m => m.Id == MessageId.SysStatus);
            IMessageNotifier<ICommonMessage> paramValueNotifier =
                mavlinkCommunicator.SubscribeForReceive(m => m.Id == MessageId.ParamValue);
            IMessageNotifier<ICommonMessage> sysStatusNotifier =
                mavlinkCommunicator.SubscribeForReceive(m => m.Id == MessageId.SysStatus);

            IMessageNotifier<ICommonMessage> statusTextNotifier =
               mavlinkCommunicator.SubscribeForReceive(m => m.Id == MessageId.StatusText);

            heartbeatNotifier.MessageReceived += (sender, eventArgs) =>
            {
                Console.SetCursorPosition(0, 0);
                HeartbeatMessage heartbeatMessage = (HeartbeatMessage)eventArgs.Message;
                Console.WriteLine("HEARTBEAT");
                Console.WriteLine($"Autopilot type: {heartbeatMessage.Autopilot}");
                Console.WriteLine($"Vehicle type: {heartbeatMessage.Type}");
                Console.WriteLine($"Base mode type: {heartbeatMessage.BaseMode}");
                Console.WriteLine($"System state: {heartbeatMessage.SystemStatus}");
                Console.WriteLine($"Mavlink version: {heartbeatMessage.MavlinkVersion}");
                Console.WriteLine($"Mav type: {heartbeatMessage.Type}");
                Console.WriteLine($"Last Update: {DateTime.Now}");
            };

            //            sysNotifier.MessageReceived += (sender, eventArgs) =>
            //            {
            //                SysStatusMessage sysStatusMessage = (SysStatusMessage)eventArgs.Message;
            //                Console.WriteLine($"Battery remaining: {sysStatusMessage.BatteryRemaining}");
            //            };
            //
            paramValueNotifier.MessageReceived += (sender, eventArgs) =>
            {
                Encoding enc = new UTF8Encoding();
                Console.SetCursorPosition(0, 10);
                ParamValueMessage paramValueMessage = (ParamValueMessage)eventArgs.Message;
                parameters.Add(paramValueMessage);
                Console.WriteLine("PARAMVALUE");
                Console.WriteLine($"Param Value: {paramValueMessage.ParamValue}");
                Console.WriteLine($"Param ids: {Encoding.UTF8.GetString(enc.GetBytes(paramValueMessage.ParamId))}");
                Console.WriteLine($"Last Update: {DateTime.Now}");

                Console.SetCursorPosition(0, 20);

                Encoding e = Encoding.UTF8;
                foreach (var p in parameters)
                {
                    File.AppendAllLines("parameters.txt", new string[]
                    {
                        $"Param Value: {p.ParamValue}",
                        $"Param ids: {Encoding.UTF8.GetString(e.GetBytes(p.ParamId))}",
                        $"Param  type: {p.ParamType}",
                        $"Param  count: {p.ParamCount}",
                        $"Param  index: {p.ParamIndex}"
                    });
                }
            };

            statusTextNotifier.MessageReceived += (sender, eventArgs) =>
            {
                Console.SetCursorPosition(0, 16);
                StatusTextMessage statusTextMessage = (StatusTextMessage)eventArgs.Message;
                Console.WriteLine("Status text");
                Console.WriteLine($"Severity: {statusTextMessage.Severity}");
                Console.WriteLine($"Text: {new string(statusTextMessage.Text)}");
                Console.WriteLine($"Last Update: {DateTime.Now}");
            };

            Timer heartbeatTimer = new Timer();
            heartbeatTimer.Elapsed += (sender, eventArgs) =>
            {
                if (seq == 255)
                    seq = 0;
                seq++;
                mavlinkCommunicator.SendMessage(new HeartbeatMessage
                {
                    SystemStatus = MavState.Uninit,
                    MavlinkVersion = 3,
                    Type = MavType.Gcs,
                    Autopilot = MavAutopilot.Invalid,
                    BaseMode = MavModeFlag.CustomModeEnabled,
                }, 1, 1, seq);
            };
            heartbeatTimer.Interval = 2000;
            heartbeatTimer.Enabled = true;

            mavlinkCommunicator.SendMessage(new ParamRequestReadMessage
            {
                TargetComponent = 0,
                TargetSystem = 0,
                ParamId = new[] { '?', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                ParamIndex = -1
            }, 1, 1);

            mavlinkCommunicator.SendMessage(new ParamRequestListMessage
            {
                TargetSystem = 0,
                ComponentId = 0
            }, 1, 1);

            while (true)
                ;
        }
    }
}