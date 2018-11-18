// <copyright file="ViewFactory.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.Factories
{
    using System;
    using Ninject;
    using Ninject.Parameters;
    using TwiddleToe.Foundation.Interfaces.Base;
    using TwiddleToe.Foundation.Registries;

    /// <summary>
    /// This class handles the creation of views and view models. It assigns the view model to the view
    /// and registeres the events needed for disposing and unregistering view models.
    /// </summary>
    public class ViewFactory
    {
        private readonly IKernel kernel;

        /// <summary>
        /// The view registry
        /// </summary>
        private readonly ViewRegistry viewRegistry;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewFactory" /> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        /// <param name="viewRegistry">The view registry.</param>
        public ViewFactory(IKernel kernel, ViewRegistry viewRegistry)
        {
            this.kernel = kernel;
            this.viewRegistry = viewRegistry;
        }

        /// <summary>
        /// Creates the view, binds the data context and its close event.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="args">The arguments.</param>
        /// <returns>
        /// A view object
        /// </returns>
        public TView Create<TView>(params ConstructorArgument[] args)
            where TView : class, IBaseView
        {
            TView view = null;

            var isActive = this.viewRegistry.IsActive(typeof(TView));
            if (isActive == false)
            {
                view = this.kernel.Get<TView>(args);

                // Remove the view from the view registry when it closes
                view.Closed += (sender, e) =>
                {
                    this.viewRegistry.Deactivated(view);

                    if (view.DataContext is IDisposable viewModel)
                    {
                        viewModel.Dispose();
                    }
                };

                // Register the view
                this.viewRegistry.Activated(view);
            }
            else
            {
                // View is already active
                var activeView = this.viewRegistry.GetView(typeof(TView));
                activeView.Focus();
                view = activeView as TView;
            }

            return view;
        }
    }
}
