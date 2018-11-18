// <copyright file="InputProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Providers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows;
    using Ninject.Parameters;
    using TwiddleToe.UI.DialogViewModels;
    using TwiddleToe.UI.Interfaces.Input.API;
    using TwiddleToe.UI.Models;
    using TwiddleToe.UI.Views;
    using TwiddleToe.Utilities.Helpers;
    using TwiddleToe.Workers.Factories;

    /// <summary>
    /// Provides an input pop-up and returns the result
    /// </summary>
    public class InputProvider
    {
        private readonly ViewFactory viewFactory;
        private readonly ViewModelFactory viewModelFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputProvider" /> class.
        /// </summary>
        /// <param name="viewFactory">The view factory.</param>
        /// <param name="viewModelFactory">The view model factory.</param>
        public InputProvider(ViewFactory viewFactory, ViewModelFactory viewModelFactory)
        {
            this.viewFactory = viewFactory;
            this.viewModelFactory = viewModelFactory;
        }

        /// <summary>
        /// Gets the specified title.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="inputs">The inputs.</param>
        /// <returns>
        /// An input result
        /// </returns>
        public InputResult Get(string title, IList<IGenericInput> inputs)
        {
            var arguments = new ConstructorArgument[]
            {
                new ConstructorArgument("title", title),
                new ConstructorArgument("inputs", inputs)
            };

            var view = this.viewFactory.Create<GenericInput>();
            var viewModel = this.viewModelFactory.Create<GenericInputViewModel>(() => { view.Close(); }, arguments);
            view.DataContext = viewModel;

            // Hack to get the first element focused.
            if (view is Window w)
            {
                w.ContentRendered += (sender, e) =>
                {
                    viewModel.FocusFirstInput();
                };

                w.Activated += (sender, e) =>
                {
                    viewModel.FocusFirstInput();
                };
            }

            view.ShowDialog();

            if (viewModel.UserAccepted)
            {
                return new InputResult
                {
                    UserAccepted = true,
                    Output = viewModel.GetData()
                };
            }
            else
            {
                return new InputResult
                {
                    UserAccepted = false,
                    Output = null,
                };
            }
        }
    }
}
