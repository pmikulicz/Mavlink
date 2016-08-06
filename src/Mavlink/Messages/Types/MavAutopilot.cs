namespace Mavlink.Messages.Types
{
    /// <summary>
    /// Defines micro air vehicles/autopilots. This identifies the individual model
    /// </summary>
    public enum MavAutopilot : byte
    {
        /// <summary>
        /// Generic autopilot, full support for everything
        /// </summary>
        Generic = 0,

        /// <summary>
        /// PIXHAWK autopilot, http://pixhawk.ethz.ch
        /// </summary>
        Pixhawk = 1,

        /// <summary>
        /// SLUGS autopilot, http://slugsuav.soe.ucsc.edu
        /// </summary>
        Slugs = 2,

        /// <summary>
        /// ArduPilotMega / ArduCopter, http://diydrones.com
        /// </summary>
        Ardupilotmega = 3,

        /// <summary>
        /// OpenPilot, http://openpilot.org
        /// </summary>
        Openpilot = 4,

        /// <summary>
        /// Generic autopilot only supporting simple waypoints
        /// </summary>
        GenericWaypointsOnly = 5,

        /// <summary>
        /// Generic autopilot supporting waypoints and other simple navigation commands
        /// </summary>
        GenericWaypointsAndSimpleNavigationOnly = 6,

        /// <summary>
        /// Generic autopilot supporting the full mission command set
        /// </summary>
        GenericMissionFull = 7,

        /// <summary>
        /// No valid autopilot, e.g. a GCS or other MAVLink component
        /// </summary>
        Invalid = 8,

        /// <summary>
        /// PPZ UAV - http://nongnu.org/paparazzi
        /// </summary>
        Ppz = 9,

        /// <summary>
        /// UAV Dev Board
        /// </summary>
        Udb = 10,

        /// <summary>
        /// FlexiPilot
        /// </summary>
        Fp = 11,

        /// <summary>
        /// PX4 Autopilot - http://pixhawk.ethz.ch/px4/
        /// </summary>
        Px4 = 12,

        /// <summary>
        /// SMACCMPilot - http://smaccmpilot.org
        /// </summary>
        Smaccmpilot = 13,

        /// <summary>
        /// AutoQuad -- http://autoquad.org
        /// </summary>
        Autoquad = 14,

        /// <summary>
        /// Armazila -- http://armazila.com
        /// </summary>
        Armazila = 15,

        /// <summary>
        /// Aerob -- http://aerob.ru
        /// </summary>
        Aerob = 16
    }
}