// <copyright file="UsersViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Input;
    using TwiddleToe.Base;
    using TwiddleToe.Models;
    using TwiddleToe.Providers;
    using TwiddleToe.UI.Commands;

    /// <summary>
    /// A view model for TwiddleToe users.
    /// </summary>
    /// <seealso cref="TwiddleToe.Base.BaseViewModel" />
    public class UsersViewModel : BaseViewModel
    {
        private readonly StateProvider stateProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersViewModel"/> class.
        /// </summary>
        /// <param name="stateProvider">The state provider.</param>
        public UsersViewModel(StateProvider stateProvider)
        {
            this.Users = new ObservableCollection<UserListItemViewModel>();

            this.stateProvider = stateProvider;

            var currentState = this.stateProvider.Get();

            this.AddNewUser = new RelayCommnand(this.AddUserAction);
        }

        /// <summary>
        /// Gets or sets the selected value.
        /// </summary>
        /// <value>
        /// The selected value.
        /// </value>
        public User SelectedValue { get; set; }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public ObservableCollection<UserListItemViewModel> Users { get; private set; }

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        public int CurrentUserId
        {
            get => -1;
            set
            {
                var foundUser = this.Users.SingleOrDefault(u => u.UserId == value);
                if (foundUser != null)
                {
                    this.CurrentUser = foundUser;
                }
            }
        }

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
        /// Gets the select user.
        /// </summary>
        /// <value>
        /// The select user.
        /// </value>
        public ICommand SetCurrentUser { get; private set; }

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        public UserListItemViewModel CurrentUser { get; set; }

        /// <summary>
        /// Gets the data from the view model.
        /// </summary>
        /// <returns>
        /// A model
        /// </returns>
        public IEnumerable<User> GetData()
        {
            return this.Users.Select(u => u.GetData());
        }

        /// <summary>
        /// Users the selected.
        /// </summary>
        /// <returns>True if a user is selected</returns>
        public bool UserSelected()
        {
            return this.CurrentUser != null;
        }

        /// <summary>
        /// Adds a new user
        /// </summary>
        public void AddUserAction()
        {
        }

        /// <summary>
        /// Removes the currently selected user.
        /// </summary>
        public void RemoveSelectedUserAction()
        {
        }

        /// <summary>
        /// Select a user.
        /// </summary>
        public void SetCurrentUserAction()
        {
        }
    }
}
