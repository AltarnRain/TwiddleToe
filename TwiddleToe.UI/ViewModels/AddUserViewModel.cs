// <copyright file="AddUserViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels
{
    using System;
    using System.Windows.Input;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.Base;
    using TwiddleToe.UI.Commands;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// A view model for adding users
    /// </summary>
    /// <seealso cref="TwiddleToe.UI.Base.BaseViewModel" />
    public class AddUserViewModel : BaseViewModel
    {
        /// <summary>
        /// The state provider
        /// </summary>
        private readonly StateProvider stateProvider;

        /// <summary>
        /// The user provider
        /// </summary>
        private readonly UserProvider userProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddUserViewModel" /> class.
        /// </summary>
        /// <param name="userProvider">The user provider.</param>
        /// <param name="stateProvider">The state provider.</param>
        /// <param name="viewModelRegistry">The view model registry.</param>
        public AddUserViewModel(UserProvider userProvider, StateProvider stateProvider, ViewModelRegistry viewModelRegistry)
            : base(viewModelRegistry, stateProvider)
        {
            this.AddUser = new RelayCommnand(this.AddNewUser, this.CanAddNewUser);
            this.Cancel = new RelayCommnand(this.CancelAddition);

            this.userProvider = userProvider;
            this.stateProvider = stateProvider;
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the add user.
        /// </summary>
        /// <value>
        /// The add user.
        /// </value>
        public ICommand AddUser { get; set; }

        /// <summary>
        /// Gets or sets the add user.
        /// </summary>
        /// <value>
        /// The add user.
        /// </value>
        public ICommand Cancel { get; set; }

        /// <summary>
        /// Determines whether this instance [can add new user].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can add new user]; otherwise, <c>false</c>.
        /// </returns>
        public bool CanAddNewUser()
        {
            return !string.IsNullOrWhiteSpace(this.FirstName) && !string.IsNullOrWhiteSpace(this.LastName);
        }

        /// <summary>
        /// Adds the new user.
        /// </summary>
        private void AddNewUser()
        {
            var newUser = this.userProvider.Create(this.FirstName, this.LastName);
            var currentState = this.stateProvider.Current;
            currentState.Users.Add(newUser);
            this.stateProvider.Current = currentState;
            this.CloseView();
        }

        /// <summary>
        /// Gets or sets the cancel addition.
        /// </summary>
        /// <value>
        /// The cancel addition.
        /// </value>
        private void CancelAddition()
        {
            this.CloseView();
        }
    }
}
