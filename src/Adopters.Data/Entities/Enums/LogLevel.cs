//-----------------------------------------------------------------------
// <copyright file="LogLevel.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities
{
    /// <summary>
    /// Log Level
    /// </summary>
    public enum LogLevel : short
    {
        /// <summary>
        /// The debug
        /// </summary>
        Debug = 10,

        /// <summary>
        /// The information
        /// </summary>
        Information = 20,

        /// <summary>
        /// The warning
        /// </summary>
        Warning = 30,

        /// <summary>
        /// The error
        /// </summary>
        Error = 40,

        /// <summary>
        /// The console
        /// </summary>
        Console = 50
    }
}