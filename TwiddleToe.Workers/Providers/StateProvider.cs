// <copyright file="StateProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.Providers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using TwiddleToe.Foundation.Interfaces.DataFlags;
    using TwiddleToe.Foundation.Interfaces.StateFlags;
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.Utilities.Extentions;
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

                return CloneState(this.state);
            }

            set
            {
                this.state = CloneState(value);

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
        /// Removes from state.
        /// </summary>
        /// <typeparam name="TRecord">The type of the record.</typeparam>
        /// <param name="model">The model.</param>
        public void RemoveFromState<TRecord>(TRecord model)
            where TRecord : BaseModel
        {
            if (string.IsNullOrWhiteSpace(model.Identity))
            {
                throw new InvalidDataException("Model does not have a set Identity property");
            }

            var pluralName = model.GetType().Name.ToPlural();

            if (this.state[pluralName] is List<TRecord> contents)
            {
                var record = contents.SingleOrDefault(r => r.Identity == model.Identity);

                if (record != null)
                {
                    if (record is IDeletable)
                    {
                        ((IDeletable)record).Deleted = true;
                    }
                    else
                    {
                        contents.Remove(model);
                    }

                    this.DispatchUpdatedStateToSubscribers();
                }
            }
        }

        /// <summary>
        /// Updates the specified current user.
        /// </summary>
        /// <typeparam name="TRecord">The type of the record.</typeparam>
        /// <param name="model">The model.</param>
        public void Update<TRecord>(TRecord model)
            where TRecord : BaseModel
        {
            if (string.IsNullOrWhiteSpace(model.Identity))
            {
                throw new InvalidDataException("Model does not have a set Identity property");
            }

            var pluralName = model.GetType().Name.ToPlural();

            if (this.state[pluralName] is List<TRecord> contents)
            {
                var record = contents.SingleOrDefault(r => r.Identity == model.Identity);

                if (record != null)
                {
                    contents.Remove(record);
                    contents.Add(model);
                    this.DispatchUpdatedStateToSubscribers();
                }
            }
        }

        /// <summary>
        /// Flushes the content of the state to a file.
        /// </summary>
        public void Flush()
        {
            this.stateFileHandler.SaveStateToFile(this.state);
        }

        /// <summary>
        /// Clones the state.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns>
        /// A cloned state
        /// </returns>
        private static State CloneState(State state)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(state);
            var clone = Newtonsoft.Json.JsonConvert.DeserializeObject<State>(json);
            return clone;
        }

        /// <summary>
        /// Dispatches the updated state to subscribers.
        /// </summary>
        private void DispatchUpdatedStateToSubscribers()
        {
            foreach (var subscriber in this.subscribers)
            {
                var clonedState = CloneState(this.state);
                subscriber.Dispatch(clonedState);
            }
        }
    }
}
