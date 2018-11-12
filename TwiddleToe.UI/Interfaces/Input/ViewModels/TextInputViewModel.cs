// <copyright file="TextInputViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Interfaces.Input.ViewModels
{
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.Base;
    using TwiddleToe.UI.Interfaces.Input.API;
    using TwiddleToe.UI.Interfaces.Input.Models;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// A class for containing text input data.
    /// </summary>
    /// <seealso cref="ITextInput" />
    public class TextInputViewModel : BaseViewModel, ITextInput, IInputViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextInputViewModel" /> class.
        /// </summary>
        /// <param name="viewModelRegistry">The view model registry.</param>
        /// <param name="stateProvider">The state provider.</param>
        public TextInputViewModel(ViewModelRegistry viewModelRegistry, StateProvider stateProvider)
            : base(viewModelRegistry, stateProvider)
        {
        }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the text input.
        /// </summary>
        /// <value>
        /// The text input.
        /// </value>
        public string Input { get; set; }

        /// <summary>
        /// Gets or sets the index of the tab.
        /// </summary>
        /// <value>
        /// The index of the tab.
        /// </value>
        public int TabIndex { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IInputViewModel" /> is focus.
        /// </summary>
        /// <value>
        ///   <c>true</c> if focus; otherwise, <c>false</c>.
        /// </value>
        public bool Focus { get; set; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>The data from this view model</returns>
        public IGenericInput GetData()
        {
            var returnValue = new TextInputModel
            {
                Input = this.Input
            };

            return returnValue;
        }
    }
}
