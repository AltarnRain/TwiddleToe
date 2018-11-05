// <copyright file="WorkAreaProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Providers
{
    using System.Windows;
    using TwiddleToe.UI.Interfaces;
    using TwiddleToe.UI.Models;

    /// <summary>
    /// Provides an abstraction layer for obtaining the work area of the screen.
    /// This permits unit tests testing views to predict position calculations made
    /// by methods which rely on the screen's work area.
    /// /// </summary>
    /// <seealso cref="TwiddleToe.UI.Interfaces.IWorkAreaProvider" />
    public class WorkAreaProvider : IWorkAreaProvider
    {
        /// <summary>
        /// Gets a WorkArea object.
        /// </summary>
        /// <returns>
        /// The width and height if the current work area.
        /// </returns>
        public WorkArea Get()
        {
            return new WorkArea
            {
                Height = SystemParameters.WorkArea.Height,
                Width = SystemParameters.WorkArea.Width
            };
        }
    }
}