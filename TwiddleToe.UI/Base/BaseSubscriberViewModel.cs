// <copyright file="BaseSubscriberViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Base
{
    using TwiddleToe.Foundation.Interfaces.StateFlags;
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// Base class for all view models that subscribe to state changes
    /// </summary>
    /// <seealso cref="TwiddleToe.Foundation.Interfaces.StateFlags.ISubscriber" />
    /// <seealso cref="TwiddleToe.UI.Base.BaseViewModel" />
    public abstract class BaseSubscriberViewModel : BaseViewModel, ISubscriber
    {
        /// <summary>
        /// The state provider
        /// </summary>
        protected readonly StateProvider stateProvider;

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
            this.UpdateViewModelState(stateProvider.Current);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="BaseSubscriberViewModel"/> class.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            this.stateProvider.Unsubscribe(this);
        }

        /// <summary>
        /// Called before updating the state. The view model inheriting from <see cref="BaseSubscriberViewModel"/>
        /// decides how to implement it.
        /// </summary>
        public abstract void PrepareForStateStateUpdate();

        /// <summary>
        /// Called after PreparingState. The view model inheriting from <see cref="BaseSubscriberViewModel"/>
        /// decides how to implement it.
        /// </summary>
        /// <param name="state">The state.</param>
        public abstract void HandleStateUpdate(State state);

        /// <summary>
        /// Dispatches the specified state.
        /// </summary>
        /// <param name="state">The state.</param>
        public void Dispatch(State state)
        {
            this.UpdateViewModelState(state);
        }

        /// <summary>
        /// Updates the state of the view model.
        /// </summary>
        /// <param name="state">The state.</param>
        private void UpdateViewModelState(State state)
        {
            this.PrepareForStateStateUpdate();
            this.HandleStateUpdate(state);
        }
    }
}
