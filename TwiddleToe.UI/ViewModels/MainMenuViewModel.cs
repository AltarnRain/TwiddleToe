// <copyright file="MainMenuViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using TwiddleToe.Base;
    using TwiddleToe.UI.Commands;
    using TwiddleToe.UI.Windows;
    using TwiddleToe.Utilities.Factories;

    /// <summary>
    /// View model for the main menu.
    /// </summary>
    public class MainMenuViewModel : BaseViewModel
    {
        private readonly ViewFactory viewFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuViewModel" /> class.
        /// </summary>
        /// <param name="viewModelFactory">The view model factory.</param>
        public MainMenuViewModel(ViewFactory viewModelFactory)
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

        private void OpenUserWindow()
        {
            var view = this.viewFactory.GetView<Users>();
            view.ShowDialog();
        }
    }
}
