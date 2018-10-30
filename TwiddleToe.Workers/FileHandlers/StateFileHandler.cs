// <copyright file="StateLoader.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.FileHandlers
{
    using System.IO;
    using Newtonsoft.Json;
    using TwiddleToe.Foundation.Models;
    using TwiddleToe.Workers.Providers;

    /// <summary>
    /// Handles loading and saving the <see cref="State"/> to a file
    /// </summary>
    public class StateFileHandler
    {
        /// <summary>
        /// The program information provider
        /// </summary>
        private readonly ProgramInformationProvider programInformationProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateFileHandler"/> class.
        /// </summary>
        /// <param name="programInformationProvider">The program information provider.</param>
        public StateFileHandler(ProgramInformationProvider programInformationProvider)
        {
            this.programInformationProvider = programInformationProvider;
        }

        /// <summary>
        /// Gets this the state from the stored file.
        /// </summary>
        /// <returns>A state object</returns>
        public State Get()
        {
            State state = null;
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

            return state;
        }

        /// <summary>
        /// Saves the state to file.
        /// </summary>
        /// <param name="state">The state.</param>
        public void SaveStateToFile(State state)
        {
            var json = JsonConvert.SerializeObject(state);
            var programInformation = this.programInformationProvider.Get();
            File.WriteAllText(programInformation.DataFile, json);
        }
    }
}
