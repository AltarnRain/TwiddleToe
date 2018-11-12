// <copyright file="InputProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.Providers
{
    using System.Collections.Generic;
    using Ninject.Parameters;
    using TwiddleToe.UI.DialogViewModels;
    using TwiddleToe.UI.Interfaces.Input.API;
    using TwiddleToe.UI.Models;
    using TwiddleToe.UI.Views;

    /// <summary>
    /// Provides an input pop-up and returns the result
    /// </summary>
    public class InputProvider
    {
        private readonly ViewProvider viewProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputProvider"/> class.
        /// </summary>
        /// <param name="viewProvider">The view provider.</param>
        public InputProvider(ViewProvider viewProvider)
        {
            this.viewProvider = viewProvider;
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

            var view = this.viewProvider.Show<GenericInput, GenericInputViewModel>(arguments);
            view.ShowDialog();

            var viewModel = view.DataContext as GenericInputViewModel;

            if (viewModel.UserAccepted)
            {
                return new InputResult
                {
                    UserAccepted = true,
                    Input = viewModel.GetData()
                };
            }
            else
            {
                return new InputResult
                {
                    UserAccepted = false,
                    Input = null,
                };
            }
        }
    }
}
