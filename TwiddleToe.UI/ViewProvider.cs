// <copyright file="ViewProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI
{
    using System.Windows;
    using TwiddleToe.Foundation.Interfaces;
    using TwiddleToe.Workers.Factories;

    /// <summary>
    /// Provides views
    /// </summary>
    public class ViewProvider
    {
        private readonly ViewFactory viewFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewProvider"/> class.
        /// </summary>
        /// <param name="viewFactory">The view factory.</param>
        public ViewProvider(ViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
        }

        /// <summary>
        /// Shows the view model according to its marker interface.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <returns>The created view</returns>
        public TView Show<TView, TViewModel>()
            where TView : IBaseView, new()
            where TViewModel : IBaseViewModel
        {
            var view = this.viewFactory.Create<TView, TViewModel>();

            if (view is IShowDialog)
            {
                if (view is Window window)
                {
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    window.ResizeMode = ResizeMode.NoResize;
                }

                view.ShowDialog();
            }
            else
            {
                view.Show();
            }

            return view;
        }
    }
}
