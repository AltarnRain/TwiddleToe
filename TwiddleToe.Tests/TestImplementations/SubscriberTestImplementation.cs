// <copyright file="SubscriberTestImplementation.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.TestImplementations
{
    using TwiddleToe.Foundation.Interfaces.StateFlags;
    using TwiddleToe.Foundation.Models;

    /// <summary>
    /// Test implementation of the ISubscriber interface
    /// </summary>
    /// <seealso cref="ISubscriber" />
    internal class SubscriberTestImplementation : ISubscriber
    {
        /// <summary>
        /// Gets or sets a value indicating whether [state updated].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [state updated]; otherwise, <c>false</c>.
        /// </value>
        public bool StateUpdated { get; set; }

        /// <summary>
        /// Dispatches the specified state.
        /// </summary>
        /// <param name="state">The state.</param>
        public void Dispatch(State state)
        {
            this.StateUpdated = true;
        }
    }
}
