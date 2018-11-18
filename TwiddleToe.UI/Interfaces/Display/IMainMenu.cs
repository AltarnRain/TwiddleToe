// <copyright file="IMainMenu.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Interfaces.Display
{
    using TwiddleToe.Foundation.Interfaces.Display;
    using TwiddleToe.Foundation.Interfaces.Locations;

    /// <summary>
    /// Provides an easy interface for the main menu.
    /// </summary>
    /// <seealso cref="TwiddleToe.Foundation.Interfaces.Locations.ICenterHorizantal" />
    /// <seealso cref="TwiddleToe.Foundation.Interfaces.Locations.ITop" />
    /// <seealso cref="TwiddleToe.Foundation.Interfaces.Display.ICanMinimize" />
    public interface IMainMenu : IView, ICenterHorizantal, ITop, ICanMinimize, IShowDialog
    {
    }
}
