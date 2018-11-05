// <copyright file="ViewProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Providers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using Ninject.Parameters;
    using TwiddleToe.Foundation.Interfaces.Base;
    using TwiddleToe.Foundation.Interfaces.Display;
    using TwiddleToe.Foundation.Interfaces.Locations;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.Interfaces;
    using TwiddleToe.Utilities.Helpers;
    using TwiddleToe.Workers.Factories;

    /// <summary>
    /// Provides views
    /// </summary>
    public class ViewProvider
    {
        /// <summary>
        /// The view factory
        /// </summary>
        private readonly ViewFactory viewFactory;

        /// <summary>
        /// The view registry
        /// </summary>
        private readonly ViewRegistry viewRegistry;

        /// <summary>
        /// The work area provider
        /// </summary>
        private readonly IWorkAreaProvider workAreaProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewProvider" /> class.
        /// </summary>
        /// <param name="viewFactory">The view factory.</param>
        /// <param name="viewRegistry">The view registry.</param>
        /// <param name="workAreaProvider">The work area provider.</param>
        public ViewProvider(
            ViewFactory viewFactory,
            ViewRegistry viewRegistry,
            IWorkAreaProvider workAreaProvider)
        {
            this.viewFactory = viewFactory;
            this.viewRegistry = viewRegistry;
            this.workAreaProvider = workAreaProvider;
        }

        /// <summary>
        /// Shows the view model according to its marker interface.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="args">The arguments.</param>
        /// <returns>
        /// The created view
        /// </returns>
        public TView Show<TView, TViewModel>(IDictionary<string, object> args = null)
            where TView : class, IView, new()
            where TViewModel : IBaseViewModel
        {
            IView view = null;

            var isActive = this.viewRegistry.IsActive(typeof(TView));
            if (isActive == false)
            {
                ConstructorArgument[] ninjectParameters;
                if (args != null)
                {
                    ninjectParameters = args.Select(a => new ConstructorArgument(a.Key, a.Value)).ToArray();
                }
                else
                {
                    ninjectParameters = new ConstructorArgument[0];
                }

                view = this.viewFactory.Create<TView, TViewModel>(ninjectParameters);

                // Remove the view from the view registry when it closes
                view.Closed += (sender, e) =>
                {
                    this.viewRegistry.Deactivated(view);
                };

                // Register the view
                this.viewRegistry.Activated(view);
                this.SetViewDisplayProperties(view);

                if (view is IOffload == false)
                {
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
            else
            {
                // View is already active
                var activeView = this.viewRegistry.GetActiveView(typeof(TView));
                activeView.Focus();
                view = activeView as IView;
            }

            return view as TView;
        }

        /// <summary>
        /// Sets the view display properties.
        /// </summary>
        /// <param name="view">The view.</param>
        private void SetViewDisplayProperties(IView view)
        {
            if (view is IResizable)
            {
                view.ResizeMode = ResizeMode.CanResize;
            }
            else if (view is ICanMinimize)
            {
                view.ResizeMode = ResizeMode.CanMinimize;
            }
            else
            {
                view.ResizeMode = ResizeMode.NoResize;
            }

            if (view is IShowInTaskbar)
            {
                view.ShowInTaskbar = true;
            }

            if (view is ITop)
            {
                view.Top = 0;
            }

            var workArea = this.workAreaProvider.Get();

            if (view is ICenterHorizantal)
            {
                view.Left = Calculations.GetCenterCoordinate(workArea.Width, view.Width);
            }

            if (view is ICenterVertical)
            {
                view.Top = Calculations.GetCenterCoordinate(workArea.Height, view.Height);
            }
        }
    }
}
