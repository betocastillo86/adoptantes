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

        /// <summary>
        /// Initializes a new instance of the <see cref="AdoptersException"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        public AdoptersException(AdopterExceptionCode code) : base(ExceptionMessages.GetMessage(code))
        {
            this.Code = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdoptersException"/> class.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="error">The error.</param>
        public AdoptersException(AdopterExceptionCode code, string error) : base(error)
        {
            this.Code = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdoptersException"/> class.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="code">The code.</param>
        public AdoptersException(string target, AdopterExceptionCode code) : base(ExceptionMessages.GetMessage(code))
        {
            this.Target = target;
            this.Code = code;
        }
    }
}