// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MavlinkModelReader.cs" company="Patryk Mikulicz">
//   Copyright (c) 2017 Patryk Mikulicz.
// </copyright>
// <summary>
//   Implementation of a component responsible for reading specified dialect of mavlink messages
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mavlink.Generator.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using MavlinkModel = Mavlink.Generator.Model.Mavlink;

namespace Mavlink.Generator
{
    /// <summary>
    ///  Implementation of a component responsible for reading specified dialect of mavlink messages
    /// </summary>
    internal sealed class MavlinkModelReader : IMavlinkModelReader
    {
        /// <inheritdoc />
        public IEnumerable<MavlinkModel> Read(string pathToXmls, DialectType dialect)
        {
            if (pathToXmls == null)
                throw new ArgumentNullException(nameof(pathToXmls));

            MavlinkModel rootMavlink = ProcessRead(pathToXmls, dialect);

            yield return rootMavlink;

            foreach (var includedDialect in rootMavlink.IncludeDialects)
                yield return ProcessRead(pathToXmls, includedDialect);
        }

        private static MavlinkModel ProcessRead(string pathToXmls, DialectType dialect)
        {
            Type enumType = dialect.GetType();
            MemberInfo memberInfo = enumType.GetMember(dialect.ToString()).FirstOrDefault();

            if (memberInfo == null)
                throw new InvalidOperationException($"Cannot get member info for field '{dialect}' and type '{enumType.Name}'");

            XmlEnumAttribute xmlEnumAttribute = (XmlEnumAttribute)memberInfo.GetCustomAttributes(typeof(XmlEnumAttribute), false).FirstOrDefault();

            if (xmlEnumAttribute == null)
                throw new InvalidOperationException($"Cannot get file name of dialet '{dialect}' from xml enum attribute name");

            XmlSerializer serializer = new XmlSerializer(typeof(Model.Mavlink));

            return (MavlinkModel)serializer.Deserialize(File.Open(Path.Combine(pathToXmls, xmlEnumAttribute.Name), FileMode.Open));
        }
    }
}