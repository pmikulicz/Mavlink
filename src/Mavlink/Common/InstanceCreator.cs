// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstanceCreator.cs" company="Patryk Mikulicz">
//   Copyright (c) 2018 Patryk Mikulicz.
// </copyright>
// <summary>
//   Represents component responsible for creating instances of specified type
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mavlink.Common
{
    /// <summary>
    ///  Represents component responsible for creating instances of specified type
    /// </summary>
    internal sealed class InstanceCreator : IInstanceCreator
    {
        /// <inheritdoc />
        public TType Create<TType>()
        {
            Type type = typeof(TType);
            return (TType)Activator.CreateInstance(type);
        }

        /// <inheritdoc />
        public IEnumerable<TBaseType> CreateDerived<TBaseType>()
        {
            Type baseClass = typeof(TBaseType);
            Assembly assembly = Assembly.GetAssembly(baseClass);
            IEnumerable<Type> allTypes = assembly.GetTypes()
                .Where(t =>
                    !t.IsAbstract &&
                    !t.IsInterface &&
                    t.IsClass &&
                    baseClass.IsAssignableFrom(t));

            foreach (Type type in allTypes)
            {
                yield return (TBaseType)Activator.CreateInstance(type);
            }
        }
    }
}