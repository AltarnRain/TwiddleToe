// <copyright file="BaseViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Base
{
    using System.ComponentModel;
    using TwiddleToe.Foundation.Events;
    using TwiddleToe.Foundation.Interfaces;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// Base view model for all view models.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class BaseViewModel : INotifyPropertyChanged, IBaseViewModel
    {
        /// <summary>
        /// The view model registry
        /// </summary>
        private readonly ViewModelRegistry viewModelRegistry;

        /// <summary>
        /// The state provider
        /// </summary>
        private readonly StateProvider stateProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel" /> class.
        /// </summary>
        /// <param name="viewModelRegistry">The view model registry.</param>
        /// <param name="stateProvider">The state provider.</param>
        public BaseViewModel(
            ViewModelRegistry viewModelRegistry,
            StateProvider stateProvider)
        {
            this.viewModelRegistry = viewModelRegistry;
            this.stateProvider = stateProvider;
            this.viewModelRegistry.Activated(this);
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

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            this.viewModelRegistry.Deactivated(this);
            this.stateProvider.Flush();
        }
    }
}
