// <copyright file="UsersViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.Foundation.Registries;
    using TwiddleToe.UI.Base;
    using TwiddleToe.UI.Commands;
    using TwiddleToe.UI.DialogWindows;
    using TwiddleToe.Workers.Factories;
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
        private readonly ViewFactory viewFactory;

        /// <summary>
        /// The state provider
        /// </summary>
        private readonly StateProvider stateProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersViewModel" /> class.
        /// </summary>
        /// <param name="viewFactory">The view factory.</param>
        /// <param name="stateProvider">The state provider.</param>
        /// <param name="viewModelRegistry">The view model registry.</param>
        public UsersViewModel(
            ViewFactory viewFactory,
            StateProvider stateProvider,
            ViewModelRegistry viewModelRegistry)
            : base(stateProvider, viewModelRegistry)
        {
            this.viewFactory = viewFactory;
            this.stateProvider = stateProvider;
            this.AddNewUser = new RelayCommnand(this.AddUserAction);
            this.RemoveSelectedUser = new RelayCommnand(this.RemoveSelectedUserAction, this.UserIsSelected);
        }

        /// <summary>
        /// Gets or sets the selected value.
        /// </summary>
        /// <value>
        /// The selected value.
        /// </value>
        public string SelectedValue
        {
            get
            {
                if (this.CurrentUser != null)
                {
                    return this.CurrentUser.FullName;
                }
                else
                {
                    return string.Empty;
                }
            }

            set
            {
                this.CurrentUser = this.Users.Single(u => u.UserId == value);
            }
        }

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
        /// Gets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        public User CurrentUser { get; private set; }

        /// <summary>
        /// States the update.
        /// </summary>
        /// <param name="state">The state.</param>
        public override void StateUpdate(State state)
        {
            if (this.Users == null)
            {
                this.Users = new ObservableCollection<User>();
            }
            else
            {
                this.Users.Clear();
            }

            foreach (var user in state.Users)
            {
                this.Users.Add(user);
            }
        }

        /// <summary>
        /// Users the is selected.
        /// </summary>
        /// <returns>True if a user is selected</returns>
        private bool UserIsSelected()
        {
            return this.CurrentUser != null;
        }

        /// <summary>
        /// Adds a new user
        /// </summary>
        private void AddUserAction()
        {
            this.viewFactory.Show<AddUser, AddUserViewModel>();
        }

        /// <summary>
        /// Removes the currently selected user.
        /// </summary>
        private void RemoveSelectedUserAction()
        {
        }

        /// <summary>
        /// Select a user.
        /// </summary>
        private void SetCurrentUserAction()
        {
        }
    }
}
