// <copyright file="ViewProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI
{
    using System.Windows;
    using TwiddleToe.Foundation.Interfaces;
    using TwiddleToe.Foundation.Interfaces.Locations;
    using TwiddleToe.UI.Interfaces;
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
            where TView : IView, new()
            where TViewModel : IBaseViewModel
        {
            var view = this.viewFactory.Create<TView, TViewModel>();


            view.ResizeMode = ResizeMode.NoResize;

            if (view is ITop)
            {
                view.Top = 0;
            }

            if (view is ICenterHorizantal)
            {
                view.Left = (SystemParameters.WorkArea.Width / 2) - (view.Width / 2);
            }

            if (view is ICenterVertical)
            {
                view.Top = (SystemParameters.WorkArea.Height / 2) - (view.Height / 2);
            }


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
    }
}
