// <copyright file="MainViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.Base;
    using TwiddleToe.UI.Commands;
    using TwiddleToe.UI.Interfaces.Input.API;
    using TwiddleToe.UI.Interfaces.Input.Models;
    using TwiddleToe.UI.Providers;
    using TwiddleToe.UI.Views;
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
        private readonly ViewProvider viewProvider;
        private readonly InputProvider inputProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel" /> class.
        /// </summary>
        /// <param name="viewProvider">The view provider.</param>
        /// <param name="viewModelRegistry">The view model registry.</param>
        /// <param name="stateProvider">The state provider.</param>
        public MainViewModel(
            ViewProvider viewProvider,
            ViewModelRegistry viewModelRegistry,
            StateProvider stateProvider,
            InputProvider inputProvider)
            : base(viewModelRegistry, stateProvider)
        {
            this.OpenUsers = new RelayCommnand(() => this.viewProvider.Show<Users, UsersViewModel>());
            this.OpenSubjects = new RelayCommnand(() => this.viewProvider.Show<Subjects, SubjectViewModel>());
            this.TestInput = new RelayCommnand(this.TestInputAction);

            this.viewProvider = viewProvider;
            this.inputProvider = inputProvider;
        }


        public void TestInputAction()
        {
  

            var inputs = new List<IGenericInput>
                {
                    new TextInputModel { Label = "Onderwerp" },
                    new TextInputModel { Label = "Onderwerp1" },
                    new TextInputModel { Label = "Onderwerp2" },
                    new TextInputModel { Label = "Onderwerp3" }
                };

            var r = this.inputProvider.Get("Proef", inputs);
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


        public ICommand TestInput { get; set; }
    }
}
