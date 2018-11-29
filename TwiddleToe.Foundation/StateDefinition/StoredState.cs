// <copyright file="StoredState.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.StateDefinition
{
    using System.Collections.Generic;

    /// <summary>
    /// Top level definition for the state
    /// </summary>
    public class StoredState
    {
        /// <summary>
        /// Gets or sets the state Tables.
        /// </summary>
        /// <value>
        /// The state items.
        /// </value>
        public List<Table> Tables { get; set; }
    }
}