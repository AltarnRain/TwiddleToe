// <copyright file="IDeletable.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Interfaces.DataFlags
{
    /// <summary>
    /// Marks a class as deletable
    /// </summary>
    public interface IDeletable
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IDeletable"/> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        bool Deleted { get; set; }
    }
}
