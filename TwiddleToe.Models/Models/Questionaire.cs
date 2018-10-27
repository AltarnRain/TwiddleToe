// <copyright file="Questionaire.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Models.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// A list of questions
    /// </summary>
    public class Questionaire
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
    }
}
