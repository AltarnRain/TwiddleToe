// <copyright file="StateProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.Providers
{
    using System.Collections.Generic;
    using TwiddleToe.Foundation.Interfaces;
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.Utilities.Factories;
    using TwiddleToe.Workers.FileHandlers;

    /// <summary>
    /// Provides the current state.
    /// </summary>
    public class StateProvider
    {
        /// <summary>
        /// The state
        /// </summary>
        private static State state;

        /// <summary>
        /// A list of classes implemting ISubscriber that will receive a cloned state each time the state is set.
        /// </summary>
        private readonly List<ISubscriber> subscribers;
        private readonly StateFileHandler stateFileHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvider" /> class.
        /// </summary>
        /// <param name="stateFileHandler">The state loader.</param>
        public StateProvider(StateFileHandler stateFileHandler)
        {
            state = stateFileHandler.Get();
            this.subscribers = new List<ISubscriber>();
            this.stateFileHandler = stateFileHandler;
        }

        /// <summary>
        /// Unsubscribes the specified subscriber.
        /// </summary>
        /// <param name="subscriber">The subscriber.</param>
        public void Unsubscribe(ISubscriber subscriber)
        {
            this.subscribers.Remove(subscriber);
        }

        /// <summary>
        /// Gets the <see cref="State"/>instance.
        /// </summary>
        /// <returns>The current state</returns>
        public State Get()
        {
            if (state == null)
            {
                state = new State();
            }

            // The state is immutable.
            return CloneFactory.MakeClone(state);
        }

        /// <summary>
        /// Sets the specified state.
        /// </summary>
        /// <param name="newState">The new state.</param>
        public void Set(State newState)
        {
            state = CloneFactory.MakeClone(newState);

            // Signal state subscribers the state has changed.
            this.DispatchUpdatedStateToSubscribers();
        }

        /// <summary>
        /// Subscribes the specified view model to changes in the state.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Subscribe(ISubscriber viewModel)
        {
            this.subscribers.Add(viewModel);
        }

        /// <summary>
        /// Flushes the content of the state to a file.
        /// </summary>
        public void Flush()
        {
            this.stateFileHandler.SaveStateToFile(state);
        }

        /// <summary>
        /// Dispatches the updated state to subscribers.
        /// </summary>
        private void DispatchUpdatedStateToSubscribers()
        {
            foreach (var subscriber in this.subscribers)
            {
                var clonedState = CloneFactory.MakeClone(state);
                subscriber.Dispatch(clonedState);
            }
        }
    }
}
