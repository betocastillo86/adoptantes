﻿//-----------------------------------------------------------------------
// <copyright file="UserService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Adopters.Business.Exceptions;
    using Adopters.Data.Entities;
    using Beto.Core.Data;
    using Beto.Core.EventPublisher;
    using Beto.Core.Helpers;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The user service
    /// </summary>
    /// <seealso cref="Adopters.Business.Services.IUserService" />
    public class UserService : IUserService
    {
        /// <summary>
        /// The HTTP context helper
        /// </summary>
        private readonly IHttpContextHelper httpContextHelper;

        /// <summary>
        /// The publisher
        /// </summary>
        private readonly IPublisher publisher;

        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IRepository<User> userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="publisher">The publisher.</param>
        /// <param name="httpContextHelper">The HTTP context helper.</param>
        public UserService(
           IRepository<User> userRepository,
           IPublisher publisher,
           IHttpContextHelper httpContextHelper)
        {
            this.userRepository = userRepository;
            this.publisher = publisher;
            this.httpContextHelper = httpContextHelper;
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the user</returns>
        public User GetById(int id)
        {
            return this.userRepository.Table
                .Include(c => c.Location)
                .FirstOrDefault(c => c.Id == id && !c.Deleted);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The user
        /// </returns>
        public async Task<User> GetByIdAsync(int id)
        {
            return await this.userRepository.Table
                .Include(c => c.Location)
                .FirstOrDefaultAsync(c => c.Id == id && !c.Deleted);
        }

        /// <summary>
        /// Inserts the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// the task
        /// </returns>
        /// <exception cref="AdoptersException">if the email was already used</exception>
        public async Task Insert(User user)
        {
            user.CreationDate = DateTime.Now;
            user.IpAddress = this.httpContextHelper.GetCurrentIpAddress();

            try
            {
                await this.userRepository.InsertAsync(user);

                await this.publisher.EntityInserted(user);
            }
            catch (DbUpdateException e)
            {
                if (e.ToString().Contains("'IX_User'"))
                {
                    throw new AdoptersException(AdopterExceptionCode.UserEmailAlreadyUsed);
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// the task
        /// </returns>
        /// <exception cref="AdoptersException">if the email was already used</exception>
        public async Task Update(User user)
        {
            try
            {
                await this.userRepository.UpdateAsync(user);

                await this.publisher.EntityUpdated(user);
            }
            catch (DbUpdateException e)
            {
                if (e.ToString().Contains("'IX_User'"))
                {
                    throw new AdoptersException(AdopterExceptionCode.UserEmailAlreadyUsed);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}