// <copyright file="ViewRegistry.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Registries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TwiddleToe.Foundation.Interfaces.Base;

    /// <summary>
    /// A registry of view models active in the entire application
    /// </summary>
    public class ViewRegistry
    {
        /// <summary>
        /// The active view models
        /// </summary>
        private readonly List<IBaseView> activeViews;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewRegistry"/> class.
        /// </summary>
        public ViewRegistry()
        {
            this.activeViews = new List<IBaseView>();
        }

        /// <summary>
        /// Gets the number of active view models.
        /// </summary>
        /// <value>
        /// The number of active view models.
        /// </value>
        public int NumberOfActiveViews
        {
            get
            {
                return this.activeViews.Count;
            }
        }

        /// <summary>
        /// Activateds the specified view model.
        /// </summary>
        /// <param name="view">The view.</param>
        public void Activated(IBaseView view)
        {
            this.activeViews.Add(view);
        }

        /// <summary>
        /// Deactivateds the specified view model.
        /// </summary>
        /// <param name="view">The view.</param>
        public void Deactivated(IBaseView view)
        {
            this.activeViews.Remove(view);
        }

        /// <summary>
        /// Determines whether the specified view is active.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns>
        ///   <c>true</c> if the specified view is active; otherwise, <c>false</c>.
        /// </returns>
        public bool IsActive(Type view)
        {
            var newViewFullName = view.FullName;
            var activeViewsFullName = new List<string>();

            return this.activeViews.Select(v => v.GetType().FullName).Contains(newViewFullName);
        }

        /// <summary>
        /// Determines whether the specified view is active.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns>
        ///   <c>true</c> if the specified view is active; otherwise, <c>false</c>.
        /// </returns>
        public IBaseView GetActiveView(Type view)
        {
            var activeView = view.FullName;
            var activeViewsFullName = new List<string>();

            return this.activeViews.Single(v => v.GetType().FullName == activeView);
        }
    }
}