// <copyright file="State.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using TwiddleToe.Utilities;

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
            this.Users = new ObservableCollection<User>();
            this.Subjects = new ObservableCollection<Subject>();
            this.Questionaires = new ObservableCollection<Questionaire>();
            this.QuestionareHistories = new ObservableCollection<QuestionareHistory>();
            this.Questions = new ObservableCollection<Question>();
        }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public ObservableCollection<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the subjects.
        /// </summary>
        /// <value>
        /// The subjects.
        /// </value>
        public ObservableCollection<Subject> Subjects { get; set; }

        /// <summary>
        /// Gets or sets the questions.
        /// </summary>
        /// <value>
        /// The questions.
        /// </value>
        public ObservableCollection<Question> Questions { get; set; }

        /// <summary>
        /// Gets or sets the history.
        /// </summary>
        /// <value>
        /// The history.
        /// </value>
        public ObservableCollection<QuestionareHistory> QuestionareHistories { get; set; }

        /// <summary>
        /// Gets or sets the questionaires.
        /// </summary>
        /// <value>
        /// The questionaires.
        /// </value>
        public ObservableCollection<Questionaire> Questionaires { get; set; }

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
