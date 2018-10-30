// <copyright file="BaseViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Base
{
    using System;
    using System.ComponentModel;
    using TwiddleToe.Foundation.Events;
    using TwiddleToe.Foundation.Interfaces;
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// Base view model for all view models.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class BaseViewModel : INotifyPropertyChanged, IBaseViewModel
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly string identifier;

        /// <summary>
        /// The state provider
        /// </summary>
        private readonly StateProvider stateProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        /// <param name="stateProvider">The state provider.</param>
        public BaseViewModel(StateProvider stateProvider)
        {
            this.stateProvider = stateProvider;
            this.stateProvider.Subscribe(this);

            this.identifier = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        ~BaseViewModel()
        {
            this.stateProvider.Unsubscribe(this);
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Occurs when [on request close].
        /// </summary>
        public event RequestClose OnRequestClose;

        /// <summary>
        /// Closes the view.
        /// </summary>
        public void CloseView()
        {
            this.OnRequestClose?.Invoke();
        }

        /// <summary>
        /// States the update.
        /// </summary>
        /// <param name="state">The state.</param>
        public abstract void StateUpdate(State state);

        /// <summary>
        /// Dispatches the specified state.
        /// </summary>
        /// <param name="state">The state.</param>
        public void Dispatch(State state)
        {
            this.StateUpdate(state);
        }
    }
}
