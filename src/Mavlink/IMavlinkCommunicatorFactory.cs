// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMavlinkCommunicatorFactory.cs" company="Patryk Mikulicz">
//   Copyright (c) 2016 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of component which is responsible for creating new instance of mavlink communicator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.IO;

namespace Mavlink
{
    /// <summary>
    /// Interface of component which is responsible for creating new instance of mavlink communicator
    /// </summary>
    public interface IMavlinkCommunicatorFactory
    {
        /// <summary>
        /// Creates new instance of mavlink communicator
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        IMavlinkCommunicator Create(Stream stream);
    }
}