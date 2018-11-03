// <copyright file="BaseSubscriberViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Base
{
    using TwiddleToe.Foundation.Interfaces;
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// Base class for all view models that subscribe to state changes
    /// </summary>
    /// <seealso cref="TwiddleToe.UI.Base.BaseViewModel" />
    /// <seealso cref="TwiddleToe.Foundation.Interfaces.ISubscriber" />
    public abstract class BaseSubscriberViewModel : BaseViewModel, ISubscriber
    {
        private readonly StateProvider stateProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSubscriberViewModel" /> class.
        /// </summary>
        /// <param name="stateProvider">The state provider.</param>
        /// <param name="viewModelRegistry">The view model registry.</param>
        public BaseSubscriberViewModel(StateProvider stateProvider, ViewModelRegistry viewModelRegistry)
            : base(viewModelRegistry, stateProvider)
        {
            this.stateProvider = stateProvider;
            this.stateProvider.Subscribe(this);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="BaseSubscriberViewModel"/> class.
        /// </summary>
        ~BaseSubscriberViewModel()
        {
            this.stateProvider.Unsubscribe(this);
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
