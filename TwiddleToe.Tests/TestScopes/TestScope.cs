// <copyright file="TestScope.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Tests
{
    using Ninject;
    using TwiddleToe.UI.DialogWindows.ViewModels;
    using TwiddleToe.UI.ViewModels;
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
        public ProgramInformationProvider ProgramInformationProvider => this.Kernel.Get<ProgramInformationProvider>();

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

        public object StateFileHandler { get; internal set; }

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
            this.Kernel.Load(new TwiddleToe.UI.Modules());
        }
    }
}
