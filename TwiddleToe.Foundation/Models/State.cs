// <copyright file="State.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Models
{
    using System;
    using System.Collections.Generic;
    using TwiddleToe.Utilities.Factories;

    /// <summary>
    /// The application state
    /// </summary>
    public class State : ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="State"/> class.
        /// </summary>
        public State()
        {
            this.Users = new List<User>();
            this.Subjects = new List<Subject>();
            this.Questionaires = new List<Questionaire>();
            this.QuestionareHistories = new List<QuestionareHistory>();
            this.Questions = new List<Question>();
        }

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

        /// <summary>
        /// Makes the clone.
        /// </summary>
        /// <returns>
        /// A copy of the inheriting class
        /// </returns>
        public object Clone()
        {
            var users = CloneFactory.MakeClone(this.Users);
            var subjects = CloneFactory.MakeClone(this.Subjects);
            var questions = CloneFactory.MakeClone(this.Questions);
            var questionaireHistories = CloneFactory.MakeClone(this.QuestionareHistories);
            var questionaires = CloneFactory.MakeClone(this.Questionaires);

            return new State
            {
                CurrentId = this.CurrentId,
                QuestionareHistories = questionaireHistories,
                Questionaires = questionaires,
                Questions = questions,
                Subjects = subjects,
                Users = users,
            };
        }
    }
}
