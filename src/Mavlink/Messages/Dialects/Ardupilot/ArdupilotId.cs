namespace Mavlink.Messages.Dialects.Ardupilot
{
    public enum ArdupilotId
    {
        Heartbeat = 0,

        /// <summary>
        /// The general system state
        /// </summary>
        SysStatus = 1,

        /// <summary>
        /// The system time is the time of the master clock,
        /// typically the computer clock of the main onboard computer
        /// </summary>
        SystemTime = 2,

        /// <summary>
        /// A ping message either requesting or responding to a ping.
        /// This allows to measure the system latencies, including serial port, radio modem and UDP connections
        /// </summary>
        Ping = 4,
    }
}