// <copyright file="ViewModelRegistry.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation
{
    using System.Collections.Generic;
    using TwiddleToe.Foundation.Interfaces;

    /// <summary>
    /// A registry of view models active in the entire application
    /// </summary>
    public class ViewModelRegistry
    {
        /// <summary>
        /// The active view models
        /// </summary>
        private readonly List<IBaseViewModel> activeViewModels;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelRegistry"/> class.
        /// </summary>
        public ViewModelRegistry()
        {
            this.activeViewModels = new List<IBaseViewModel>();
        }

        /// <summary>
        /// Activateds the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Activated(IBaseViewModel viewModel)
        {
            this.activeViewModels.Add(viewModel);
        }

        /// <summary>
        /// Deactivateds the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public void Deactivated(IBaseViewModel viewModel)
        {
            this.activeViewModels.Remove(viewModel);
        }

        /// <summary>
        /// Closes all active.
        /// </summary>
        public void CloseAllActive()
        {
            foreach (var activeVieWModel in this.activeViewModels)
            {
                activeVieWModel.CloseView();
            }
        }
    }
}
