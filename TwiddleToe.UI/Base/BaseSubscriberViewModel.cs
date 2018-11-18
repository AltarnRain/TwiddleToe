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
        /// Initializes a new instance of the <see cref="BaseSubscriberViewModel" /> class.
        /// </summary>
        /// <param name="stateProvider">The state provider.</param>
        /// <param name="viewModelRegistry">The view model registry.</param>
        public BaseSubscriberViewModel(StateProvider stateProvider, ViewModelRegistry viewModelRegistry)
            : base(viewModelRegistry, stateProvider)
        {
            this.StateProvider = stateProvider;
            this.StateProvider.Subscribe(this);
            this.UpdateViewModelState(stateProvider.Current);
        }

        /// <summary>
        /// Gets state provider
        /// </summary>
        protected StateProvider StateProvider { get; private set; }

        /// <summary>
        /// Finalizes an instance of the <see cref="BaseSubscriberViewModel"/> class.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
            this.StateProvider.Unsubscribe(this);
        }

        /// <summary>
        /// Dispatches the specified state.
        /// </summary>
        /// <param name="state">The state.</param>
        public void Dispatch(State state)
        {
            this.UpdateViewModelState(state);
        }

        /// <summary>
        /// Called before updating the state. The view model inheriting from <see cref="BaseSubscriberViewModel"/>
        /// decides how to implement it.
        /// </summary>
        protected abstract void PrepareForStateStateUpdate();

        /// <summary>
        /// Called after PreparingState. The view model inheriting from <see cref="BaseSubscriberViewModel"/>
        /// decides how to implement it.
        /// </summary>
        /// <param name="state">The state.</param>
        protected abstract void HandleStateUpdate(State state);

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
