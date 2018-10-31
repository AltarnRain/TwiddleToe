// <copyright file="MainViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels
{
    using System.Windows.Input;
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.UI.Base;
    using TwiddleToe.UI.Commands;
    using TwiddleToe.UI.Windows;
    using TwiddleToe.Workers.Factories;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// View model for the main menu.
    /// </summary>
    public class MainViewModel : BaseSubscriberViewModel
    {
        private readonly ViewFactory viewFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel" /> class.
        /// </summary>
        /// <param name="viewModelFactory">The view model factory.</param>
        /// <param name="stateProvider">The state provider.</param>
        public MainViewModel(
            ViewFactory viewModelFactory,
            StateProvider stateProvider)
            : base(stateProvider)
        {
            this.OpenUsers = new RelayCommnand(this.OpenUserWindow);
            this.viewFactory = viewModelFactory;
        }

        /// <summary>
        /// Gets or sets the open users.
        /// </summary>
        /// <value>
        /// The open users.
        /// </value>
        public ICommand OpenUsers { get; set; }

        /// <summary>
        /// States the update.
        /// </summary>
        /// <param name="state">The state.</param>
        public override void StateUpdate(State state)
        {
            // Does nothing. This view model doesn't show the state.
        }

        private void OpenUserWindow()
        {
            var view = this.viewFactory.GetView<Users>();
            view.ShowDialog();
        }
    }
}
