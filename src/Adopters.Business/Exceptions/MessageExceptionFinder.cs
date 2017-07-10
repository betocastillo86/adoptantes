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
        public string GetErrorMessage<T>(T exceptionCode)
        {
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