// <copyright file="Question.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Models
{
    using System;
    using TwiddleToe.Foundation.Interfaces;

    /// <summary>
    /// Model for a question
    /// </summary>
    public class Question : BaseModel, IDeletable
    {
        /// <summary>
        /// Gets or sets the question identifier.
        /// </summary>
        /// <value>
        /// The question identifier.
        /// </value>
        public int QuestionId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the answer.
        /// </summary>
        /// <value>
        /// The answer.
        /// </value>
        public string Answer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IDeletable" /> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        public bool Deleted { get; set; }
    }
}
