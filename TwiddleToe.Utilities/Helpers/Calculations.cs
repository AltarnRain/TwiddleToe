// <copyright file="Calculations.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Utilities.Helpers
{
    /// <summary>
    /// Generic calculations
    /// </summary>
    public static class Calculations
    {
        /// <summary>
        /// Gets the center position.
        /// </summary>
        /// <param name="screenSize">Size of the screen.</param>
        /// <param name="viewSize">Size of the view.</param>
        /// <returns>The center coordinate for a view's horizantal or vertical position</returns>
        public static double GetCenterCoordinate(double screenSize, double viewSize)
        {
            return (screenSize / 2) - (viewSize / 2);
        }
    }
}
