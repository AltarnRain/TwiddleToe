// <copyright file="BaseViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Base
{
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Base view model for all view models.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
