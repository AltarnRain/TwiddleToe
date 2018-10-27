// <copyright file="StateProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Providers
{
    using System.IO;
    using Newtonsoft.Json;
    using TwiddleToe.Models.Models;

    /// <summary>
    /// Provides the current state.
    /// </summary>
    public class StateProvider
    {
        /// <summary>
        /// The state
        /// </summary>
        private static State state;

        /// <summary>
        /// The programinformation
        /// </summary>
        private readonly ProgramInformation programinformation;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvider"/> class.
        /// </summary>
        /// <param name="programinformation">The programinformation.</param>
        public StateProvider(ProgramInformation programinformation)
        {
            this.programinformation = programinformation;
        }

        /// <summary>
        /// Gets the <see cref="State"/>instance.
        /// </summary>
        /// <returns>The current state</returns>
        public State Get()
        {
            if (File.Exists(this.programinformation.DataFile))
            {
                try
                {
                    state = JsonConvert.DeserializeObject<State>(this.programinformation.DataFile);
                }
                catch
                {
                    if (state == null)
                    {
                        state = new State();
                    }
                }
            }
            else
            {
                state = new State();
            }

            return state;
        }

        /// <summary>
        /// Sets the specified state.
        /// </summary>
        /// <param name="newState">The new state.</param>
        public void Set(State newState)
        {
            state = newState;
        }

        /// <summary>
        /// Flushes the content of the state to a file.
        /// </summary>
        public void Flush()
        {
            var json = JsonConvert.SerializeObject(state);
            File.WriteAllText(this.programinformation.DataFile, json);
        }
    }
}
