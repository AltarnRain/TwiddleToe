// <copyright file="IBaseViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Interfaces
{
    using TwiddleToe.Foundation.Events;

    /// <summary>
    /// Base interface for all view models. Allows inversion of control.
    /// for the ViewFactory
    /// </summary>
    public interface IBaseViewModel : ISubscriber
    {
        /// <summary>
        /// Occurs when [on request close].
        /// </summary>
        event RequestClose OnRequestClose;

        /// <summary>
        /// Closes the view.
        /// </summary>
        void CloseView();
    }
}
