﻿// <copyright file="ViewFactory.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.Factories
{
    using System;
    using Ninject.Parameters;
    using TwiddleToe.Foundation.Interfaces.Base;

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
        /// <param name="args">The arguments.</param>
        /// <returns>
        /// A view object
        /// </returns>
        public TView Create<TView, TViewModel>(params ConstructorArgument[] args)
            where TView : IBaseView, new()
            where TViewModel : IBaseViewModel
        {
            var view = new TView();

            ConstructorArgument[] ninjectArguments = null;
            if (args == null)
            {
                ninjectArguments = new ConstructorArgument[0];
            }
            else
            {
                ninjectArguments = args;
            }

            view.DataContext = this.viewModelFactory.GetViewModel<TViewModel>(() => { view.Close(); }, ninjectArguments);

            if (view.DataContext is IDisposable viewModel)
            {
                view.Closed += (sender, e) =>
                {
                    viewModel.Dispose();
                };
            }

            return view;
        }
    }
}
