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
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the user</returns>
        User GetById(int id);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The user</returns>
        Task<User> GetByIdAsync(int id);

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