﻿// <copyright file="MainViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels
{
    using System.Windows.Input;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.Base;
    using TwiddleToe.UI.Commands;
    using TwiddleToe.UI.Providers;
    using TwiddleToe.UI.Views;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// View model for the main menu.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// The view factory
        /// </summary>
        private readonly ViewProvider viewProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel" /> class.
        /// </summary>
        /// <param name="viewProvider">The view provider.</param>
        /// <param name="viewModelRegistry">The view model registry.</param>
        /// <param name="stateProvider">The state provider.</param>
        public MainViewModel(
            ViewProvider viewProvider,
            ViewModelRegistry viewModelRegistry,
            StateProvider stateProvider)
            : base(viewModelRegistry, stateProvider)
        {
            this.OpenUsers = new RelayCommnand(() => this.viewProvider.Show<Users, UsersViewModel>());
            this.OpenSubjects = new RelayCommnand(() => this.viewProvider.Show<Subjects, SubjectViewModel>());
            this.OpenAddQuestions = new RelayCommnand(() => this.viewProvider.Show<AddQuestionsView, AddQuestionsViewModel>());

            this.viewProvider = viewProvider;
        }

        /// <summary>
        /// Gets or sets the open users.
        /// </summary>
        /// <value>
        /// The open users.
        /// </value>
        public ICommand OpenUsers { get; set; }

        /// <summary>
        /// Gets or sets the open subjects.
        /// </summary>
        /// <value>
        /// The open subjects.
        /// </value>
        public ICommand OpenSubjects { get; set; }

        /// <summary>
        /// Gets or sets the open add questions.
        /// </summary>
        /// <value>
        /// The open add questions.
        /// </value>
        public ICommand OpenAddQuestions { get; set; }
    }
}
