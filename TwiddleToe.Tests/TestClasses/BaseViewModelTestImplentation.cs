// <copyright file="BaseViewModelTestImplentation.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.TestClasses
{
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.Base;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// Implementation of BaseViewModel for unit testing.
    /// </summary>
    /// <seealso cref="TwiddleToe.UI.Base.BaseViewModel" />
    public class BaseViewModelTestImplentation : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModelTestImplentation"/> class.
        /// </summary>
        /// <param name="viewModelRegistry">The view model registry.</param>
        /// <param name="stateProvider">The state provider.</param>
        public BaseViewModelTestImplentation(ViewModelRegistry viewModelRegistry, StateProvider stateProvider)
            : base(viewModelRegistry, stateProvider)
        {
        }
    }
}
