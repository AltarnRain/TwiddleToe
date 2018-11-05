// <copyright file="ViewProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Providers
{
    using System.Windows;
    using TwiddleToe.Foundation.Interfaces.Base;
    using TwiddleToe.Foundation.Interfaces.Display;
    using TwiddleToe.Foundation.Interfaces.Locations;
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
        /// The work area provider
        /// </summary>
        private readonly IWorkAreaProvider workAreaProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewProvider" /> class.
        /// </summary>
        /// <param name="viewFactory">The view factory.</param>
        /// <param name="workAreaProvider">The work area provider.</param>
        public ViewProvider(ViewFactory viewFactory, IWorkAreaProvider workAreaProvider)
        {
            this.viewFactory = viewFactory;
            this.workAreaProvider = workAreaProvider;
        }

        /// <summary>
        /// Shows the view model according to its marker interface.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <returns>The created view</returns>
        public TView Show<TView, TViewModel>()
            where TView : IView, new()
            where TViewModel : IBaseViewModel
        {
            var view = this.viewFactory.Create<TView, TViewModel>();

            this.SetViewDisplayProperties(view);

            if (view is IShowDialog)
            {
                view.ShowDialog();
            }
            else
            {
                view.Show();
            }

            return view;
        }

        /// <summary>
        /// Sets the view display properties.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <param name="view">The view.</param>
        private void SetViewDisplayProperties<TView>(TView view)
            where TView : IView, new()
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
