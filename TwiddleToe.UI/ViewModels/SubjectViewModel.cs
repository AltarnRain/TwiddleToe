// <copyright file="SubjectViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.Base;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// A View model for subjects
    /// </summary>
    public class SubjectViewModel : BaseSubscriberViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubjectViewModel"/> class.
        /// </summary>
        /// <param name="stateProvider">The state provider.</param>
        /// <param name="viewModelRegistry">The view model registry.</param>
        public SubjectViewModel(
            StateProvider stateProvider,
            ViewModelRegistry viewModelRegistry)
            : base(stateProvider, viewModelRegistry)
        {
        }

        /// <summary>
        /// Gets or sets the subjects.
        /// </summary>
        /// <value>
        /// The subjects.
        /// </value>
        public ObservableCollection<Subject> Subjects { get; set; }

        /// <summary>
        /// States the update.
        /// </summary>
        /// <param name="state">The state.</param>
        public override void StateUpdate(State state)
        {
            // No implentation
        }
    }
}
