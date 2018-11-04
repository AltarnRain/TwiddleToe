// <copyright file="BaseModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Models
{
    /// <summary>
    /// Base model for all models.
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Gets or sets the identity.
        /// </summary>
        /// <value>
        /// The identity.
        /// </value>
        public string Identity { get; set; }
    }
}
