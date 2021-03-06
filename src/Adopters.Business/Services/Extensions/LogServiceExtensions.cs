﻿//-----------------------------------------------------------------------
// <copyright file="LogServiceExtensions.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Huellitas.Business.Extensions
{
    using System;
    using Adopters.Business.Services;
    using Adopters.Data.Entities;

    /// <summary>
    /// Log extensions
    /// </summary>
    public static class LogServiceExtensions
    {
        /// <summary>
        /// Consoles the specified short message.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="shortMessage">The short message.</param>
        /// <param name="fullMessage">The full message.</param>
        /// <param name="user">The user.</param>
        public static void Console(this ILogService log, string shortMessage, string fullMessage = null, User user = null)
        {
            log.Insert(LogLevel.Console, shortMessage, fullMessage ?? shortMessage, user);
            System.Console.WriteLine("{0} - {1}", DateTime.Now, shortMessage);
        }

        /// <summary>
        /// Debugs the specified short message.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="shortMessage">The short message.</param>
        /// <param name="fullMessage">The full message.</param>
        /// <param name="user">The user.</param>
        /// <param name="writeConsole">if set to <c>true</c> [write console].</param>
        public static void Debug(this ILogService log, string shortMessage, string fullMessage = null, User user = null, bool writeConsole = false)
        {
            log.Insert(LogLevel.Debug, shortMessage, fullMessage ?? shortMessage, user);

            if (writeConsole)
            {
                System.Console.WriteLine("{0} - {1}", DateTime.Now, shortMessage);
            }
        }

        /// <summary>
        /// Errors the specified short message.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="shortMessage">The short message.</param>
        /// <param name="fullMessage">The full message.</param>
        /// <param name="user">The user.</param>
        public static void Error(this ILogService log, string shortMessage, string fullMessage = null, User user = null)
        {
            log.Insert(LogLevel.Error, shortMessage, fullMessage ?? shortMessage, user);
        }

        /// <summary>
        /// Errors the specified e.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="e">The e.</param>
        /// <param name="user">The user.</param>
        public static void Error(this ILogService log, Exception e, User user = null)
        {
            log.Insert(LogLevel.Error, e.Message, e.ToString(), user);
        }

        /// <summary>
        /// Information the specified short message.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="shortMessage">The short message.</param>
        /// <param name="fullMessage">The full message.</param>
        /// <param name="user">The user.</param>
        public static void Information(this ILogService log, string shortMessage, string fullMessage = null, User user = null)
        {
            log.Insert(LogLevel.Information, shortMessage, fullMessage ?? shortMessage, user);
        }
    }
}