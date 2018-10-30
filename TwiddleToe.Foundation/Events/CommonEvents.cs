// <copyright file="CommonEvents.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Events
{
    using TwiddleToe.Foundation.Models;

    /// <summary>
    /// A request to close delegate
    /// </summary>
    public delegate void RequestClose();

    /// <summary>
    /// A delegate that dispatches the state
    /// </summary>
    /// <param name="state">The state.</param>
    public delegate void DispatchState(State state);
}
