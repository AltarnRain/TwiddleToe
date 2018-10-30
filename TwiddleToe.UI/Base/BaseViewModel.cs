// <copyright file="BaseViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Base
{
    using System.ComponentModel;
    using TwiddleToe.Foundation.Events;
    using TwiddleToe.Models.Interfaces;

    /// <summary>
    /// Base view model for all view models.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class BaseViewModel : INotifyPropertyChanged, IBaseViewModel
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Occurs when [on request close].
        /// </summary>
        public event RequestClose OnRequestClose;

        /// <summary>
        /// Closes the view.
        /// </summary>
        public void CloseView()
        {
            this.OnRequestClose?.Invoke();
        }
    }
}
