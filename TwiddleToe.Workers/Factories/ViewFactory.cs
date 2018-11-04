﻿// <copyright file="ViewFactory.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.Factories
{
    using System;
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
        /// Creates the view, binds the data context and its close event.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <returns>A view object</returns>
        public TView Create<TView, TViewModel>()
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

            return view;
        }

        /// <summary>
        /// Shows the view model according to its marker interface.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        public void Show<TView, TViewModel>()
            where TView : IBaseView, new()
            where TViewModel : IBaseViewModel
        {
            var view = this.Create<TView, TViewModel>();

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
