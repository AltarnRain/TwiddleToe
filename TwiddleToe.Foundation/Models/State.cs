// <copyright file="State.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The application state
    /// </summary>
    public class State
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
        /// Gets or sets the <see cref="object"/> with the specified property name.
        /// </summary>
        /// <value>
        /// The <see cref="object"/>.
        /// </value>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>The value of a property</returns>
        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
        }
    }
}
