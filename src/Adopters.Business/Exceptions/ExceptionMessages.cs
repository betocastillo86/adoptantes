//-----------------------------------------------------------------------
// <copyright file="ExceptionMessages.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Exceptions
{
    /// <summary>
    /// Gets the exception messages
    /// </summary>
    public static class ExceptionMessages
    {
        /// <summary>
        /// Gets the exception message.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>the message</returns>
        public static string GetMessage(AdopterExceptionCode code)
        {
            switch (code)
            {
                case AdopterExceptionCode.RowNotFound:
                    return "El registro no se ha encontrado";

                case AdopterExceptionCode.BadArgument:
                    return "Argumento invalido";

                case AdopterExceptionCode.InvalidForeignKey:
                    return "El registro que se desea relacionar no existe";

                case AdopterExceptionCode.UserEmailAlreadyUsed:
                    return "El correo electrónico ya se encuentra registrado";

                case AdopterExceptionCode.InvalidIndex:
                    return "Esta llave se encuentra duplicada";

                default:
                    return null;
            }
        }
    }
}