// <copyright file="State.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Models.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The application state
    /// </summary>
    public class State
    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public List<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the subjects.
        /// </summary>
        /// <value>
        /// The subjects.
        /// </value>
        public List<Subject> Subjects { get; set; }

        /// <summary>
        /// Gets or sets the questions.
        /// </summary>
        /// <value>
        /// The questions.
        /// </value>
        public List<Question> Questions { get; set; }

        /// <summary>
        /// Gets or sets the history.
        /// </summary>
        /// <value>
        /// The history.
        /// </value>
        public List<QuestionareHistory> QuestionareHistories { get; set; }

        /// <summary>
        /// Gets or sets the questionaires.
        /// </summary>
        /// <value>
        /// The questionaires.
        /// </value>
        public List<Questionaire> Questionaires { get; set; }

        /// <summary>
        /// Gets or sets the current identifier.
        /// Used to provide unique Ids to other classes.
        /// </summary>
        /// <value>
        /// The current identifier.
        /// </value>
        public int CurrentId { get; set; }
    }
}
