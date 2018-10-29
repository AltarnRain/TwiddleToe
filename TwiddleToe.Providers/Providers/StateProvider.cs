// <copyright file="StateProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Providers
{
    using System;
    using System.IO;
    using Newtonsoft.Json;
    using TwiddleToe.Models.Models;
    using TwiddleToe.Utilities;

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
        private readonly ProgramInformationProvider programInformationProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateProvider" /> class.
        /// </summary>
        /// <param name="programInformationProvider">The program information provider.</param>
        public StateProvider(ProgramInformationProvider programInformationProvider)
        {
            this.programInformationProvider = programInformationProvider;

            var programInformation = this.programInformationProvider.Get();

            if (File.Exists(programInformation.DataFile))
            {
                try
                {
                    state = JsonConvert.DeserializeObject<State>(programInformation.DataFile);
                }
                catch
                {
                    state = new State();
                }
            }
        }

        /// <summary>
        /// Gets or sets the on change.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <value>
        /// The on change.
        /// </value>
        public delegate void OnStateChangedEvent(State state);

        /// <summary>
        /// Occurs when [on state changed].
        /// </summary>
        public event OnStateChangedEvent OnStateChanged;

        /// <summary>
        /// Gets the <see cref="State"/>instance.
        /// </summary>
        /// <returns>The current state</returns>
        public State Get()
        {
            if (state == null)
            {
                state = new State();
            }

            // The state is immutable.
            return CloneFactory.MakeClone(state);
        }

        /// <summary>
        /// Sets the specified state.
        /// </summary>
        /// <param name="newState">The new state.</param>
        public void Set(State newState)
        {
            state = CloneFactory.MakeClone(newState);

            // Signal state subscribers the state has changed.
            this.OnStateChanged?.Invoke(CloneFactory.MakeClone(state));
        }

        /// <summary>
        /// Flushes the content of the state to a file.
        /// </summary>
        public void Flush()
        {
            var json = JsonConvert.SerializeObject(state);
            var programInformation = this.programInformationProvider.Get();
            File.WriteAllText(programInformation.DataFile, json);
        }
    }
}
