// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageMetadataProvider.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Component which is responsible for providing mavlink message metadata
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    /// Component which is responsible for providing mavlink message metadata
    /// </summary>
    internal interface IMessageMetadataProvider
    {
        /// <summary>
        /// Provides mavlink message metadata
        /// </summary>
        /// <returns></returns>
        MessageMetadata Provide();
    }
}