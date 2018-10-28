// <copyright file="UserProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Providers.Providers
{
    using System.Collections.Generic;
    using TwiddleToe.Models;

    /// <summary>
    /// Provides and creates user models
    /// </summary>
    public class UserProvider
    {
        private readonly IdentityProvider identityProvider;
        private readonly StateProvider stateProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProvider"/> class.
        /// </summary>
        /// <param name="identityProvider">The identity provider.</param>
        /// <param name="stateProvider">The state provider.</param>
        public UserProvider(
            IdentityProvider identityProvider,
            StateProvider stateProvider)
        {
            this.identityProvider = identityProvider;
            this.stateProvider = stateProvider;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// Creates a new User model
        /// </returns>
        public User Create(User user)
        {
            user.UserId = this.identityProvider.Get();
            return user;
        }

        /// <summary>
        /// Creates the specified first name.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns>A new user model</returns>
        public User Create(string firstName, string lastName)
        {
            var returnValue = new User
            {
                FirstName = firstName,
                LastName = lastName,
                UserId = this.identityProvider.Get()
            };

            return returnValue;
        }

        /// <summary>
        /// Sets the specified users.
        /// </summary>
        /// <param name="users">The users.</param>
        public void Set(List<User> users)
        {
            var currentState = this.stateProvider.Get();
            currentState.Users = users;
            this.stateProvider.Set(currentState);
        }
    }
}
