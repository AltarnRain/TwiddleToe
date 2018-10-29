// <copyright file="MainViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels
{
    using System.Windows.Input;
    using TwiddleToe.Base;
    using TwiddleToe.UI.Commands;
    using TwiddleToe.UI.Factories;
    using TwiddleToe.UI.Windows;

    /// <summary>
    /// View model for the main menu.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private readonly ViewFactory viewFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel" /> class.
        /// </summary>
        /// <param name="viewModelFactory">The view model factory.</param>
        public MainViewModel(ViewFactory viewModelFactory)
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
