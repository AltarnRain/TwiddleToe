// <copyright file="GenericInputViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels
{
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.Base;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// A generic imput view model.
    /// </summary>
    public class GenericInputViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericInputViewModel"/> class.
        /// </summary>
        /// <param name="viewModelRegistry">The view model registry.</param>
        /// <param name="stateProvider">The state provider.</param>
        public GenericInputViewModel(ViewModelRegistry viewModelRegistry, StateProvider stateProvider)
            : base(viewModelRegistry, stateProvider)
        {
        }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        /// <value>
        /// The input.
        /// </value>
        public string Input { get; set; }

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
    }
}
