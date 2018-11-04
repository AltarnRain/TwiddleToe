// <copyright file="SubscriberTestImplementation.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.TestClasses
{
    using TwiddleToe.Foundation.Interfaces;
    using TwiddleToe.Foundation.Models;

    /// <summary>
    /// Test implementation of the ISubscriber interface
    /// </summary>
    /// <seealso cref="TwiddleToe.Foundation.Interfaces.ISubscriber" />
    public class SubscriberTestImplementation : ISubscriber
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
