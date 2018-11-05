// <copyright file="IInput.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Interfaces.Display
{
    using TwiddleToe.Foundation.Interfaces.Display;

    /// <summary>
    /// Tells the view provider this is an input window and its display
    /// and return value are handled elsewhere.
    /// </summary>
    /// <seealso cref="IView" />
    /// <seealso cref="ICenterScreen" />
    /// <seealso cref="IOffload" />
    public interface IInput : IView, ICenterScreen, IOffload
    {
    }
}
