//-----------------------------------------------------------------------
// <copyright file="MessageExceptionFinder.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Exceptions
{
    using Beto.Core.Exceptions;

    /// <summary>
    /// Service that finds a error message of a Adopters Exception Code
    /// </summary>
    /// <seealso cref="Beto.Core.Exceptions.IMessageExceptionFinder" />
    public class MessageExceptionFinder : IMessageExceptionFinder
    {
        /// <summary>
        /// Gets the error message
        /// </summary>
        /// <typeparam name="T">the enumeration type error</typeparam>
        /// <param name="exceptionCode">the exception type</param>
        /// <returns>the error message</returns>
        public string GetErrorMessage<T>(T exceptionCode)
        {
            ////TODO:Implementar
            if (exceptionCode is AdopterExceptionCode)
            {
                return string.Empty;
            }
            else
            {
                return null;
            }
        }
    }
}