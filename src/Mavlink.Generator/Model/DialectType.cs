// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DialectType.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Defines dialects of mavlink messages
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Xml.Serialization;

namespace Mavlink.Generator.Model
{
    /// <summary>
    /// Defines dialects of mavlink messages
    /// </summary>
    public enum DialectType
    {
        /// <summary>
        /// Used for the ASLUAV fixed-wing autopilot (www.asl.ethz.ch),
        /// which implements extensions to the Pixhawk (www.pixhawk.org) autopilot
        /// </summary>
        [XmlEnum("ASLUAV.xml")]
        Asluav = 0,

        /// <summary>
        /// Used for Ardupilot controllers (http://ardupilot.org/)
        /// </summary>
        [XmlEnum("ardupilotmega.xml")]
        Ardupilotmega = 1,

        /// <summary>
        /// Used for AutoQuad flightcontroller (http://autoquad.org/)
        /// </summary>
        [XmlEnum("autoquad.xml")]
        Autoquad,

        /// <summary>
        /// Used for the basic message set
        /// </summary>
        [XmlEnum("common.xml")]
        Common,

        /// <summary>
        /// Used for MatrixPilot / UAV Dev Board (https://github.com/MatrixPilot/MatrixPilot/wiki)
        /// </summary>
        [XmlEnum("matrixpilot.xml")]
        Matrixpilot,

        /// <summary>
        /// Used for the minimal message set
        /// </summary>
        [XmlEnum("minimal.xml")]
        Minimal,

        /// <summary>
        /// Used for Paparazzi UAV (http://paparazziuav.org)
        /// </summary>
        [XmlEnum("paparazzi.xml")]
        Paparazzi,

        /// <summary>
        /// Used for Santa Cruz Low-cost UAV GNC System (https://slugsuav.soe.ucsc.edu/)
        /// </summary>
        [XmlEnum("slugs.xml")]
        Slugs,

        /// <summary>
        /// Used as a standard basic message set
        /// </summary>
        [XmlEnum("standard.xml")]
        Standard,

        /// <summary>
        /// Used for uAvionix systems (https://www.uavionix.com/)
        /// </summary>
        [XmlEnum("uAvionix.xml")]
        UAvionix,

        /// <summary>
        /// Used for Unmanned Aerial System (UAS) (https://www.mece.engineering.ualberta.ca/en/Research/ResearchGroups/UnmannedAerialSystems.aspx)
        /// </summary>
        [XmlEnum("ualberta.xml")]
        Ualberta
    }
}