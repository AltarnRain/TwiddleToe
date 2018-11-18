// <copyright file="SubjectViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using TwiddleToe.Foundation.Extentions;
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.Base;
    using TwiddleToe.UI.Commands;
    using TwiddleToe.UI.Interfaces.Input.API;
    using TwiddleToe.UI.Interfaces.Input.Models;
    using TwiddleToe.UI.Providers;
    using TwiddleToe.Utilities.Extentions;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// A View model for subjects
    /// </summary>
    /// <seealso cref="TwiddleToe.UI.Base.BaseSubscriberViewModel" />
    public class SubjectViewModel : BaseSubscriberViewModel
    {
        /// <summary>
        /// The subject provider
        /// </summary>
        private readonly SubjectProvider subjectProvider;

        /// <summary>
        /// The input provider
        /// </summary>
        private readonly InputProvider inputProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubjectViewModel" /> class.
        /// </summary>
        /// <param name="subjectProvider">The subject provider.</param>
        /// <param name="stateProvider">The state provider.</param>
        /// <param name="viewModelRegistry">The view model registry.</param>
        /// <param name="inputProvider">The input provider.</param>
        public SubjectViewModel(
            SubjectProvider subjectProvider,
            StateProvider stateProvider,
            ViewModelRegistry viewModelRegistry,
            InputProvider inputProvider)
            : base(stateProvider, viewModelRegistry)
        {
            this.subjectProvider = subjectProvider;
            this.inputProvider = inputProvider;
            this.InitializeCommands();
        }

        /// <summary>
        /// Gets or sets the subjects.
        /// </summary>
        /// <value>
        /// The subjects.
        /// </value>
        public ObservableCollection<Subject> Subjects { get; set; }

        /// <summary>
        /// Gets or sets the current subject.
        /// </summary>
        /// <value>
        /// The current subject.
        /// </value>
        public Subject CurrentSubject { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the add subject.
        /// </summary>
        /// <value>
        /// The add subject.
        /// </value>
        public ICommand AddSubject { get; set; }

        /// <summary>
        /// Gets or sets the remove subject.
        /// </summary>
        /// <value>
        /// The remove subject.
        /// </value>
        public ICommand RemoveSubject { get; set; }

        /// <summary>
        /// Gets or sets the update subject.
        /// </summary>
        /// <value>
        /// The update subject.
        /// </value>
        public ICommand UpdateSubject { get; set; }

        /// <summary>
        /// Gets or sets the selected value.
        /// </summary>
        /// <value>
        /// The selected value.
        /// </value>
        public string SelectedValue
        {
            get => this.CurrentSubject?.Identity;
            set
            {
                if (value != null)
                {
                    this.CurrentSubject = this.Subjects.Find(value);
                    this.Description = this.CurrentSubject.Description;
                }
            }
        }

        /// <summary>
        /// Called before updating the state. The view model inheriting from <see cref="BaseSubscriberViewModel" />
        /// decides how to implement it.
        /// </summary>
        protected override void PrepareForStateStateUpdate()
        {
            if (this.Subjects == null)
            {
                this.Subjects = new ObservableCollection<Subject>();
            }
            else
            {
                this.Subjects.Clear();
            }
        }

        /// <summary>
        /// Called when the state is updated.
        /// </summary>
        /// <param name="state">The state.</param>
        protected override void HandleStateUpdate(State state)
        {
            this.Subjects.AddRange(state.Subjects);
        }

        /// <summary>
        /// Initializes the commands.
        /// </summary>
        private void InitializeCommands()
        {
            this.AddSubject = new RelayCommnand(
                () =>
                {
                    var inputs = new List<IGenericInput>
                    {
                        new TextInputModel { Label = "Onderwerp", Required = true }
                    };

                    var result = this.inputProvider.Get("Nieuw onderwerp", inputs);

                    if (result.UserAccepted)
                    {
                        var subject = result.Output.ValueByLabel<TextInputModel>("Onderwerk").Input;
                        var newSubject = this.subjectProvider.Create(subject);
                        this.StateProvider.Add(newSubject);
                    }
                });

            this.RemoveSubject = new RelayCommnand(
                () =>
                {
                    if (this.CurrentSubject != null)
                    {
                        this.StateProvider.Remove(this.CurrentSubject);
                    }
                },
                () =>
                {
                    return this.CurrentSubject != null;
                });

            this.UpdateSubject = new RelayCommnand(
                () =>
                {
                    this.CurrentSubject.Description = this.Description;
                    this.StateProvider.Update(this.CurrentSubject);
                },
                () =>
                {
                    if (this.CurrentSubject == null)
                    {
                        return false;
                    }

                    return this.CurrentSubject.Description != this.Description;
                });
        }
    }
}
