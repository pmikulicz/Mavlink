// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITypeInitializer.cs" company="Patryk Mikulicz">
//   Copyright (c) 2018 Patryk Mikulicz.
// </copyright>
// <summary>
//  Interface of a component responsible for creating instances of specified type
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Mavlink.Common
{
    /// <summary>
    /// Interface of a component responsible for creating instances of specified type
    /// </summary>
    internal interface IInstanceCreator
    {
        /// <summary>
        /// Creates new instance of specified type
        /// </summary>
        /// <typeparam name="TType">Type of instace to be created</typeparam>
        /// <returns>New instance of specified type</returns>
        TType Create<TType>();

        /// <summary>
        /// Creates new instances of specified base type
        /// </summary>
        /// <typeparam name="TBaseType">Base type of instace to be created</typeparam>
        /// <returns>Collection of new instances which derives of specified type</returns>
        IEnumerable<TBaseType> CreateDerived<TBaseType>();
    }
}