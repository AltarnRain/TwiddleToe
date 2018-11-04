// <copyright file="Questionaire.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Models
{
    using System.Collections.Generic;
    using TwiddleToe.Foundation.Interfaces;

    /// <summary>
    /// A list of questions
    /// </summary>
    public class Questionaire : BaseModel, IDeletable
    {
        /// <summary>
        /// Gets or sets the question ids.
        /// </summary>
        /// <value>
        /// The question ids.
        /// </value>
        public List<string> Questions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IDeletable" /> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        public bool Deleted { get; set; }
    }
}
