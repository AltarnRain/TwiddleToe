﻿// <copyright file="AddUserViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.DialogWindows.ViewModels
{
    using System;
    using System.Windows.Input;
    using TwiddleToe.Base;
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.UI.Commands;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// A view model for adding users
    /// </summary>
    /// <seealso cref="TwiddleToe.Base.BaseViewModel" />
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
        /// <param name="stateProvider">The state provider.</param>
        /// <param name="userProvider">The user provider.</param>
        public AddUserViewModel(
            StateProvider stateProvider,
            UserProvider userProvider)
            : base(stateProvider)
        {
            this.AddUser = new RelayCommnand(this.AddNewUser, this.CanAddNewUser, this.CanNowAddNewUser);
            this.Cancel = new RelayCommnand(this.CancelAddition);
            this.stateProvider = stateProvider;
            this.userProvider = userProvider;
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
        /// Determines whether this instance [can now add new user] the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void CanNowAddNewUser(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// States the update.
        /// </summary>
        /// <param name="state">The state.</param>
        public override void StateUpdate(State state)
        {
            // No action. This view model is not updated when the state changes.
        }

        /// <summary>
        /// Adds the new user.
        /// </summary>
        private void AddNewUser()
        {
            var newUser = this.userProvider.Create(this.FirstName, this.LastName);
            var currentState = this.stateProvider.Get();
            currentState.Users.Add(newUser);
            this.stateProvider.Set(currentState);
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

        /// <summary>
        /// Determines whether this instance [can add new user].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can add new user]; otherwise, <c>false</c>.
        /// </returns>
        private bool CanAddNewUser()
        {
            return !string.IsNullOrWhiteSpace(this.FirstName) && !string.IsNullOrWhiteSpace(this.LastName);
        }
    }
}