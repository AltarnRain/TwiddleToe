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
        /// Initializes a new instance of the <see cref="ViewRegistry"/> class.
        /// </summary>
        public ViewRegistry()
        {
            this.ActiveViews = new List<IBaseView>();
        }

        /// <summary>
        /// Gets the active view models
        /// </summary>
        public List<IBaseView> ActiveViews { get; private set; }

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
                return this.ActiveViews.Count;
            }
        }

        /// <summary>
        /// Activateds the specified view model.
        /// </summary>
        /// <param name="view">The view.</param>
        public void Activated(IBaseView view)
        {
            this.ActiveViews.Add(view);
        }

        /// <summary>
        /// Deactivateds the specified view model.
        /// </summary>
        /// <param name="view">The view.</param>
        public void Deactivated(IBaseView view)
        {
            this.ActiveViews.Remove(view);
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

            return this.ActiveViews.Select(v => v.GetType().FullName).Contains(newViewFullName);
        }

        /// <summary>
        /// Determines whether the specified view is active.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns>
        ///   <c>true</c> if the specified view is active; otherwise, <c>false</c>.
        /// </returns>
        public IBaseView GetView(Type view)
        {
            var activeView = view.FullName;
            var activeViewsFullName = new List<string>();

            return this.ActiveViews.Single(v => v.GetType().FullName == activeView);
        }
    }
}