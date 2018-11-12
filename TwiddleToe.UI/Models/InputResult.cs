// <copyright file="InputResult.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Models
{
    using System.Collections.Generic;
    using TwiddleToe.UI.Interfaces.Input;
    using TwiddleToe.UI.Interfaces.Input.API;

    /// <summary>
    /// The result of a generic input
    /// </summary>
    public class InputResult
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public IList<IGenericInput> Input { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [user accepted].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [user accepted]; otherwise, <c>false</c>.
        /// </value>
        public bool UserAccepted { get; set; }
    }
}