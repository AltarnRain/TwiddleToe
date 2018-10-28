﻿// <copyright file="ProviderTestScope.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests
{
    using Ninject;
    using TwiddleToe.Models.Models;
    using TwiddleToe.Providers;

    /// <summary>
    /// Test scope for provider unit tests.
    /// </summary>
    public class ProviderTestScope : TestScopeBase
    {
        /// <summary>
        /// Gets the identity provider.
        /// </summary>
        /// <value>
        /// The identity provider.
        /// </value>
        public IdentityProvider IdentityProvider => this.Kernel.Get<IdentityProvider>();

        /// <summary>
        /// Gets the state provider.
        /// </summary>
        /// <value>
        /// The state provider.
        /// </value>
        public StateProvider StateProvider => this.Kernel.Get<StateProvider>();

        /// <summary>
        /// Gets the program information.
        /// </summary>
        /// <value>
        /// The program information.
        /// </value>
        public ProgramInformation ProgramInformation => this.Kernel.Get<ProgramInformation>();

        /// <summary>
        /// Starts this a test scope.
        /// </summary>
        public override void Start()
        {
            base.Start();
            this.RegisterServices();
        }

        /// <summary>
        /// Registers the services.
        /// </summary>
        protected override void RegisterServices()
        {
            base.RegisterServices();
            this.Kernel.Load(new TwiddleToe.Providers.Modules());
        }
    }
}