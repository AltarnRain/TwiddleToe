// <copyright file="ISubscriber.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Interfaces
{
    using TwiddleToe.Foundation.Models;

    /// <summary>
    /// Describes a method that dispatches an updated state
    /// </summary>
    public interface ISubscriber
    {
        /// <summary>
        /// Dispatches the specified state.
        /// </summary>
        /// <param name="state">The state.</param>
        void Dispatch(State state);
    }
}
