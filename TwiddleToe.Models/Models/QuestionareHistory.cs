// <copyright file="QuestionareHistory.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Models.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A history record for a taken questionary
    /// </summary>
    public class QuestionareHistory
    {
        /// <summary>
        /// Gets or sets the questionare identifier.
        /// </summary>
        /// <value>
        /// The questionare identifier.
        /// </value>
        public int? QuestionareId { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the correct answers.
        /// </summary>
        /// <value>
        /// The correct answers.
        /// </value>
        public List<int> CorrectAnswers { get; set; }

        /// <summary>
        /// Gets or sets the wrong answers.
        /// </summary>
        /// <value>
        /// The wrong answers.
        /// </value>
        public List<int> WrongAnswers { get; set; }

        /// <summary>
        /// Gets or sets the date taken.
        /// </summary>
        /// <value>
        /// The date taken.
        /// </value>
        public DateTime DateTaken { get; set; }
    }
}