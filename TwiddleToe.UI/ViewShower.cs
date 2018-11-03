// <copyright file="ViewShower.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI
{
    using System;
    using System.Windows;
    using TwiddleToe.Foundation.Interfaces;
    using TwiddleToe.Workers.Factories;

    /// <summary>
    /// This class handles the creation of views and view models. It assigns the view model to the view
    /// and registeres the events needed for disposing and unregistering view models.
    /// </summary>
    public class ViewShower
    {
        /// <summary>
        /// The view factory
        /// </summary>
        private readonly ViewFactory viewFactory;

        /// <summary>
        /// The view model factory
        /// </summary>
        private readonly ViewModelFactory viewModelFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewShower" /> class.
        /// </summary>
        /// <param name="viewFactory">The view factory.</param>
        /// <param name="viewModelFactory">The view model factory.</param>
        public ViewShower(ViewFactory viewFactory, ViewModelFactory viewModelFactory)
        {
            this.viewFactory = viewFactory;
            this.viewModelFactory = viewModelFactory;
        }

        /// <summary>
        /// Loads the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        public void Load<TView, TViewModel>()
            where TView : Window
            where TViewModel : IBaseViewModel
        {
            var view = this.viewFactory.GetView<TView>();

            if (view.DataContext is IDisposable viewModel)
            {
                view.Closed += (sender, e) => { viewModel.Dispose(); };
            }

            view.DataContext = this.viewModelFactory.GetViewModel<TViewModel>(() => { view.Close(); });

            if (view is IShowDialog)
            {
                view.ShowDialog();
            }
            else
            {
                view.Show();
            }
        }
    }
}
