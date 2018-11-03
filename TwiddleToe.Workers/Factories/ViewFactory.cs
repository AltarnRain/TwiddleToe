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
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <returns>A view</returns>
        public TView GetView<TView>()
            where TView : Window
        {
            return this.kernel.Get<TView>();
        }
    }
}
