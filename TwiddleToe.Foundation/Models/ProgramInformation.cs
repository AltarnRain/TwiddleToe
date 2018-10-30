// <copyright file="ProgramInformation.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Foundation.Models
{
    /// <summary>
    /// Class with general program information.
    /// </summary>
    public class ProgramInformation
    {
        /// <summary>
        /// Gets or sets the data folder.
        /// This is where information for TwiddleToe is stored.
        /// </summary>
        /// <value>
        /// The data folder.
        /// </value>
        public string DataFolder { get; set; }

        /// <summary>
        /// Gets or sets the data file.
        /// </summary>
        /// <value>
        /// The data file.
        /// </value>
        public string DataFile { get; set; }
    }
}
