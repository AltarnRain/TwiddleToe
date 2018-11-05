// <copyright file="WorkAreaTestImplementation.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.TestImplementations
{
    using TwiddleToe.UI.Interfaces;
    using TwiddleToe.UI.Models;

    /// <summary>
    /// Provides mocked WorkArea data
    /// </summary>
    /// <seealso cref="TwiddleToe.UI.Interfaces.IWorkAreaProvider" />
    internal class WorkAreaTestImplementation : IWorkAreaProvider
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
                Width = Constants.WorkAreaWidth,
                Height = Constants.WorkAreaHeight,
            };
        }
    }
}