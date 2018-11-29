// <copyright file="Column.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.StateDefinition
{
    using System.Xml.Serialization;

    /// <summary>
    /// The properties
    /// </summary>
    public class Column
    {
        /// <summary>
        /// Gets or sets the name of the column
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of this column
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [XmlAttribute]
        public StateTypes Type { get; set; }

        /// <summary>
        /// Gets or sets the link to another table.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        [XmlAttribute]
        public string Reference { get; set; }
    }
}