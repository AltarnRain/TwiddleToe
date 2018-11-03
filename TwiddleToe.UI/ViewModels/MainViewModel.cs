﻿// <copyright file="MainViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels
{
    using System.Windows.Input;
    using TwiddleToe.Foundation;
    using TwiddleToe.UI.Base;
    using TwiddleToe.UI.Commands;
    using TwiddleToe.UI.Windows;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// View model for the main menu.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// The view factory
        /// </summary>
        private readonly ViewLoader viewLoader;
        private readonly ViewModelRegistry viewModelRegistry;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel" /> class.
        /// </summary>
        /// <param name="viewLoader">The view factory.</param>
        /// <param name="stateProvider">The state provider.</param>
        /// <param name="viewModelRegistry">The view model registry.</param>
        public MainViewModel(
            ViewLoader viewLoader,
            StateProvider stateProvider,
            ViewModelRegistry viewModelRegistry)
            : base(viewModelRegistry)
        {
            this.OpenUsers = new RelayCommnand(this.OpenUserWindow);
            this.viewLoader = viewLoader;
            this.viewModelRegistry = viewModelRegistry;
        }

        /// <summary>
        /// Gets or sets the open users.
        /// </summary>
        /// <value>
        /// The open users.
        /// </value>
        public ICommand OpenUsers { get; set; }

        /// <summary>
        /// Opens the user window.
        /// </summary>
        private void OpenUserWindow()
        {
            this.viewLoader.LoadView<Users>();
        }
    }
}
