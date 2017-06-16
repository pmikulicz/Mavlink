namespace Mavlink.Messages.Implementations.Common.Types
{
    public enum MavCmd
    {
        /// <summary>
        /// Navigate to MISSION
        /// Param 1: Hold time in decimal seconds. (ignored by fixed wing, time to stay at MISSION for rotary wing)
        /// Param 2: Acceptance radius in meters (if the sphere with this radius is hit, the MISSION counts as reached)
        /// Param 3: 0 to pass through the WP, if > 0 radius in meters to pass by WP. Positive value for clockwise orbit, negative value for counter-clockwise orbit. Allows trajectory control.
        /// Param 4: Desired yaw angle at MISSION (rotary wing)
        /// Param 5: Latitude
        /// Param 6: Longitude
        /// Param 7: Altitude
        /// </summary>
        NavWaypoint = 16,

        /// <summary>
        /// Loiter around this MISSION an unlimited amount of tim
        /// Param 1: Empty
        /// Param 2: Empty
        /// Param 3: Radius around MISSION, in meters. If positive loiter clockwise, else counter-clockwise
        /// Param 4: Desired yaw angle.
        /// Param 5: Latitude
        /// Param 6: Longitude
        /// Param 7: Altitude
        /// </summary>
        NavLoiterUnlim = 17,

        /// <summary>
        /// Loiter around this MISSION for X turns
        /// Param 1: Turns
        /// Param 2: Empty
        /// Param 3: Radius around MISSION, in meters. If positive loiter clockwise, else counter-clockwise
        /// Param 4: Forward moving aircraft this sets exit xtrack location: 0 for center of loiter wp, 1 for exit location. Else, this is desired yaw angle
        /// Param 5: Latitude
        /// Param 6: Longitude
        /// Param 7: Altitude
        /// </summary>
        LoiterTurns = 18,

        /// <summary> Loiter around this MISSION for X seconds
        /// Param 1: Seconds (decimal)
        /// Param 2: Empty
        /// Param 3: Radius around MISSION, in meters. If positive loiter clockwise, else counter-clockwise
        /// Param 4: Forward moving aircraft this sets exit xtrack location: 0 for center of loiter wp, 1 for exit location. Else, this is desired yaw angle
        /// Param 5: Latitude
        /// Param 6: Longitude
        /// Param 7: Altitude
        /// </summary>
        LoiterTime = 19,

        /// <summary>
        /// Return to launch location
        /// Param 1: Empty
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        ReturnToLaunch = 20,

        /// <summary> Land at location
        /// Param 1: Abort Alt
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Desired yaw angle
        /// Param 5: Latitude
        /// Param 6: Longitude
        /// Param 7: Altitude
        /// </summary>
        Land = 21,

        /// <summary>
        /// Takeoff from ground / hand
        /// Param 1: Minimum pitch (if airspeed sensor present), desired pitch without sensor
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Yaw angle (if magnetometer present), ignored without magnetometer
        /// Param 5: Latitude
        /// Param 6: Longitude
        /// Param 7: Altitude
        /// </summary>
        Takeoff = 22,

        /// <summary>
        /// Land at local position (local frame only)
        /// Param 1: Landing target number (if available)
        /// Param 2: Maximum accepted offset from desired landing position [m] - computed magnitude from spherical coordinates: d = sqrt(x^2 + y^2 + z^2),
        /// which gives the maximum accepted distance between the desired landing position and the position where the vehicle is about to land
        /// Param 3: Landing descend rate [ms^-1]
        /// Param 4: Desired yaw angle [rad]
        /// Param 5: Y-axis position [m]
        /// Param 6: X-axis position [m]
        /// Param 7: Z-axis / ground level position [m]
        /// </summary>
        LandLocal = 23,

        /// <summary>
        /// Takeoff from local position (local frame only)
        /// Param 1: Minimum pitch (if airspeed sensor present), desired pitch without sensor [rad]
        /// Param 2: Empty
        /// Param 3: Takeoff ascend rate [ms^-1]
        /// Param 4: Yaw angle [rad] (if magnetometer or another yaw estimation source present), ignored without one of these
        /// Param 5: Y-axis position [m]
        /// Param 6: X-axis position [m]
        /// Param 7: Z-axis position [m]
        /// </summary>
        TakeoffLocal = 24,

        /// <summary>
        /// Vehicle following, i.e. this waypoint represents the position of a moving vehicle
        /// Param 1: Following logic to use (e.g. loitering or sinusoidal following) - depends on specific autopilot implementation
        /// Param 2: Ground speed of vehicle to be followed
        /// Param 3: Radius around MISSION, in meters. If positive loiter clockwise, else counter-clockwise
        /// Param 4: Desired yaw angle
        /// Param 5: Latitude
        /// Param 6: Longitude
        /// Param 7: Altitude
        /// </summary>
        Follow = 25,

        /// <summary>
        /// Continue on the current course and climb/descend to specified altitude.
        /// When the altitude is reached continue to the next command (i.e., don't proceed to the next command until the desired altitude is reached.
        /// Param 1: Climb or Descend (0 = Neutral, command completes when within 5m of this command's altitude, 1 = Climbing, command completes when at or above this command's altitude, 2 = Descending, command completes when at or below this command's altitude.
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Desired altitude in meters
        /// </summary>
        ContinueAndChangeAlt = 30,

        /// <summary>
        /// Begin loiter at the specified Latitude and Longitude.  If Lat=Lon=0, then loiter at the current position. Don't consider the navigation command complete (don't leave loiter) until the altitude has been reached.
        /// Additionally, if the Heading Required parameter is non-zero the  aircraft will not leave the loiter until heading toward the next waypoint.
        /// Param 1: Heading Required (0 = False)
        /// Param 2: Radius in meters. If positive loiter clockwise, negative counter-clockwise, 0 means no change to standard loiter
        /// Param 3: Empty
        /// Param 4: Forward moving aircraft this sets exit xtrack location: 0 for center of loiter wp, 1 for exit location
        /// Param 5: Latitude
        /// Param 6: Longitude
        /// Param 7: Altitude
        /// </summary>
        LoiterToAlt = 31,

        /// <summary>
        /// Being following a target
        /// Param 1: System id (the system id of the FOLLOW_TARGET beacon). Send 0 to disable follow-me and return to the default position hold mode
        /// Param 2: RESERVED
        /// Param 3: RESERVED
        /// Param 4: altitude flag: 0: Keep current altitude, 1: keep altitude difference to target, 2: go to a fixed altitude above home
        /// Param 5: altitude
        /// Param 6: RESERVED
        /// Param 7: TTL in seconds in which the MAV should go to the default position hold mode after a message rx timeout
        /// </summary>
        DoFollow = 32,

        /// <summary>
        /// Reposition the MAV after a follow target command has been sent
        /// Param 1: Camera q1 (where 0 is on the ray from the camera to the tracking device)
        /// Param 2: Camera q2
        /// Param 3: Camera q3
        /// Param 4: Camera q4
        /// Param 5: altitude offset from target (m)
        /// Param 6: X offset from target (m)
        /// Param 7: Y offset from target (m)
        /// </summary>
        DoFollowReposition = 33,

        /// <summary>
        /// Sets the region of interest (ROI) for a sensor set or the vehicle itself. This can then be used by the vehicles control system to control the vehicle attitude and the attitude of various sensors such as cameras.
        /// Param 1: Region of intereset mode. (see MAV_ROI enum)
        /// Param 2: MISSION index/ target id. (see MAV_ROI enum)
        /// Param 3: ROI index (allows a vehicle to manage multiple ROI's)
        /// Param 4: Empty
        /// Param 5: x the location of the fixed ROI (see MAV_FRAME)
        /// Param 6: y
        /// Param 7: z
        /// </summary>
        Roi = 80,

        /// <summary>
        /// Control autonomous path planning on the MAV
        /// Param 1: 0: Disable local obstacle avoidance / local path planning (without resetting map), 1: Enable local path planning, 2: Enable and reset local path planning
        /// Param 2: 0: Disable full path planning (without resetting map), 1: Enable, 2: Enable and reset map/occupancy grid, 3: Enable and reset planned route, but not occupancy grid
        /// Param 3: Empty
        /// Param 4: Yaw angle at goal, in compass degrees, [0..360]
        /// Param 5: Latitude/X of goal
        /// Param 6: Longitude/Y of goal
        /// Param 7: Altitude/Z of goal
        /// </summary>
        Pathplanning = 81,

        /// <summary>
        /// Navigate to MISSION using a spline path
        /// Param 1: Hold time in decimal seconds. (ignored by fixed wing, time to stay at MISSION for rotary wing)
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Latitude/X of goal
        /// Param 6: Longitude/Y of goal
        /// Param 7: Altitude/Z of goal
        /// </summary>
        SplineWaypoint = 82,

        /// <summary>
        /// Mission command to wait for an altitude or downwards vertical speed. This is meant for high altitude balloon launches,
        /// allowing the aircraft to be idle until either an altitude is reached or a negative vertical speed is reached (indicating early balloon burst).
        /// The wiggle time is how often to wiggle the control surfaces to prevent them seizing up
        /// Param 1: altitude (m)
        /// Param 2: descent speed (m/s)
        /// Param 3: Wiggle Time (s)
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        AltitudeWait = 83,

        /// <summary>
        /// Takeoff from ground using VTOL mode
        /// Param 1: Empty
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Yaw angle in degrees
        /// Param 5: Latitude
        /// Param 6: Longitude
        /// Param 7: Altitude
        /// </summary>
        VtolTakeoff = 84,

        /// <summary>
        /// Land using VTOL mode
        /// Param 1: Empty
        /// Param 2: Empty
        /// Param 3:Empty
        /// Param 4: Yaw angle in degrees
        /// Param 5: Latitude
        /// Param 6: Longitude
        /// Param 7: Altitude
        /// </summary>
        VtolLand = 85,

        /// <summary>
        /// Hand control over to an external controller
        /// Param 1: On / Off (> 0.5f on)
        /// Param 1: Empty
        /// Param 1: Empty
        /// Param 1: Empty
        /// Param 1: Empty
        /// Param 1: Empty
        /// Param 1: Empty
        /// </summary>
        GuidedEnable = 92,

        /// <summary>
        /// Delay the next navigation command a number of seconds or until a specified time
        /// Param 1: Delay in seconds (decimal, -1 to enable time-of-day fields)
        /// Param 2: hour (24h format, UTC, -1 to ignore)
        /// Param 3: minute (24h format, UTC, -1 to ignore)
        /// Param 4: second (24h format, UTC)
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        Delay = 93,

        /// <summary>
        /// Descend and place payload.  Vehicle descends until it detects a hanging payload has reached the ground, the gripper is opened to release the payload
        /// Param 1: Maximum distance to descend (meters)
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Latitude (deg * 1E7)
        /// Param 6: Longitude (deg * 1E7)
        /// Param 7: Altitude (meters)
        /// </summary>
        PayloadPlace = 94,

        /// <summary>
        /// NOP - This command is only used to mark the upper limit of the NAV/ACTION commands in the enumeration
        /// Param 1: Empty
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        Last = 95,

        /// <summary>
        /// Delay mission state machine
        /// Param 1: Delay in seconds (decimal)
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        ConditionDelay = 112,

        /// <summary>
        /// Ascend/descend at rate.  Delay mission state machine until desired altitude reached
        /// Param 1: Descent / Ascend rate (m/s)
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Finish Altitude
        /// </summary>
        ConditionChangeAlt = 113,

        /// <summary>
        /// Delay mission state machine until within desired distance of next NAV point
        /// Param 1: Distance (meters)
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        ConditionDistance = 114,

        /// <summary>
        /// Reach a certain target angle
        /// Param 1: Target angle: [0-360], 0 is north
        /// Param 1: Speed during yaw change:[deg per second]
        /// Param 1: Direction: negative: counter clockwise, positive: clockwise [-1,1]
        /// Param 1: Relative offset or absolute angle: [ 1,0]
        /// Param 1: Empty
        /// Param 1: Empty
        /// Param 1: Empty
        /// </summary>
        ConditionYaw = 115,

        /// <summary>
        /// NOP - This command is only used to mark the upper limit of the CONDITION commands in the enumeration
        /// Param 1: Empty
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        ConditionLast = 159,

        /// <summary>
        /// Set system mode
        /// Param 1: Mode, as defined by ENUM MAV_MODE
        /// Param 2: Custom mode - this is system specific, please refer to the individual autopilot specifications for details
        /// Param 3: Custom sub mode - this is system specific, please refer to the individual autopilot specifications for details
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoSetMode = 176,

        /// <summary>
        /// Jump to the desired command in the mission list. Repeat this action only the specified number of times
        /// Param 1: Sequence number
        /// Param 2: Repeat count
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoJump = 177,

        /// <summary>
        /// Change speed and/or throttle set points
        /// Param 1: Speed type (0=Airspeed, 1=Ground Speed)
        /// Param 2: Speed  (m/s, -1 indicates no change)
        /// Param 3: Throttle  ( Percent, -1 indicates no change)
        /// Param 4: absolute or relative [0,1]
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoChangeSpeed = 178,

        /// <summary>
        /// Changes the home location either to the current location or a specified location
        /// Param 1: Use current (1=use current location, 0=use specified location)
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Latitude
        /// Param 6: Longitude
        /// Param 7: Altitude
        /// </summary>
        DoSetHome = 179,

        ///<summary>
        /// Set a system parameter. Caution!  Use of this command requires knowledge of the numeric enumeration value of the parameter
        /// Param 1: Parameter number
        /// Param 2: Parameter value
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoSetParameter = 180,

        ///<summary>
        /// Set a relay to a condition
        /// Param 1: Relay number
        /// Param 2: Setting (1=on, 0=off, others possible depending on system hardware)
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoSetRelay = 181,

        ///<summary>
        /// Cycle a relay on and off for a desired number of cyles with a desired period
        /// Param 1: Relay number
        /// Param 2: Cycle count
        /// Param 3: Cycle time (seconds, decimal)
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoRepeatRelay = 182,

        /// <summary>
        /// Set a servo to a desired PWM value
        /// Param 1: Servo number
        /// Param 2: PWM (microseconds, 1000 to 2000 typical)
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoSetServo = 183,

        /// <summary>
        /// Cycle a between its nominal setting and a desired PWM for a desired number of cycles with a desired period
        /// Param 1: Servo number
        /// Param 2: PWM (microseconds, 1000 to 2000 typical)
        /// Param 3: Cycle count
        /// Param 4: Cycle time (seconds)
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoRepeatServo = 184,

        /// <summary>
        /// Terminate flight immediately
        /// Param 1: Flight termination activated if > 0.5
        /// Param 1: Empty
        /// Param 1: Empty
        /// Param 1: Empty
        /// Param 1: Empty
        /// Param 1: Empty
        /// Param 1: Empty
        /// </summary>
        DoFlighttermination = 185,

        /// <summary>
        /// Change altitude set point
        /// Param 1: Altitude in meters
        /// Param 2: Mav frame of new altitude (see MAV_FRAME)
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoChangeAltitude = 186,

        /// <summary>
        /// Mission command to perform a landing. This is used as a marker in a mission to tell the autopilot where a sequence of mission items that represents a landing starts.
        /// It may also be sent via a COMMAND_LONG to trigger a landing, in which case the nearest (geographically) landing sequence in the mission will be used.
        /// The Latitude/Longitude is optional, and may be set to 0/0 if not needed. If specified then it will be used to help find the closest landing sequence
        /// Param 1: Empty
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Latitude
        /// Param 6: Longitude
        /// Param 7: Empty
        /// </summary>
        DoLandStart = 189,

        /// <summary>
        /// Mission command to perform a landing from a rally point
        /// Param 1: Break altitude (meters)
        /// Param 2: Landing speed (m/s)
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoRallyLand = 190,

        /// <summary>
        /// Mission command to safely abort an autonmous landing
        /// Param 1: Altitude (meters)
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoGoAround = 191,

        /// <summary>
        /// Reposition the vehicle to a specific WGS84 global position
        /// Param 1: Ground speed, less than 0 (-1) for default
        /// Param 2: Bitmask of option flags, see the MAV_DO_REPOSITION_FLAGS enum
        /// Param 3: Reserved
        /// Param 4: Yaw heading, NaN for unchanged. For planes indicates loiter direction (0: clockwise, 1: counter clockwise)
        /// Param 5: Latitude (deg * 1E7)
        /// Param 6: Longitude (deg * 1E7)
        /// Param 7: Altitude (meters)
        /// </summary>
        DoReposition = 192,

        /// <summary>
        /// If in a GPS controlled position mode, hold the current position or continue
        /// Param 1: 0: Pause current mission or reposition command, hold current position. 1: Continue mission. A VTOL capable vehicle should enter hover mode (multicopter and VTOL planes).
        /// A plane should loiter with the default loiter radius
        /// Param 2: Reserved
        /// Param 3: Reserved
        /// Param 4: Reserved
        /// Param 5: Reserved
        /// Param 6: Reserved
        /// Param 7: Reserved
        /// </summary>
        DoPauseContinue = 193,

        /// <summary>
        /// Set moving direction to forward or reverse
        /// Param 1: Direction (0=Forward, 1=Reverse)
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoSetReverse = 194,

        /// <summary>
        /// Control onboard camera system
        /// Param 1: Camera id (-1 for all)
        /// Param 2: Transmission: 0: disabled, 1: enabled compressed, 2: enabled raw
        /// Param 3: Transmission mode: 0: video stream, >0: single images every n seconds (decimal)
        /// Param 4: Recording: 0: disabled, 1: enabled compressed, 2: enabled raw
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoControlVideo = 200,

        /// <summary>
        /// Sets the region of interest (ROI) for a sensor set or the vehicle itself. This can then be used by the vehicles control system to control the vehicle attitude and the attitude of various sensors such as cameras
        /// Param 1: Region of intereset mode. (see MAV_ROI enum)
        /// Param 2: MISSION index/ target id. (see MAV_ROI enum)
        /// Param 3: ROI index (allows a vehicle to manage multiple ROI's)
        /// Param 4: Empty
        /// Param 5: x the location of the fixed ROI (see MAV_FRAME)
        /// Param 6: y
        /// Param 7: z
        /// </summary>
        DoSetRoi = 201,

        /// <summary>
        /// Mission command to configure an on-board camera controller system
        /// Param 1: Modes: P, TV, AV, M, Etc
        /// Param 2: Shutter speed: Divisor number for one second
        /// Param 3: Aperture: F stop number
        /// Param 4: ISO number e.g. 80, 100, 200, Etc
        /// Param 5: Exposure type enumerator
        /// Param 6: Command identity
        /// Param 7: Main engine cut-off time before camera trigger in seconds/10 (0 means no cut-off)
        /// </summary>
        DoDigicamConfigure = 202,

        /// <summary>
        /// Mission command to control an on-board camera controller system
        /// Param 1: Session control e.g. show/hide lens
        /// Param 2: Zoom's absolute position
        /// Param 3: Zooming step value to offset zoom from the current position
        /// Param 4: Focus Locking, Unlocking or Re-locking
        /// Param 5: Shooting Command
        /// Param 6: Command identity
        /// Param 7: Empty
        /// </summary>
        DoDigicamControl = 203,

        /// <summary>
        /// Mission command to configure a camera or antenna mount
        /// Param 1: Mount operation mode (see MAV_MOUNT_MODE enum)
        /// Param 2: stabilize roll? (1 = yes, 0 = no)
        /// Param 3: stabilize pitch? (1 = yes, 0 = no)
        /// Param 4: stabilize yaw? (1 = yes, 0 = no)
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoMountConfigure = 204,

        /// <summary>
        /// Mission command to control a camera or antenna mount
        /// Param 1: Pitch (WIP: DEPRECATED: or lat in degrees) depending on mount mode
        /// Param 2: Roll (WIP: DEPRECATED: or lon in degrees) depending on mount mode
        /// Param 3: Yaw (WIP: DEPRECATED: or alt in meters) depending on mount mode
        /// Param 4: WIP: alt in meters depending on mount mode
        /// Param 5: WIP: latitude in degrees * 1E7, set if appropriate mount mode
        /// Param 6: WIP: longitude in degrees * 1E7, set if appropriate mount mode
        /// Param 7: MAV_MOUNT_MODE enum value
        /// </summary>
        DoMountControl = 205,

        /// <summary>
        /// Mission command to set CAM_TRIGG_DIST for this flight
        /// Param 1: Camera trigger distance (meters)
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoSetCamTriggDist = 206,

        /// <summary>
        /// Mission command to enable the geofence
        /// Param 1: Enable? (0=disable, 1=enable, 2=disable_floor_only)
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoFenceEnable = 207,

        /// <summary>
        /// Mission command to trigger a parachute
        /// Param 1: Action (0=disable, 1=enable, 2=release, for some systems see PARACHUTE_ACTION enum, not in general message set.)
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoParachute = 208,

        /// <summary>
        /// Mission command to perform motor test
        /// Param 1: Motor sequence number (a number from 1 to max number of motors on the vehicle)
        /// Param 2: Throttle type (0=throttle percentage, 1=PWM, 2=pilot throttle channel pass-through. See MOTOR_TEST_THROTTLE_TYPE enum)
        /// Param 3: Throttle
        /// Param 4: Timeout (in seconds)
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoMotorTest = 209,

        /// <summary>
        /// Change to/from inverted flight
        /// Param 1: Inverted (0=normal, 1=inverted)
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoInvertedFlight = 210,

        /// <summary>
        /// Mission command to operate EPM gripper
        /// Param 1: Gripper number (a number from 1 to max number of grippers on the vehicle)
        /// Param 2: Gripper action (0=release, 1=grab. See GRIPPER_ACTIONS enum)
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoGripper = 211,

        /// <summary>
        /// Enable/disable autotune
        /// Param 1: Enable (1: enable, 0:disable)
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoAutotuneEnable = 212,

        /// <summary>
        /// Sets a desired vehicle turn angle and speed change
        /// Param 1: Yaw angle to adjust steering by in centidegress
        /// Param 2: Speed - normalized to 0 .. 1
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        SetYawSpeed = 213,

        /// <summary>
        /// Mission command to control a camera or antenna mount, using a quaternion as reference
        /// Param 1: Q1 - quaternion param #1, w (1 in null-rotation)
        /// Param 2: Q2 - quaternion param #2, x (0 in null-rotation)
        /// Param 3: Q3 - quaternion param #3, y (0 in null-rotation)
        /// Param 4: Q4 - quaternion param #4, z (0 in null-rotation)
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoMountControlQuat = 220,

        /// <summary>
        /// Set id of master controller
        /// Param 1: System id
        /// Param 2: Component id
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoGuidedMaster = 221,

        /// <summary>
        /// Set limits for external control
        /// Param 1:timeout - maximum time (in seconds) that external controller will be allowed to control vehicle. 0 means no timeout
        /// Param 2: absolute altitude min (in meters, AMSL) - if vehicle moves below this alt, the command will be aborted and the mission will continue.  0 means no lower altitude limit
        /// Param 3: absolute altitude max (in meters)- if vehicle moves above this alt, the command will be aborted and the mission will continue. 0 means no upper altitude limit
        /// Param 4: horizontal move limit (in meters, AMSL) - if vehicle moves more than this distance from it's location at the moment the command was executed,
        /// the command will be aborted and the mission will continue. 0 means no horizontal altitude limit
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoGuidedLimits = 222,

        /// <summary>
        /// Control vehicle engine. This is interpreted by the vehicles engine controller to change the target engine state. It is intended for vehicles with internal combustion engines
        /// Param 1: 0: Stop engine, 1:Start Engine
        /// Param 2: 0: Warm start, 1:Cold start. Controls use of choke where applicable
        /// Param 3: Height delay (meters). This is for commanding engine start only after the vehicle has gained the specified height.
        /// Used in VTOL vehicles during takeoff to start engine after the aircraft is off the ground. Zero for no delay
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoEngineControl = 223,

        /// <summary>
        /// NOP - This command is only used to mark the upper limit of the DO commands in the enumeration
        /// Param 1: Empty
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoLast = 240,

        /// <summary>
        /// Trigger calibration. This command will be only accepted if in pre-flight mode
        /// Param 1: Gyro calibration: 0: no, 1: yes
        /// Param 2: Magnetometer calibration: 0: no, 1: yes
        /// Param 3: Ground pressure: 0: no, 1: yes
        /// Param 4: Radio calibration: 0: no, 1: yes
        /// Param 5: Accelerometer calibration: 0: no, 1: yes
        /// Param 6: Compass/Motor interference calibration: 0: no, 1: yes
        /// Param 7: Empty
        /// </summary>
        PreflightCalibration = 241,

        /// <summary>
        /// Set sensor offsets. This command will be only accepted if in pre-flight mode
        /// Param 1: Sensor to adjust the offsets for: 0: gyros, 1: accelerometer, 2: magnetometer, 3: barometer, 4: optical flow, 5: second magnetometer, 6: third magnetometer
        /// Param 2: X axis offset (or generic dimension 1), in the sensor's raw units
        /// Param 3: Y axis offset (or generic dimension 2), in the sensor's raw units
        /// Param 4: Z axis offset (or generic dimension 3), in the sensor's raw units
        /// Param 5: Generic dimension 4, in the sensor's raw units
        /// Param 6: Generic dimension 5, in the sensor's raw units
        /// Param 7: Generic dimension 6, in the sensor's raw units
        /// </summary>
        PreflightSetSensorOffsets = 242,

        ///<summary>
        /// Trigger UAVCAN config. This command will be only accepted if in pre-flight mode
        /// Param 1: 1: Trigger actuator id assignment and direction mapping
        /// Param 2: Reserved
        /// Param 3: Reserved
        /// Param 4: Reserved
        /// Param 5: Reserved
        /// Param 6: Reserved
        /// Param 7: Reserved
        /// </summary>
        PreflightUavcan = 243,

        /// <summary>
        /// Request storage of different parameter values and logs. This command will be only accepted if in pre-flight mode
        /// Param 1: Parameter storage: 0: READ FROM FLASH/EEPROM, 1: WRITE CURRENT TO FLASH/EEPROM, 2: Reset to defaults
        /// Param 2: Mission storage: 0: READ FROM FLASH/EEPROM, 1: WRITE CURRENT TO FLASH/EEPROM, 2: Reset to defaults
        /// Param 3: Onboard logging: 0: Ignore, 1: Start default rate logging, -1: Stop logging, > 1: start logging with rate of param 3 in Hz (e.g. set to 1000 for 1000 Hz logging)
        /// Param 4: Reserved
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        PreflightStorage = 245,

        /// <summary>
        /// Request the reboot or shutdown of system components
        /// Param 1: 0: Do nothing for autopilot, 1: Reboot autopilot, 2: Shutdown autopilot, 3: Reboot autopilot and keep it in the bootloader until upgraded
        /// Param 2: 0: Do nothing for onboard computer, 1: Reboot onboard computer, 2: Shutdown onboard computer, 3: Reboot onboard computer and keep it in the bootloader until upgraded
        /// Param 3: WIP: 0: Do nothing for camera, 1: Reboot onboard camera, 2: Shutdown onboard camera, 3: Reboot onboard camera and keep it in the bootloader until upgraded
        /// Param 4: WIP: 0: Do nothing for mount (e.g. gimbal), 1: Reboot mount, 2: Shutdown mount, 3: Reboot mount and keep it in the bootloader until upgraded
        /// Param 5: Reserved, send 0
        /// Param 6: Reserved, send 0
        /// Param 7: WIP: id (e.g. camera id -1 for all ids)
        /// </summary>
        PreflightRebootShutdown = 246,

        /// <summary>
        /// Hold / continue the current action
        /// Param 1: MAV_GOTO_DO_HOLD: hold MAV_GOTO_DO_CONTINUE: continue with next item in mission plan
        /// Param 2: MAV_GOTO_HOLD_AT_CURRENT_POSITION: Hold at current position MAV_GOTO_HOLD_AT_SPECIFIED_POSITION: hold at specified position
        /// Param 3: MAV_FRAME coordinate frame of hold point
        /// Param 4: Desired yaw angle in degrees
        /// Param 5: Latitude / X position
        /// Param 6: Longitude / Y position
        /// Param 7: Altitude / Z position
        /// </summary>
        OverrideGoto = 252,

        /// <summary>
        /// Start running a mission
        /// Param 1: First_item: the first mission item to run
        /// Param 2: Last_item:  the last mission item to run (after this item is run, the mission ends)
        /// </summary>
        MissionStart = 300,

        /// <summary>
        /// Arms / Disarms a component
        /// Param 1: 1 to arm, 0 to disarm
        /// </summary>
        ComponentArmDisarm = 400,

        /// <summary>
        /// Request the home position from the vehicle
        /// Param 1: Reserved
        /// Param 2: Reserved
        /// Param 3: Reserved
        /// Param 4: Reserved
        /// Param 5: Reserved
        /// Param 6: Reserved
        /// Param 7: Reserved
        /// </summary>
        GetHomePosition = 410,

        /// <summary>
        /// Starts receiver pairing
        /// Param 1: 0: Spektrum
        /// Param 2: 0: Spektrum DSM2, 1: Spektrum DSMX
        /// </summary>
        StartRxPair = 500,

        /// <summary>
        /// Request the interval between messages for a particular MAVLink message id
        /// Param 1: The MAVLink message id
        /// </summary>
        GetMessageInterval = 510,

        /// <summary>
        /// Request the interval between messages for a particular MAVLink message id. This interface replaces REQUEST_DATA_STREAM
        /// Param 1:The MAVLink message id
        /// Param 2: The interval between two messages, in microseconds. Set to -1 to disable and 0 to request default rate
        /// </summary>
        SetMessageInterval = 511,

        /// <summary>
        /// Request autopilot capabilities
        /// Param 1: 1: Request autopilot version
        /// Param 2: Reserved (all remaining params)
        /// </summary>
        RequestAutopilotCapabilities = 520,

        /// <summary>
        /// WIP: Request camera information (CAMERA_INFORMATION)
        /// Param 1: 1: Request camera capabilities
        /// Param 2: Camera id
        /// Param 3: Reserved (all remaining params)
        /// </summary>
        RequestCameraInformation = 521,

        /// <summary>
        /// WIP: Request camera settings (CAMERA_SETTINGS)
        /// Param 1: 1: Request camera settings
        /// Param 2: Camera id
        /// Param 3: Reserved (all remaining params)
        /// </summary>
        RequestCameraSettings = 522,

        ///<summary> WIP: Set the camera settings part 1 (CAMERA_SETTINGS)
        /// Param 1: Camera id
        /// Param 2: Aperture (1/value)
        /// Param 3: Aperture locked (0: auto, 1: locked)
        /// Param 4: Shutter speed in s
        /// Param 5: Shutter speed locked (0: auto, 1: locked)
        /// Param 6: ISO sensitivity
        /// Param 7: ISO sensitivity locked (0: auto, 1: locked)
        /// </summary>
        SetCameraSettings1 = 523,

        /// <summary>
        /// WIP: Set the camera settings part 2 (CAMERA_SETTINGS)
        /// Param 1: Camera id
        /// Param 2: White balance locked (0: auto, 1: locked)
        /// Param 3: White balance (color temperature in K)
        /// Param 4: Reserved for camera mode id
        /// Param 5: Reserved for color mode id
        /// Param 6: Reserved for image format id
        /// Param 7: Reserved
        /// </summary>
        SetCameraSettings2 = 524,

        /// <summary>
        /// WIP: Request storage information (STORAGE_INFORMATION)
        /// Param 1: 1: Request storage information
        /// Param 1: Storage id
        /// Param 1: Reserved (all remaining params)
        /// </summary>
        RequestStorageInformation = 525,

        /// <summary>
        /// WIP: Format a storage medium
        /// Param 1: 1: Format storage
        /// Param 1: Storage id
        /// Param 1: Reserved (all remaining params)
        /// </summary>
        StorageFormat = 526,

        /// <summary>
        /// WIP: Request camera capture status (CAMERA_CAPTURE_STATUS)
        /// Param 1: 1: Request camera capture status
        /// Param 1: Camera id
        /// Param 1: Reserved (all remaining params)
        /// </summary>
        RequestCameraCaptureStatus = 527,

        /// <summary>
        /// WIP: Request flight information (FLIGHT_INFORMATION)
        /// Param 1: 1: Request flight information
        /// Param 1: Reserved (all remaining params)
        /// </summary>
        RequestFlightInformation = 528,

        /// <summary>
        /// Start image capture sequence
        /// Param 1: Duration between two consecutive pictures (in seconds)
        /// Param 1: Number of images to capture total - 0 for unlimited capture
        /// Param 1: Resolution in megapixels (0.3 for 640x480, 1.3 for 1280x720, etc), set to 0 if param 4/5 are used
        /// Param 1: WIP: Resolution horizontal in pixels
        /// Param 1: WIP: Resolution horizontal in pixels
        /// Param 1: WIP: Camera id
        /// </summary>
        ImageStartCapture = 2000,

        /// <summary>
        /// Stop image capture sequence
        /// Param 1: Camera id
        /// Param 1: Reserved
        /// </summary>
        ImageStopCapture = 2001,

        /// <summary>
        /// Enable or disable on-board camera triggering system
        /// Param 1: Trigger enable/disable (0 for disable, 1 for start)
        /// Param 2: Shutter integration time (in ms)
        /// Param 3: Reserved
        /// </summary>
        DoTriggerControl = 2003,

        /// <summary>
        /// Starts video capture
        /// Param 1: Camera id (0 for all cameras), 1 for first, 2 for second, etc.
        /// Param 2: Frames per second
        /// Param 3: Resolution in megapixels (0.3 for 640x480, 1.3 for 1280x720, etc), set to 0 if param 4/5 are used
        /// Param 4: WIP: Resolution horizontal in pixels
        /// Param 5: WIP: Resolution horizontal in pixels
        /// </summary>
        VideoStartCapture = 2500,

        /// <summary>
        /// Stop the current video capture
        /// Param 1: WIP: Camera id
        /// Param 2: Reserved
        /// </summary>
        VideoStopCapture = 2501,

        /// <summary>
        /// Request to start streaming logging data over MAVLink (see also LOGGING_DATA message)
        /// Param 1: Format: 0: ULog
        /// Param 2: Reserved (set to 0)
        /// Param 3: Reserved (set to 0)
        /// Param 4: Reserved (set to 0)
        /// Param 5: Reserved (set to 0)
        /// Param 6: Reserved (set to 0)
        /// Param 7: Reserved (set to 0)
        /// </summary>
        LoggingStart = 2510,

        /// <summary>
        /// Request to stop streaming log data over MAVLink
        /// Param 1: Reserved (set to 0)
        /// Param 2: Reserved (set to 0)
        /// Param 3: Reserved (set to 0)
        /// Param 4: Reserved (set to 0)
        /// Param 5: Reserved (set to 0)
        /// Param 6: Reserved (set to 0)
        /// Param 7: Reserved (set to 0)
        /// </summary>
        LoggingStop = 2511,

        /// <summary>
        /// Param 1: Landing gear id (default: 0, -1 for all)
        /// Param 2: Landing gear position (Down: 0, Up: 1, NAN for no change)
        /// Param 3: Reserved, set to NAN
        /// Param 4: Reserved, set to NAN
        /// Param 5: Reserved, set to NAN
        /// Param 6: Reserved, set to NAN
        /// Param 7: Reserved, set to NAN
        /// </summary>
        AirframeConfiguration = 2520,

        /// <summary>
        /// Create a panorama at the current position
        /// Param 1: Viewing angle horizontal of the panorama (in degrees, +- 0.5 the total angle)
        /// Param 2: Viewing angle vertical of panorama (in degrees)
        /// Param 3: Speed of the horizontal rotation (in degrees per second)
        /// Param 4: Speed of the vertical rotation (in degrees per second)
        /// </summary>
        PanoramaCreate = 2800,

        /// <summary>
        /// Request VTOL transition
        /// Param 1: The target VTOL state, as defined by ENUM MAV_VTOL_STATE. Only MAV_VTOL_STATE_MC and MAV_VTOL_STATE_FW can be used
        /// </summary>
        DoVtolTransition = 3000,

        /// <summary>
        /// This command sets the submode to standard guided when vehicle is in guided mode.
        /// The vehicle holds position and altitude and the user can input the desired velocites along all three axes
        /// </summary>
        SetGuidedSubmodeStandard = 4000,

        /// <summary>
        /// This command sets submode circle when vehicle is in guided mode. Vehicle flies along a circle facing the center of the circle.
        /// The user can input the velocity along the circle and change the radius. If no input is given the vehicle will hold position
        /// Param 1: Radius of desired circle in CIRCLE_MODE
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: Unscaled target latitude of center of circle in CIRCLE_MODE
        /// Param 6: Unscaled target longitude of center of circle in CIRCLE_MODE
        /// </summary>
        SetGuidedSubmodeCircle = 4001,

        /// <summary>
        /// Deploy payload on a Lat / Lon / Alt position. This includes the navigation to reach the required release position and velocity
        /// Param 1: Operation mode. 0: prepare single payload deploy (overwriting previous requests), but do not execute it.
        /// 1: execute payload deploy immediately (rejecting further deploy commands during execution, but allowing abort).
        /// 2: add payload deploy to existing deployment list
        /// Param 2: Desired approach vector in degrees compass heading (0..360). A negative value indicates the system can define the approach vector at will
        /// Param 3: Desired ground speed at release time. This can be overriden by the airframe in case it needs to meet minimum airspeed. A negative value indicates the system can define the ground speed at will
        /// Param 4: Minimum altitude clearance to the release position in meters. A negative value indicates the system can define the clearance at will
        /// Param 5: Latitude unscaled for MISSION_ITEM or in 1e7 degrees for MISSION_ITEM_INT
        /// Param 6: Longitude unscaled for MISSION_ITEM or in 1e7 degrees for MISSION_ITEM_INT
        /// Param 7: Altitude, in meters AMSL
        /// </summary>
        PayloadPrepareDeploy = 30001,

        /// <summary>
        /// Control the payload deployment
        /// Param 1: Operation mode. 0: Abort deployment, continue normal mission. 1: switch to payload deploment mode. 100: delete first payload deployment request. 101: delete all payload deployment requests
        /// Param 2: Reserved
        /// Param 3: Reserved
        /// Param 4: Reserved
        /// Param 5: Reserved
        /// Param 6: Reserved
        /// Param 7: Reserved
        /// </summary>
        PayloadControlDeploy = 30002,

        /// <summary>
        /// User defined waypoint item. Ground Station will show the Vehicle as flying through this item
        /// Param 1: User defined
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: Latitude unscaled
        /// Param 6: Longitude unscaled
        /// Param 7: Altitude, in meters AMSL
        /// </summary>
        WaypointUser1 = 31000,

        /// <summary>
        /// User defined waypoint item. Ground Station will show the Vehicle as flying through this item
        /// Param 1: User defined
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: Latitude unscaled
        /// Param 6: Longitude unscaled
        /// Param 7: Altitude, in meters AMSL
        /// </summary>
        WaypointUser2 = 31001,

        /// <summary>
        /// User defined waypoint item. Ground Station will show the Vehicle as flying through this item
        /// Param 1: User defined
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: Latitude unscaled
        /// Param 6: Longitude unscaled
        /// Param 7: Altitude, in meters AMSL
        /// </summary>
        WaypointUser3 = 31002,

        /// <summary>
        /// User defined waypoint item. Ground Station will show the Vehicle as flying through this item
        /// Param 1: User defined
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: Latitude unscaled
        /// Param 6: Longitude unscaled
        /// Param 7: Altitude, in meters AMSL
        /// </summary>
        WaypointUser4 = 31003,

        /// <summary>
        /// User defined waypoint item. Ground Station will show the Vehicle as flying through this item
        /// Param 1: User defined
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: Latitude unscaled
        /// Param 6: Longitude unscaled
        /// Param 7: Altitude, in meters AMSL
        /// </summary>
        WaypointUser5 = 31004,

        /// <summary>
        /// User defined spatial item. Ground Station will not show the Vehicle as flying through this item. Example: ROI item
        /// Param 1: User defined
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: Latitude unscaled
        /// Param 6: Longitude unscaled
        /// Param 7: Altitude, in meters AMSL
        /// </summary>
        SpatialUser1 = 31005,

        /// <summary>
        /// User defined spatial item. Ground Station will not show the Vehicle as flying through this item. Example: ROI item
        /// Param 1: User defined
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: Latitude unscaled
        /// Param 6: Longitude unscaled
        /// Param 7: Altitude, in meters AMSL
        /// </summary>
        SpatialUser2 = 31006,

        /// <summary>
        /// User defined spatial item. Ground Station will not show the Vehicle as flying through this item. Example: ROI item
        /// Param 1: User defined
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: Latitude unscaled
        /// Param 6: Longitude unscaled
        /// Param 7: Altitude, in meters AMSL
        /// </summary>
        SpatialUser3 = 31007,

        /// <summary>
        /// User defined spatial item. Ground Station will not show the Vehicle as flying through this item. Example: ROI item
        /// Param 1: User defined
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: Latitude unscaled
        /// Param 6: Longitude unscaled
        /// Param 7: Altitude, in meters AMSL
        /// </summary>
        SpatialUser4 = 31008,

        /// <summary>
        /// User defined spatial item. Ground Station will not show the Vehicle as flying through this item. Example: ROI item
        /// Param 1: User defined
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: Latitude unscaled
        /// Param 6: Longitude unscaled
        /// Param 7: Altitude, in meters AMSL
        /// </summary>
        SpatialUser5 = 31009,

        /// <summary> User defined command. Ground Station will not show the Vehicle as flying through this item. Example: MAV_CMD_DO_SET_PARAMETER item
        /// Param 1: User defined
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: User defined
        /// Param 6: User defined
        /// Param 7: User defined
        /// </summary>
        User1 = 31010,

        /// <summary> User defined command. Ground Station will not show the Vehicle as flying through this item. Example: MAV_CMD_DO_SET_PARAMETER item
        /// Param 1: User defined
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: User defined
        /// Param 6: User defined
        /// Param 7: User defined
        /// </summary>
        User2 = 31011,

        /// <summary>
        /// User defined command. Ground Station will not show the Vehicle as flying through this item. Example: MAV_CMD_DO_SET_PARAMETER item
        /// Param 1: User defined
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: User defined
        /// Param 6: User defined
        /// Param 7: User defined
        /// </summary>
        User3 = 31012,

        /// <summary>
        /// User defined command. Ground Station will not show the Vehicle as flying through this item. Example: MAV_CMD_DO_SET_PARAMETER item
        /// Param 1: User defined
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: User defined
        /// Param 6: User defined
        /// Param 7: User defined
        /// </summary>
        User4 = 31013,

        /// <summary> User defined command. Ground Station will not show the Vehicle as flying through this item. Example: MAV_CMD_DO_SET_PARAMETER item
        /// Param 1: User defined
        /// Param 2: User defined
        /// Param 3: User defined
        /// Param 4: User defined
        /// Param 5: User defined
        /// Param 6: User defined
        /// Param 7: User defined
        /// </summary>
        User5 = 31014,

        /// <summary>
        /// A system wide power-off event has been initiated
        /// Param 1: Empty
        /// Param 1: Empty
        /// Param 1: Empty
        /// Param 1: Empty
        /// Param 1: Empty
        /// Param 1: Empty
        /// Param 1: Empty
        /// </summary>
        PowerOffInitiated = 42000,

        /// <summary>
        /// FLY button has been clicked
        /// Param 1: Empty
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        SoloBtnFlyClick = 42001,

        /// <summary>
        /// FLY button has been held for 1.5 seconds
        /// Param 1: Takeoff altitude
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        SoloBtnFlyHold = 42002,

        /// <summary>
        /// PAUSE button has been clicked
        /// Param 1: 1 if Solo is in a shot mode, 0 otherwise
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        SoloBtnPauseClick = 42003,

        /// <summary>
        /// Initiate a magnetometer calibration
        /// Param 1: uint8_t bitmask of magnetometers (0 means all)
        /// Param 2: Automatically retry on failure (0=no retry, 1=retry)
        /// Param 3: Save without user input (0=require input, 1=autosave)
        /// Param 4: Delay (seconds)
        /// Param 5: Autoreboot (0=user reboot, 1=autoreboot)
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoStartMagCal = 42424,

        /// <summary>
        /// Initiate a magnetometer calibration
        /// Param 1: uint8_t bitmask of magnetometers (0 means all)
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoAcceptMagCal = 42425,

        /// <summary>
        /// Cancel a running magnetometer calibration
        /// Param 1: uint8_t bitmask of magnetometers (0 means all)
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoCancelMagCal = 42426,

        /// <summary>
        /// Command autopilot to get into factory test/diagnostic mode
        /// Param 1: 0 means get out of test mode, 1 means get into test mode
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        SetFactoryTestMode = 42427,

        /// <summary>
        /// Reply with the version banner
        /// Param 1: Empty
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        DoSendBanner = 42428,

        /// <summary>
        /// Used when doing accelerometer calibration. When sent to the GCS tells it what position to put the vehicle in. When sent to the vehicle says what position the vehicle is in
        /// Param 1: Position, one of the ACCELCAL_VEHICLE_POS enum values
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        AccelcalVehiclePos = 42429,

        /// <summary>
        /// Causes the gimbal to reset and boot as if it was just powered on
        /// Param 1: Empty
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        GimbalReset = 42501,

        ///<summary>
        /// Reports progress and success or failure of gimbal axis calibration procedure
        /// Param 1: Gimbal axis we're reporting calibration progress for
        /// Param 2: Current calibration progress for this axis, 0x64=100%
        /// Param 3: Status of the calibration
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        GimbalAxisCalibrationStatus = 42502,

        ///<summary>
        /// Starts commutation calibration on the gimbal
        /// Param 1: Empty
        /// Param 2: Empty
        /// Param 3: Empty
        /// Param 4: Empty
        /// Param 5: Empty
        /// Param 6: Empty
        /// Param 7: Empty
        /// </summary>
        GimbalRequestAxisCalibration = 42503,

        /// <summary>
        /// Erases gimbal application and parameters
        /// Param 1: Magic number
        /// Param 2: Magic number
        /// Param 3: Magic number
        /// Param 4: Magic number
        /// Param 5: Magic number
        /// Param 6: Magic number
        /// Param 7: Magic number
        /// </summary>
        GimbalFullReset = 42505,

        ///<summary>
        /// </summary>
        EnumEnd = 42506,
    }
}