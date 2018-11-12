// <copyright file="TextInputModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Interfaces.Input.Models
{
    using TwiddleToe.UI.Interfaces.Input.API;

    /// <summary>
    /// Model for generating a text input view model
    /// </summary>
    public class TextInputModel : ITextInput
    {
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
    }
}
