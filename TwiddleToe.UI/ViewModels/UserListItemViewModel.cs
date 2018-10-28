// <copyright file="UserListItemViewModel.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.UI.ViewModels
{
    using TwiddleToe.Base;
    using TwiddleToe.Models;

    /// <summary>
    /// A view model for displaying users in a list box.
    /// </summary>
    /// <seealso cref="TwiddleToe.Base.BaseViewModel" />
    public class UserListItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The user
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserListItemViewModel"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
        public UserListItemViewModel(User user)
        {
            this.user = user;
            this.UpdateFullName();
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName
        {
            get
            {
                return this.user.FirstName;
            }

            set
            {
                this.user.FirstName = value;
                this.UpdateFullName();
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName
        {
            get
            {
                return this.user.LastName;
            }

            set
            {
                this.user.LastName = value;
                this.UpdateFullName();
            }
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId
        {
            get
            {
                return this.user.UserId;
            }
        }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>The current data container in the view model</returns>
        public User GetData()
        {
            return this.user;
        }

        /// <summary>
        /// Updates the full name.
        /// </summary>
        private void UpdateFullName()
        {
            this.FullName = $"{this.user.FirstName} {this.user.LastName}";
        }
    }
}
