// <copyright file="ITextInput.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Interfaces.Input.API
{
    /// <summary>
    /// Interface for a text input class.
    /// </summary>
    /// <seealso cref="IGenericInput" />
    internal interface ITextInput : IGenericInput
    {
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        string Label { get; set; }

        /// <summary>
        /// Gets or sets the text input.
        /// </summary>
        /// <value>
        /// The text input.
        /// </value>
        string Input { get; set; }
    }
}
