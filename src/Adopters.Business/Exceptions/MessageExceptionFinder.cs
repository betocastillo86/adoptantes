//-----------------------------------------------------------------------
// <copyright file="MessageExceptionFinder.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Exceptions
{
    using System;
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
                var enumerator = Enum.Parse(typeof(AdopterExceptionCode), exceptionCode.ToString());

                switch (enumerator)
                {
                    case AdopterExceptionCode.BadArgument:
                        return "Argument mal enviado";
                    case AdopterExceptionCode.ErrorTryingExternalLogin:
                        return "Error autenticando con external login";
                    case AdopterExceptionCode.UserEmailAlreadyUsed:
                        return "El correo ya está siendo usado";
                    case AdopterExceptionCode.InvalidExternalAuthenticationProvider:
                        return "El proveedor de autenticación no es valido";
                    case AdopterExceptionCode.InvalidForeignKey:
                        return "Llave mal relacionada";
                    case AdopterExceptionCode.InvalidIndex:
                        return "Indice invalido";
                    case AdopterExceptionCode.RowNotFound:
                        return "Fila no encontrada";
                    default:
                        return string.Empty;
                }
            }
            else
            {
                return null;
            }
        }
    }
}