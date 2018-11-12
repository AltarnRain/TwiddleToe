// <copyright file="IInputViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Interfaces.Input.Models
{
    using TwiddleToe.UI.Interfaces.Input.API;

    /// <summary>
    /// Defined a generic input view model
    /// </summary>
    public interface IInputViewModel
    {
        /// <summary>
        /// Gets or sets the index of the tab.
        /// </summary>
        /// <value>
        /// The index of the tab.
        /// </value>
        int TabIndex { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IInputViewModel"/> is focus.
        /// </summary>
        /// <value>
        ///   <c>true</c> if focus; otherwise, <c>false</c>.
        /// </value>
        bool Focus { get; set; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>The data from the view model</returns>
        IGenericInput GetData();
    }
}