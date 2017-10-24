using Mavlink.Messages.Configuration;
using Mavlink.Messages.Dialects.Ardupilot;
using Mavlink.Messages.Implementations.Common.Types;
using System.Collections.Generic;
using System.Reflection;

namespace Mavlink.UnitTests
{
    internal static class Constants
    {
        public static int HeartbeatMessageId = 0;

        public static MessageMetadata HeartBeatMessageMetadata = new MessageMetadata(
            new Dictionary<PropertyInfo, PropertyMetadata>
            {
                {
                    typeof(HeartbeatMessage).GetProperty("Type"), new PropertyMetadata
                    {
                        Name = "type",
                        Order = 2,
                        Size = 1
                    }
                },
                {
                    typeof(HeartbeatMessage).GetProperty("Autopilot"), new PropertyMetadata
                    {
                        Name = "autopilot",
                        Order = 3,
                        Size = 1
                    }
                },
                {
                    typeof(HeartbeatMessage).GetProperty("BaseMode"), new PropertyMetadata
                    {
                        Name = "base_mode",
                        Order = 4,
                        Size = 1
                    }
                },
                {
                    typeof(HeartbeatMessage).GetProperty("CustomMode"), new PropertyMetadata
                    {
                        Name = "custom_mode",
                        Order = 1,
                        Size = 4
                    }
                },
                {
                    typeof(HeartbeatMessage).GetProperty("SystemStatus"), new PropertyMetadata
                    {
                        Name = "system_status",
                        Order = 5,
                        Size = 1
                    }
                },
                {
                    typeof(HeartbeatMessage).GetProperty("MavlinkVersion"), new PropertyMetadata
                    {
                        Name = "mavlink_version",
                        Order = 6,
                        Size = 1
                    }
                }
            }, typeof(HeartbeatMessage))
        {
            Name = "HEARTBEAT",
            Id = HeartbeatMessageId
        };

        public static byte[] HeartbeatMessagePayload =
        {
            0x0, 0x00, 0x00, 0x00, 0x02, 0x03, 0x51, 0x04, 0x03
        };

        public static HeartbeatMessage HeartbeatMessage = new HeartbeatMessage
        {
            Type = MavType.Quadrotor,
            MavlinkVersion = 3,
            SystemStatus = MavState.Active,
            BaseMode = MavModeFlag.CustomModeEnabled | MavModeFlag.StabilizeEnabled | MavModeFlag.ManualInputEnabled,
            CustomMode = 0,
            Autopilot = MavAutopilot.Ardupilotmega
        };
    }
}