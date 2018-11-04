// <copyright file="BaseViewTestImplentation.cs" company="Onno Invernizzi">
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
    public abstract class BaseViewTestImplentation : IBaseView
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
        /// Gets a value indicating whether [show dialog called].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show dialog called]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowDialogCalled { get; private set; }

        /// <summary>
        /// Gets a value indicating whether [show called].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show called]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowCalled { get; private set; }

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
            this.ShowCalled = true;
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <returns>
        /// True, null, or false
        /// </returns>
        public bool? ShowDialog()
        {
            this.ShowDialogCalled = true;
            return null;
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
