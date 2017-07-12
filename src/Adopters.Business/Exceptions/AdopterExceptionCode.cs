//-----------------------------------------------------------------------
// <copyright file="AdopterExceptionCode.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Exceptions
{
    /// <summary>
    /// Adopter exception codes
    /// </summary>
    public enum AdopterExceptionCode
    {
        /// <summary>
        /// A bad argument in a request
        /// </summary>
        BadArgument = 1,

        /// <summary>
        /// The error trying external login
        /// </summary>
        ErrorTryingExternalLogin = 50,

        /// <summary>
        /// The user email already used
        /// </summary>
        UserEmailAlreadyUsed = 51,

        /// <summary>
        /// The invalid external authentication provider
        /// </summary>
        InvalidExternalAuthenticationProvider = 53,

        /// <summary>
        /// The invalid foreign key
        /// </summary>
        InvalidForeignKey = 100,

        /// <summary>
        /// The invalid index
        /// </summary>
        InvalidIndex = 101,

        /// <summary>
        /// The row not found
        /// </summary>
        RowNotFound = 102
    }
}