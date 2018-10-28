// <copyright file="ViewModelsTestScope.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.TestScopes
{
    using Ninject;
    using TwiddleToe.UI.ViewModels;

    /// <summary>
    /// Test scope for view models
    /// </summary>
    /// <seealso cref="TwiddleToe.Tests.TestScopeBase" />
    public class ViewModelsTestScope : TestScopeBase
    {
        /// <summary>
        /// Gets the user view model.
        /// </summary>
        /// <value>
        /// The user view model.
        /// </value>
        public UsersViewModel UserViewModel
        {
            get
            {
                return this.Kernel.Get<UsersViewModel>();
            }
        }
    }
}
