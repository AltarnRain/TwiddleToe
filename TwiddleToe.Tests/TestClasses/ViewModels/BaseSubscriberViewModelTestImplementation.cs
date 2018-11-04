// <copyright file="BaseSubscriberViewModelTestImplementation.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.TestClasses
{
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.Base;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// Test implementation for the BaseSubscriberViewModel
    /// </summary>
    /// <seealso cref="TwiddleToe.UI.Base.BaseSubscriberViewModel" />
    public class BaseSubscriberViewModelTestImplementation : BaseSubscriberViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSubscriberViewModelTestImplementation"/> class.
        /// </summary>
        /// <param name="stateProvider">The state provider.</param>
        /// <param name="viewModelRegistry">The view model registry.</param>
        public BaseSubscriberViewModelTestImplementation(StateProvider stateProvider, ViewModelRegistry viewModelRegistry)
            : base(stateProvider, viewModelRegistry)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether [state updated].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [state updated]; otherwise, <c>false</c>.
        /// </value>
        public bool StateUpdated { get; set; }

        /// <summary>
        /// Called when the state updates.
        /// </summary>
        /// <param name="state">The state.</param>
        public override void HandleStateUpdate(State state)
        {
            this.StateUpdated = true;
        }

        /// <summary>
        /// Called before updating the state. The view model inheriting from <see cref="T:TwiddleToe.UI.Base.BaseSubscriberViewModel" />
        /// decides how to implement it.
        /// </summary>
        public override void PrepareForStateStateUpdate()
        {
            this.StateUpdated = false;
        }
    }
}
