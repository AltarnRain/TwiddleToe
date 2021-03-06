﻿// <copyright file="IBaseView.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Interfaces.Base
{
    using System;

    /// <summary>
    /// This interface provides an absraction layer for the Wpf Window class.
    /// Every window in this application uses this interface and it allows
    /// the view factory to be implemented at a much lower level.
    /// </summary>
    public interface IBaseView
    {
        /// <summary>
        /// Occurs when [closed].
        /// </summary>
        event EventHandler Closed;

        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        object DataContext { get; set; }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        void Close();

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <returns>True, null, or false</returns>
        bool? ShowDialog();

        /// <summary>
        /// Shows this instance.
        /// </summary>
        void Show();

        /// <summary>
        /// Focuses this instance.
        /// </summary>
        /// <returns>A boolean</returns>
        bool Focus();
    }
}
