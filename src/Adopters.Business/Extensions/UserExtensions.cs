//-----------------------------------------------------------------------
// <copyright file="UserExtensions.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Extensions
{
    using Adopters.Data.Entities;

    /// <summary>
    /// User extensions
    /// </summary>
    public static class UserExtensions
    {
        /// <summary>
        /// Determines whether this instance is admin.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        ///   <c>true</c> if the specified user is admin; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAdmin(this User user)
        {
            return user.Role == Role.Admin;
        }
    }
}