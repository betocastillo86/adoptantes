//-----------------------------------------------------------------------
// <copyright file="LoggerService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Exceptions
{
    using System.Threading.Tasks;
    using Beto.Core.Exceptions;

    /// <summary>
    /// Logger Service of Adopters
    /// </summary>
    /// <seealso cref="Beto.Core.Exceptions.ILoggerService" />
    public class LoggerService : ILoggerService
    {
        /// <summary>
        /// Inserts the specified short message.
        /// </summary>
        /// <param name="shortMessage">The short message.</param>
        /// <param name="fullMessage">The full message.</param>
        public void Insert(string shortMessage, string fullMessage = "")
        {
            ////TODO: Implementar
        }

        /// <summary>
        /// Inserts the asynchronous.
        /// </summary>
        /// <param name="shortMessage">The short message.</param>
        /// <param name="fullMessage">The full message.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task InsertAsync(string shortMessage, string fullMessage = "")
        {
            ////TODO: Implementar
            await Task.FromResult(0);
        }
    }
}