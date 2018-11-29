// <copyright file="TestScope.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests.TestBase
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ninject;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.Test.Base;
    using TwiddleToe.Tests.TestClasses;
    using TwiddleToe.Tests.TestImplementations;
    using TwiddleToe.UI.Interfaces;
    using TwiddleToe.UI.Providers;
    using TwiddleToe.UI.ViewModels;
    using TwiddleToe.Workers.Factories;
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
        public IProgramInformationProvider ProgramInformationProvider => this.Kernel.Get<IProgramInformationProvider>();

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
        /// Gets the test base view model.
        /// </summary>
        /// <value>
        /// The test base view model.
        /// </value>
        public BaseViewModelTestImplentation BaseViewModelTestImplentation => this.Kernel.Get<BaseViewModelTestImplentation>();

        /// <summary>
        /// Gets the view model registry.
        /// </summary>
        /// <value>
        /// The view model registry.
        /// </value>
        public ViewModelRegistry ViewModelRegistry => this.Kernel.Get<ViewModelRegistry>();

        /// <summary>
        /// Gets the base subscriber view model test implentation.
        /// </summary>
        /// <value>
        /// The base subscriber view model test implentation.
        /// </value>
        public BaseSubscriberViewModelTestImplementation BaseSubscriberViewModelTestImplentation => this.Kernel.Get<BaseSubscriberViewModelTestImplementation>();

        /// <summary>
        /// Gets the view factory.
        /// </summary>
        /// <value>
        /// The view factory.
        /// </value>
        public ViewFactory ViewFactory => this.Kernel.Get<ViewFactory>();

        /// <summary>
        /// Gets the view provider.
        /// </summary>
        /// <value>
        /// The view provider.
        /// </value>
        public ViewProvider ViewProvider => this.Kernel.Get<ViewProvider>();

        /// <summary>
        /// Gets the subject view model.
        /// </summary>
        /// <value>
        /// The subject view model.
        /// </value>
        public SubjectViewModel SubjectViewModel => this.Kernel.Get<SubjectViewModel>();

        /// <summary>
        /// Gets the subject provider.
        /// </summary>
        /// <value>
        /// The subject provider.
        /// </value>
        public SubjectProvider SubjectProvider => this.Kernel.Get<SubjectProvider>();

        /// <summary>
        /// Gets the view registry.
        /// </summary>
        /// <value>
        /// The view registry.
        /// </value>
        public ViewRegistry ViewRegistry => this.Kernel.Get<ViewRegistry>();

        /// <summary>
        /// Gets the input provider.
        /// </summary>
        /// <value>
        /// The input provider.
        /// </value>
        public InputProvider InputProvider => this.Kernel.Get<InputProvider>();

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
            this.Kernel.Rebind<IProgramInformationProvider>().To<ProgramInformationProviderTestImplementation>().InSingletonScope();

            var provider = this.Kernel.Get<IProgramInformationProvider>() as ProgramInformationProviderTestImplementation;
            provider.SetTestContext(this.TestContext);

            this.Kernel.Rebind<IWorkAreaProvider>().To<WorkAreaTestImplementation>().InSingletonScope();
        }
    }
}
