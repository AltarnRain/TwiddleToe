// <copyright file="ViewFactory.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.Factories
{
    using System.Windows;
    using Ninject;
    using TwiddleToe.Foundation.Events;
    using TwiddleToe.Foundation.Interfaces;

    /// <summary>
    /// Creates view models and views and handles service injection
    /// </summary>
    public class ViewFactory
    {
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public ViewFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view.</typeparam>
        /// <param name="close">The close.</param>
        /// <returns>
        /// A view model
        /// </returns>
        public TViewModel GetViewModel<TViewModel>(RequestClose close)
            where TViewModel : IBaseViewModel
        {
            var viewModel = this.kernel.Get<TViewModel>();
            viewModel.OnRequestClose += close;

            return viewModel;
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <returns>A view</returns>
        public TView GetView<TView>()
            where TView : Window
        {
            return this.kernel.Get<TView>();
        }
    }
}
