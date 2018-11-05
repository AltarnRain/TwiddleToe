// <copyright file="IPopup.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Interfaces.Display
{
    using TwiddleToe.Foundation.Interfaces.Display;

    /// <summary>
    /// Flags a view as a pop up window.
    /// </summary>
    /// <seealso cref="ICenterScreen" />
    /// <seealso cref="IShowDialog" />
    public interface IPopup : IView, ICenterScreen, IShowDialog
    {
    }
}
