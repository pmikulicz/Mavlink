// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageConfiguration.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of a component which is responsible for configuring mavlink message
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    /// Interface of a component which is responsible for configuring mavlink message
    /// </summary>
    internal interface IMessageConfiguration
    {
        /// <summary>
        /// Configures mavlink message
        /// </summary>
         void Configure();
    }
}