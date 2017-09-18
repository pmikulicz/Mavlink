// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPropertyConfigurator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Interface of component which allows to configure property metadata of a mavlink message
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mavlink.Messages.Configuration
{
    /// <summary>
    /// Interface of component which allows to configure property metadata of a mavlink message
    /// </summary>
    public interface IPropertyMetadataConfigurator
    {
        /// <summary>
        /// Sets property name of a message
        /// </summary>
        /// <param name="name">Name to be set</param>
        /// <returns>Instance of property metadata configurator for fluet api</returns>
        IPropertyMetadataConfigurator SetName(string name);

        /// <summary>
        /// Sets property order of a message
        /// </summary>
        /// <param name="order">Order number to be set. Order number should start with 1 and can not be negative number</param>
        /// <returns>Instance of property metadata  configurator for fluet api</returns>
        IPropertyMetadataConfigurator SetOrder(int order);

        /// <summary>
        /// Sets property size of a message. Size must be greater than zero.
        /// If size is greater than default size of property type it means that it is an array of this type
        /// </summary>
        /// <param name="size">Size to be set</param>
        /// <returns>Instance of property metadata configurator for fluet api</returns>
        IPropertyMetadataConfigurator SetSize(int size);
    }
}