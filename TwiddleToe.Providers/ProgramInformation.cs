// <copyright file="ProgramInformation.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Providers
{
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// This is a singleton class that contains a information that the entire application uses.
    /// </summary>
    public class ProgramInformation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgramInformation"/> class.
        /// </summary>
        public ProgramInformation()
        {
            this.DataFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!this.DataFolder.EndsWith(@"\"))
            {
                this.DataFolder += @"\";
            }

            this.DataFolder += @"Data\";

            if (!Directory.Exists(this.DataFolder))
            {
                Directory.CreateDirectory(this.DataFolder);
            }

            this.DataFile = this.DataFolder + "Data.json";
        }

        /// <summary>
        /// Gets the data folder.
        /// This is where information for TwiddleToe is stored.
        /// </summary>
        /// <value>
        /// The data folder.
        /// </value>
        public string DataFolder { get; private set; }

        /// <summary>
        /// Gets the data file.
        /// </summary>
        /// <value>
        /// The data file.
        /// </value>
        public string DataFile { get; private set; }
    }
}
