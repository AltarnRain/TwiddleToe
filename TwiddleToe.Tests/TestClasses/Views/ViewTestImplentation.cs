// <copyright file="ViewTestImplentation.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.TestClasses.Views
{
    using System;
    using System.Windows;
    using TwiddleToe.Tests;
    using TwiddleToe.UI.Interfaces;

    /// <summary>
    /// Test implentation of IBaseView
    /// </summary>
    /// <seealso cref="IView" />
    public class ViewTestImplentation : IView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewTestImplentation"/> class.
        /// </summary>
        public ViewTestImplentation()
        {
            // Set size and position to known values so we can test if they were changed to expected values.
            this.Width = Constants.TestViewWidth;
            this.Height = Constants.TestViewHeight;
            this.Left = Constants.TestViewLeft;
            this.Top = Constants.TestViewTop;
        }

        /// <summary>
        /// Occurs when [closed].
        /// </summary>
        public event EventHandler Closed;

        /// <summary>
        /// Gets or sets the top.
        /// </summary>
        /// <value>
        /// The top.
        /// </value>
        public double Top { get; set; }

        /// <summary>
        /// Gets or sets the resize mode.
        /// </summary>
        /// <value>
        /// The resize mode.
        /// </value>
        public ResizeMode ResizeMode { get; set; }

        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        /// <value>
        /// The left.
        /// </value>
        public double Left { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public double Height { get; set; }

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
