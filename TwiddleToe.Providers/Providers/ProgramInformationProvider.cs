// <copyright file="ProgramInformationProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Providers
{
    using System.IO;
    using System.Reflection;
    using TwiddleToe.Models.Models;

    /// <summary>
    /// This is a singleton class that contains a information that the entire application uses.
    /// </summary>
    public class ProgramInformationProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramInformationProvider" /> class.
        /// </summary>
        /// <returns>A program information object</returns>
        public ProgramInformation Get()
        {
            var programInformation = new ProgramInformation();
            programInformation.DataFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!programInformation.DataFolder.EndsWith(@"\"))
            {
                programInformation.DataFolder += @"\";
            }

            programInformation.DataFolder += @"Data\";

            if (!Directory.Exists(programInformation.DataFolder))
            {
                Directory.CreateDirectory(programInformation.DataFolder);
            }

            programInformation.DataFile = programInformation.DataFolder + "Data.json";

            return programInformation;
        }
    }
}
