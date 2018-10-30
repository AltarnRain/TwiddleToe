// <copyright file="Questionaire.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A list of questions
    /// </summary>
    public class Questionaire : ICloneable
    {
        /// <summary>
        /// Gets or sets the questionaire identifier.
        /// </summary>
        /// <value>
        /// The questionaire identifier.
        /// </value>
        public int QuestionaireId { get; set; }

        /// <summary>
        /// Gets or sets the question ids.
        /// </summary>
        /// <value>
        /// The question ids.
        /// </value>
        public List<int> Questions { get; set; }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return new Questionaire
            {
                QuestionaireId = this.QuestionaireId,
                Questions = this.Questions.ToList(),
            };
        }
    }
}
