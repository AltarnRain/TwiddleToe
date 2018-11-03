// <copyright file="BaseViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Base
{
    using System;
    using System.ComponentModel;
    using TwiddleToe.Foundation;
    using TwiddleToe.Foundation.Events;
    using TwiddleToe.Foundation.Interfaces;

    /// <summary>
    /// Base view model for all view models.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class BaseViewModel : INotifyPropertyChanged, IBaseViewModel
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private readonly string identifier;

        private readonly ViewModelRegistry viewModelRegistry;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel" /> class.
        /// </summary>
        /// <param name="viewModelRegistry">The view model registry.</param>
        public BaseViewModel(ViewModelRegistry viewModelRegistry)
        {
            this.identifier = Guid.NewGuid().ToString();
            this.viewModelRegistry = viewModelRegistry;
            this.viewModelRegistry.Activated(this);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        ~BaseViewModel()
        {
            this.viewModelRegistry.Deactivated(this);
        }

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
