// <copyright file="SubjectProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.Providers
{
    using TwiddleToe.Foundation.Models;

    /// <summary>
    /// Provides subjects
    /// </summary>
    public class SubjectProvider
    {
        /// <summary>
        /// The identity provider
        /// </summary>
        private readonly IdentityProvider identityProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubjectProvider"/> class.
        /// </summary>
        /// <param name="identityProvider">The identity provider.</param>
        public SubjectProvider(IdentityProvider identityProvider)
        {
            this.identityProvider = identityProvider;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>
        /// A subject objects
        /// </returns>
        public Subject Create(string description)
        {
            return new Subject
            {
                SubjectId = this.identityProvider.Get(),
                Description = description
            };
        }
    }
}
