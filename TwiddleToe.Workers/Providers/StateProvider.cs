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
        /// A list of classes implemting ISubscriber that will receive a cloned state each time the state is set.
        /// </summary>
        private readonly List<ISubscriber> subscribers;

        /// <summary>
        /// The state file handler
        /// </summary>
        private readonly StateFileHandler stateFileHandler;

        /// <summary>
        /// The state
        /// </summary>
        private State state;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvider" /> class.
        /// </summary>
        /// <param name="stateFileHandler">The state loader.</param>
        public StateProvider(StateFileHandler stateFileHandler)
        {
            this.state = stateFileHandler.Get();
            this.subscribers = new List<ISubscriber>();
            this.stateFileHandler = stateFileHandler;
        }

        /// <summary>
        /// Gets or sets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public State Current
        {
            get
            {
                if (this.state == null)
                {
                    this.state = new State();
                }

                return CloneFactory.MakeClone(this.state);
            }

            set
            {
                this.state = CloneFactory.MakeClone(value);

                // Signal state subscribers the state has changed.
                this.DispatchUpdatedStateToSubscribers();
            }
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
            this.stateFileHandler.SaveStateToFile(this.state);
        }

        /// <summary>
        /// Dispatches the updated state to subscribers.
        /// </summary>
        private void DispatchUpdatedStateToSubscribers()
        {
            foreach (var subscriber in this.subscribers)
            {
                var clonedState = CloneFactory.MakeClone(this.state);
                subscriber.Dispatch(clonedState);
            }
        }
    }
}
