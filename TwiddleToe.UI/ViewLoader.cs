// <copyright file="ViewLoader.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI
{
    using System.Windows;
    using TwiddleToe.Foundation.Interfaces;
    using TwiddleToe.Workers.Factories;

    /// <summary>
    /// Loads views
    /// </summary>
    public class ViewLoader
    {
        private readonly ViewFactory viewFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewLoader"/> class.
        /// </summary>
        /// <param name="viewFactory">The view factory.</param>
        public ViewLoader(ViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
        }

        /// <summary>
        /// Loads the view.
        /// </summary>
        /// <typeparam name="TView">The type of the view.</typeparam>
        public void LoadView<TView>()
            where TView : Window
        {
            var view = this.viewFactory.GetView<TView>();

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
}
