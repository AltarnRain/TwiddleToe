﻿// <copyright file="TestScope.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.Base
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ninject;
    using TwiddleToe.Tests.TestClasses;
    using TwiddleToe.UI.DialogWindows.ViewModels;
    using TwiddleToe.UI.ViewModels;
    using TwiddleToe.Workers.FileHandlers;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// Test scope for provider unit tests.
    /// </summary>
    public class TestScope : TestScopeBase
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
        public IProgramInformationProvider ProgramInformationProvider
        {
            get
            {
                // Unit tests testing the ProgramInformationProvider need the real ProgramInformationProvider and
                // not a test implementation
                this.Kernel.Rebind<IProgramInformationProvider>().To<ProgramInformationProvider>();
                var returnValue = this.Kernel.Get<IProgramInformationProvider>();
                this.SetTestProgramInformationProvider();

                return returnValue;
            }
        }

        /// <summary>
        /// Gets the user provider.
        /// </summary>
        /// <value>
        /// The user provider.
        /// </value>
        public UserProvider UserProvider => this.Kernel.Get<UserProvider>();

        /// <summary>
        /// Gets the user view model.
        /// </summary>
        /// <value>
        /// The user view model.
        /// </value>
        public UsersViewModel UserViewModel => this.Kernel.Get<UsersViewModel>();

        /// <summary>
        /// Gets the add user view model.
        /// </summary>
        /// <value>
        /// The add user view model.
        /// </value>
        public AddUserViewModel AddUserViewModel => this.Kernel.Get<AddUserViewModel>();

        /// <summary>
        /// Gets the main view model.
        /// </summary>
        /// <value>
        /// The main view model.
        /// </value>
        public MainViewModel MainViewModel => this.Kernel.Get<MainViewModel>();

        /// <summary>
        /// Gets the state file handler.
        /// </summary>
        /// <value>
        /// The state file handler.
        /// </value>
        public StateFileHandler StateFileHandler => this.Kernel.Get<StateFileHandler>();

        /// <summary>
        /// Starts this a test scope.
        /// </summary>
        /// <param name="testContext">The test context.</param>
        public override void Start(TestContext testContext)
        {
            base.Start(testContext);
            this.RegisterServices();
        }

        /// <summary>
        /// Registers the services.
        /// </summary>
        protected override void RegisterServices()
        {
            base.RegisterServices();
            this.Kernel.Load(new TwiddleToe.UI.Modules());

            this.SetTestProgramInformationProvider();
        }

        /// <summary>
        /// Sets the test program information provider. This method ensures all
        /// classes using the ProgramInformationProvider use the TestProgramInformationProvider
        /// </summary>
        private void SetTestProgramInformationProvider()
        {
            this.Kernel.Rebind<IProgramInformationProvider>().To<TestProgramInformationProvider>().InSingletonScope();
            var testProgramInformationProvider = this.Kernel.Get<IProgramInformationProvider>() as TestProgramInformationProvider;
            testProgramInformationProvider.SetTestContext(this.TestContext);
        }
    }
}