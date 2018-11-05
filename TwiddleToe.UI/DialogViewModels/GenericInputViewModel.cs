// <copyright file="GenericInputViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.DialogViewModels
{
    using System.Windows.Input;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.Base;
    using TwiddleToe.UI.Commands;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// A generic imput view model.
    /// </summary>
    public class GenericInputViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericInputViewModel" /> class.
        /// </summary>
        /// <param name="viewModelRegistry">The view model registry.</param>
        /// <param name="stateProvider">The state provider.</param>
        /// <param name="label">The label.</param>
        /// <param name="title">The title.</param>
        public GenericInputViewModel(
            ViewModelRegistry viewModelRegistry,
            StateProvider stateProvider,
            string label,
            string title)
            : base(viewModelRegistry, stateProvider)
        {
            this.Label = label;
            this.Title = title;

            this.Cancel = new RelayCommnand(() =>
            {
                this.UserAccepted = false;
                this.CloseView();
            });

            this.Ok = new RelayCommnand(() =>
            {
                this.UserAccepted = true;
                this.CloseView();
            });
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GenericInputViewModel"/> is canceled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if canceled; otherwise, <c>false</c>.
        /// </value>
        public bool UserAccepted { get; set; }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        /// <value>
        /// The input.
        /// </value>
        public string Input { get; set; }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        /// <value>
        /// The input.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the Ok command.
        /// </summary>
        /// <value>
        /// The ok.
        /// </value>
        public ICommand Ok { get; set; }

        /// <summary>
        /// Gets or sets the cancel command.
        /// </summary>
        /// <value>
        /// The cancel.
        /// </value>
        public ICommand Cancel { get; set; }
    }
}
