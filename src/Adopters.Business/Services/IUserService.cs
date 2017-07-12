//-----------------------------------------------------------------------
// <copyright file="IUserService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using System.Threading.Tasks;
    using Adopters.Data.Entities;

    /// <summary>
    /// The interface of user service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Inserts the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>the task</returns>
        Task Insert(User user);

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>the task</returns>
        Task Update(User user);
    }
}