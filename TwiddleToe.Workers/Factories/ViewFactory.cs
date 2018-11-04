// <copyright file="ViewFactory.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.Factories
{
    using System;
    using System.Windows;
    using TwiddleToe.Foundation.Interfaces;

    /// <summary>
    /// This class handles the creation of views and view models. It assigns the view model to the view
    /// and registeres the events needed for disposing and unregistering view models.
    /// </summary>
    public class ViewFactory
    {
        /// <summary>
        /// The view model factory
        /// </summary>
        private readonly ViewModelFactory viewModelFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewFactory"/> class.
        /// </summary>
        /// <param name="viewModelFactory">The view model factory.</param>
        public ViewFactory(ViewModelFactory viewModelFactory)
        {
            this.viewModelFactory = viewModelFactory;
        }

        /// <summary>
        /// Loads the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        public void Show<TView, TViewModel>()
            where TView : IBaseView, new()
            where TViewModel : IBaseViewModel
        {
            var view = new TView();
            view.DataContext = this.viewModelFactory.GetViewModel<TViewModel>(() => { view.Close(); });

            if (view.DataContext is IDisposable viewModel)
            {
                view.Closed += (sender, e) =>
                {
                    viewModel.Dispose();
                };
            }

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
