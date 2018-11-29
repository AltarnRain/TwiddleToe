// <copyright file="XmlHelper.cs" company="Onno Invernizzi">
// Copyright Onno Invernizzi
// </copyright>

namespace TwiddleToe.Utilities.Helpers
{
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Helper methods for XML files.
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// Deserializes the specified file.
        /// </summary>
        /// <typeparam name="T">A class file</typeparam>
        /// <param name="file">The file.</param>
        /// <returns>A deserialized file of type T</returns>
        public static T Deserialize<T>(string file)
            where T : class
        {
            var serializer = new XmlSerializer(typeof(T));

            T value;
            using (var reader = new StreamReader(file))
            {
                value = (T)serializer.Deserialize(reader);
            }

            return value;
        }
    }
}
