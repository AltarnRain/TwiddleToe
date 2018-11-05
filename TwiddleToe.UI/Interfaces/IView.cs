// <copyright file="IView.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Interfaces
{
    using System.Windows;
    using TwiddleToe.Foundation.Interfaces.Base;

    /// <summary>
    /// Interface that describes the required methods and properties to unit tests a view.
    /// </summary>
    /// <seealso cref="IBaseView" />
    public interface IView : IBaseView
    {
        /// <summary>
        /// Gets or sets the top.
        /// </summary>
        /// <value>
        /// The top.
        /// </value>
        double Top { get; set; }

        /// <summary>
        /// Gets or sets the resize mode.
        /// </summary>
        /// <value>
        /// The resize mode.
        /// </value>
        ResizeMode ResizeMode { get; set; }

        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        /// <value>
        /// The left.
        /// </value>
        double Left { get; set; }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        double Width { get; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        double Height { get; }
    }
}
