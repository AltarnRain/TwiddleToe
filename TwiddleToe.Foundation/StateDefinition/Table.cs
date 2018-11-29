// <copyright file="Table.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.StateDefinition
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// A state item.
    /// </summary>
    public class Table
    {
        /// <summary>
        /// Gets or sets the name of the state item.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the columns for a table.
        /// </summary>
        /// <value>
        /// The state item properties.
        /// </value>
        public List<Column> Columns { get; set; }
    }
}