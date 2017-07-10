//-----------------------------------------------------------------------
// <copyright file="AdoptersException.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Exceptions
{
    using Beto.Core.Exceptions;

    /// <summary>
    /// Adopters Exception
    /// </summary>
    /// <seealso cref="Beto.Core.Exceptions.CoreException{Adopters.Business.Exceptions.AdopterExceptionCode}" />
    public class AdoptersException : CoreException<AdopterExceptionCode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdoptersException"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        public AdoptersException(string error) : base(error)
        {
        }
    }
}