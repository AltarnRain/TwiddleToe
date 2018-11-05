// <copyright file="InputResult.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Models
{
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
        public string Input { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [user accepted].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [user accepted]; otherwise, <c>false</c>.
        /// </value>
        public bool UserAccepted { get; set; }
    }
}