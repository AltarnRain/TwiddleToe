// <copyright file="StateProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.Providers
{
    using System.Collections.Generic;
    using System.Diagnostics;
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

        private enum ManipulationActions
        {
            Add,
            Remove,
            Update
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
        public void Remove<TRecord>(TRecord model)
            where TRecord : BaseModel
        {
            this.ManipulateState(model, ManipulationActions.Remove);
        }

        /// <summary>
        /// Adds to state.
        /// </summary>
        /// <typeparam name="TRecord">The type of the record.</typeparam>
        /// <param name="model">The model.</param>
        public void Add<TRecord>(TRecord model)
             where TRecord : BaseModel
        {
            this.ManipulateState(model, ManipulationActions.Add);
        }

        /// <summary>
        /// Updates the specified current user.
        /// </summary>
        /// <typeparam name="TRecord">The type of the record.</typeparam>
        /// <param name="model">The model.</param>
        public void Update<TRecord>(TRecord model)
            where TRecord : BaseModel
        {
            this.ManipulateState(model, ManipulationActions.Update);
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

        private void ManipulateState<TRecord>(TRecord model, ManipulationActions action)
            where TRecord : BaseModel
        {
            if (string.IsNullOrWhiteSpace(model.Identity))
            {
                throw new InvalidDataException("Model does not have a set Identity property");
            }

            var pluralName = model.GetType().Name.ToPlural();

            if (this.state[pluralName] is List<TRecord> contents)
            {
                TRecord record;
                switch (action)
                {
                    case ManipulationActions.Add:

                        contents.Add(model);
                        break;

                    case ManipulationActions.Remove:
                        record = contents.SingleOrDefault(r => r.Identity == model.Identity);

                        if (record is IDeletable)
                        {
                            ((IDeletable)record).Deleted = true;
                        }
                        else
                        {
                            contents.Remove(model);
                        }

                        break;

                    case ManipulationActions.Update:
                        record = contents.SingleOrDefault(r => r.Identity == model.Identity);

                        if (record != null)
                        {
                            contents.Remove(record);
                            contents.Add(model);
                        }

                        break;

                    default:
                        Debugger.Break();
                        break;
                }

                this.DispatchUpdatedStateToSubscribers();
            }
        }
    }
}
