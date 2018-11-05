// <copyright file="ICenterScreen.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Interfaces.Display
{
    using TwiddleToe.Foundation.Interfaces.Locations;

    /// <summary>
    /// Provides an easy interface for setting center horizantal and vertical
    /// </summary>
    /// <seealso cref="TwiddleToe.Foundation.Interfaces.Locations.ICenterHorizantal" />
    /// <seealso cref="TwiddleToe.Foundation.Interfaces.Locations.ICenterVertical" />
    public interface ICenterScreen : ICenterHorizantal, ICenterVertical
    {
    }
}
