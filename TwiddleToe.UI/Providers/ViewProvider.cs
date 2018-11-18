// <copyright file="ViewProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Providers
{
    using System.Linq;
    using System.Windows;
    using Ninject.Parameters;
    using TwiddleToe.Foundation.Interfaces.Base;
    using TwiddleToe.Foundation.Interfaces.Display;
    using TwiddleToe.Foundation.Interfaces.Locations;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.Interfaces;
    using TwiddleToe.UI.Interfaces.Display;
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
        /// The view model factory
        /// </summary>
        private readonly ViewModelFactory viewModelFactory;
        private readonly ViewRegistry viewRegistry;

        /// <summary>
        /// The work area provider
        /// </summary>
        private readonly IWorkAreaProvider workAreaProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewProvider" /> class.
        /// </summary>
        /// <param name="viewFactory">The view factory.</param>
        /// <param name="viewModelFactory">The view model factory.</param>
        /// <param name="viewRegistry">The view registry.</param>
        /// <param name="workAreaProvider">The work area provider.</param>
        public ViewProvider(
            ViewFactory viewFactory,
            ViewModelFactory viewModelFactory,
            ViewRegistry viewRegistry,
            IWorkAreaProvider workAreaProvider)
        {
            this.viewFactory = viewFactory;
            this.viewModelFactory = viewModelFactory;
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
        public TView Show<TView, TViewModel>(params ConstructorArgument[] args)
            where TView : class, IView, new()
            where TViewModel : IBaseViewModel
        {
            var view = this.viewFactory.Create<TView>(args);
            view.DataContext = this.viewModelFactory.Create<TViewModel>(() => { view.Close(); }, args);

            if (view is IView v)
            {
                this.SetViewDisplayProperties(v);
            }

            if (view is IShowDialog)
            {
                view.ShowDialog();
            }
            else
            {
                view.Show();
            }

            if (view is IEntryView)
            {
                var screenHorizantalCenter = this.workAreaProvider.Get().Width / 2;

                var activeEntryViews = this.viewRegistry.ActiveViews
                    .Where(activeView => activeView is IEntryView)
                    .Select(activeView => activeView as IEntryView);

                if (activeEntryViews.Any())
                {
                    double left;
                    if (activeEntryViews.Count() % 2 == 0)
                    {
                        left = screenHorizantalCenter - (activeEntryViews.First().Width * activeEntryViews.Count() / 2);
                    }
                    else
                    {
                        left = screenHorizantalCenter - (activeEntryViews.First().Width * (activeEntryViews.Count() / 2)) - (activeEntryViews.First().Width / 2);
                    }

                    foreach (var activeEntryView in activeEntryViews)
                    {
                        activeEntryView.Left = left;
                        left += activeEntryView.Width;
                    }
                }
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
