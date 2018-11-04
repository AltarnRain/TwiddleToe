// <copyright file="ViewTestImplentation.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.TestClasses
{
    using System;
    using TwiddleToe.Foundation.Interfaces;

    /// <summary>
    /// Test implentation of IBaseView
    /// </summary>
    /// <seealso cref="TwiddleToe.Foundation.Interfaces.IBaseView" />
    public class ViewTestImplentation : IBaseView
    {
        /// <summary>
        /// Occurs when [closed].
        /// </summary>
        public event EventHandler Closed;

        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        public object DataContext { get; set; }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            // No implentation
        }

        /// <summary>
        /// Shows this instance.
        /// </summary>
        public void Show()
        {
            // No implentation
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <returns>
        /// True, null, or false
        /// </returns>
        public bool? ShowDialog()
        {
            return false;
        }

        /// <summary>
        /// Closeds the was set.
        /// </summary>
        /// <returns>True if the closed event was set.</returns>
        public bool ClosedWasSet()
        {
            return this.Closed != null;
        }
    }
}
