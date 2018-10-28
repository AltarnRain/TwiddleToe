// <copyright file="IdentityProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Providers
{
    /// <summary>
    /// This class provides a unique identifiers.
    /// </summary>
    public class IdentityProvider
    {
        /// <summary>
        /// The state provider
        /// </summary>
        private readonly StateProvider stateProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityProvider"/> class.
        /// </summary>
        /// <param name="stateProvider">The state provider.</param>
        public IdentityProvider(StateProvider stateProvider)
        {
            this.stateProvider = stateProvider;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>A new unique identifier</returns>
        public int Get()
        {
            var state = this.stateProvider.Get();
            var returnValue = state.CurrentId;
            state.CurrentId += 1;
            this.stateProvider.Set(state);

            return returnValue;
        }
    }
}