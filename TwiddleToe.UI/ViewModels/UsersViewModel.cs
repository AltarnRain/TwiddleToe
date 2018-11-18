// <copyright file="UsersViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.Base;
    using TwiddleToe.UI.Commands;
    using TwiddleToe.UI.Interfaces.Input.API;
    using TwiddleToe.UI.Interfaces.Input.Models;
    using TwiddleToe.UI.Providers;
    using TwiddleToe.Utilities.Extentions;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// A view model for TwiddleToe users.
    /// </summary>
    /// <seealso cref="TwiddleToe.UI.Base.BaseSubscriberViewModel" />
    public class UsersViewModel : BaseSubscriberViewModel
    {
        /// <summary>
        /// The view factory
        /// </summary>
        private readonly ViewProvider viewProvider;

        /// <summary>
        /// The user provider
        /// </summary>
        private readonly UserProvider userProvider;
        private readonly InputProvider inputProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersViewModel" /> class.
        /// </summary>
        /// <param name="viewProvider">The view provider.</param>
        /// <param name="stateProvider">The state provider.</param>
        /// <param name="viewModelRegistry">The view model registry.</param>
        /// <param name="userProvider">The user provider.</param>
        /// <param name="inputProvider">The input provider.</param>
        public UsersViewModel(
            ViewProvider viewProvider,
            StateProvider stateProvider,
            ViewModelRegistry viewModelRegistry,
            UserProvider userProvider,
            InputProvider inputProvider)
            : base(stateProvider, viewModelRegistry)
        {
            this.viewProvider = viewProvider;
            this.userProvider = userProvider;
            this.inputProvider = inputProvider;
            this.InitializeCommands();
        }

        /// <summary>
        /// Gets or sets the selected value.
        /// </summary>
        /// <value>
        /// The selected value.
        /// </value>
        public string SelectedValue
        {
            get => this.CurrentUser?.Identity;
            set
            {
                this.CurrentUser = this.Users.SingleOrDefault(u => u.Identity == value);

                // Keep track of the original first and last name so we can detect changes to the current user data.
                this.FirstName = this.CurrentUser?.FirstName;
                this.LastName = this.CurrentUser?.LastName;
            }
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
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public ObservableCollection<User> Users { get; set; }

        /// <summary>
        /// Gets the add new user command
        /// </summary>
        /// <value>
        /// The add new user.
        /// </value>
        public ICommand AddNewUser { get; private set; }

        /// <summary>
        /// Gets the remove user selected user command.
        /// </summary>
        /// <value>
        /// The remove user.
        /// </value>
        public ICommand RemoveSelectedUser { get; private set; }

        /// <summary>
        /// Gets the update user.
        /// </summary>
        /// <value>
        /// The update user.
        /// </value>
        public ICommand UpdateUser { get; private set; }

        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        public User CurrentUser { get; private set; }

        /// <summary>
        /// Called before updating the state. The view model inheriting from <see cref="BaseSubscriberViewModel" />
        /// decides how to implement it.
        /// </summary>
        public override void PrepareForStateStateUpdate()
        {
            if (this.Users == null)
            {
                this.Users = new ObservableCollection<User>();
            }
            else
            {
                this.Users.Clear();
            }
        }

        /// <summary>
        /// States the update.
        /// </summary>
        /// <param name="state">The state.</param>
        public override void HandleStateUpdate(State state)
        {
            var users = state.Users.Where(u => u.Deleted == false).ToList();
            // users.Sort();
            this.Users.AddRange(users);
        }

        private void InitializeCommands()
        {
            this.AddNewUser = new RelayCommnand(this.AddNewUserAction);

            this.RemoveSelectedUser = new RelayCommnand(
                () =>
                {
                    var currentUser = this.CurrentUser;
                    this.StateProvider.RemoveFromState(currentUser);
                },
                () => this.CurrentUser != null);

            this.UpdateUser = new RelayCommnand(
                () =>
                {
                    this.CurrentUser.FirstName = this.FirstName;
                    this.CurrentUser.LastName = this.LastName;
                    this.StateProvider.Update(this.CurrentUser);
                },
                () => this.CurrentUser?.FirstName != this.FirstName || this.CurrentUser?.LastName != this.LastName);
        }

        private void AddNewUserAction()
        {
            var inputs = new List<IGenericInput>
            {
                new TextInputModel { Label = "Voornaam", Required = true },
                new TextInputModel { Label = "Achernaam", Required = true }
            };

            var result = this.inputProvider.Get("Nieuwe gebruiker", inputs);

            if (result.UserAccepted)
            {
                var voornaam = result.Output.ValueByLabel<TextInputModel>("Voornaam").Input;
                var achternaam = result.Output.ValueByLabel<TextInputModel>("Achernaam").Input;

                var newUser = this.userProvider.Create(voornaam, achternaam);
                this.StateProvider.Add(newUser);
            }
        }
    }
}
