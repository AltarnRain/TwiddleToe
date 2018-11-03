// <copyright file="IProgramInformationProvider.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Workers.Providers
{
    using TwiddleToe.Foundation.Models;

    /// <summary>
    /// Provides a contract for a ProgramInformationProvider.
    /// </summary>
    public interface IProgramInformationProvider
    {
        /// <summary>
        /// Get's a <see cref="ProgramInformation"/> object
        /// </summary>
        /// <returns>A ProgramInformation object</returns>
        ProgramInformation Get();
    }
}