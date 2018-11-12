// <copyright file="ViewModelFactory.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.Factories
{
    using Ninject;
    using Ninject.Parameters;
    using TwiddleToe.Foundation.Events;
    using TwiddleToe.Foundation.Interfaces.Base;

    /// <summary>
    /// A factory responsible for creating view models
    /// </summary>
    public class ViewModelFactory
    {
        /// <summary>
        /// The kernel
        /// </summary>
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public ViewModelFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view.</typeparam>
        /// <param name="close">The close.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>
        /// A view model
        /// </returns>
        public TViewModel GetViewModel<TViewModel>(RequestClose close = null, params ConstructorArgument[] args)
            where TViewModel : IBaseViewModel
        {
            var viewModel = this.kernel.Get<TViewModel>(args);
            viewModel.OnRequestClose += close;

            return viewModel;
        }
    }
}
