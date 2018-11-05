// <copyright file="IWorkAreaProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Interfaces
{
    using TwiddleToe.UI.Models;

    /// <summary>
    /// Providers an inteface for the WorkAreaProvider. Permits injection of a test class for unit testing
    /// positioning.
    /// </summary>
    public interface IWorkAreaProvider
    {
        /// <summary>
        /// Gets a WorkArea object.
        /// </summary>
        /// <returns>The width and height if the current work area.</returns>
        WorkArea Get();
    }
}
