//-----------------------------------------------------------------------
// <copyright file="NotificationService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Adopters.Business.Caching;
    using Adopters.Business.Configuration;
    using Adopters.Business.Exceptions;
    using Adopters.Data.Entities;
    using Beto.Core.Caching;
    using Beto.Core.Data;
    using Beto.Core.Data.Notifications;
    using Beto.Core.Data.Users;

    /// <summary>
    /// Notification Service
    /// </summary>
    /// <seealso cref="Adopters.Business.Services.INotificationService" />
    public class NotificationService : INotificationService
    {
        /// <summary>
        /// The cache manager
        /// </summary>
        private readonly ICacheManager cacheManager;

        /// <summary>
        /// The notification repository
        /// </summary>
        private readonly IRepository<Notification> notificationRepository;

        /// <summary>
        /// The general settings
        /// </summary>
        private readonly IGeneralSettings generalSettings;

        /// <summary>
        /// The core notification service
        /// </summary>
        private readonly ICoreNotificationService coreNotificationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationService"/> class.
        /// </summary>
        /// <param name="notificationRepository">The notification repository.</param>
        /// <param name="cacheManager">The cache manager.</param>
        /// <param name="generalSettings">The general settings.</param>
        /// <param name="coreNotificationService">The core notification service.</param>
        public NotificationService(
            IRepository<Notification> notificationRepository,
            ICacheManager cacheManager,
            IGeneralSettings generalSettings,
            ICoreNotificationService coreNotificationService)
        {
            this.notificationRepository = notificationRepository;
            this.cacheManager = cacheManager;
            this.generalSettings = generalSettings;
            this.coreNotificationService = coreNotificationService;
        }

        /// <summary>
        /// Inserts the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="userTriggerEvent">The user trigger event.</param>
        /// <param name="type">The type.</param>
        /// <param name="targetUrl">The target URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task NewNotification(User user, User userTriggerEvent, NotificationType type, string targetUrl, IList<NotificationParameter> parameters)
        {
            if (type == NotificationType.Manual)
            {
                throw new AdoptersException("Faltan los parametros 'de', asunto, y contenido");
            }

            await this.NewNotification(user, userTriggerEvent, type, targetUrl, parameters, null, null, null);
        }

        /// <summary>
        /// Inserts the notification.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <param name="userTriggerEvent">The user trigger event.</param>
        /// <param name="type">The type.</param>
        /// <param name="targetUrl">The target URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task NewNotification(IList<User> users, User userTriggerEvent, NotificationType type, string targetUrl, IList<NotificationParameter> parameters)
        {
            if (type == NotificationType.Manual)
            {
                throw new AdoptersException("Faltan los parametros 'de', asunto, y contenido");
            }

            await this.NewNotification(users, userTriggerEvent, type, targetUrl, parameters, null, null, null);
        }

        /// <summary>
        /// Inserts the specified notification.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="userTriggerEvent">The user trigger event.</param>
        /// <param name="type">The type.</param>
        /// <param name="targetUrl">The target URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="defaultFromName">The default from name.</param>
        /// <param name="defaultSubject">The default subject.</param>
        /// <param name="defaultMessage">The default message.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task NewNotification(User user, User userTriggerEvent, NotificationType type, string targetUrl, IList<NotificationParameter> parameters, string defaultFromName, string defaultSubject, string defaultMessage)
        {
            var list = new List<User>() { user };
            await this.NewNotification(list, userTriggerEvent, type, targetUrl, parameters, defaultFromName, defaultSubject, defaultMessage);
        }

        /// <summary>
        /// Inserts the specified notifications.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <param name="userTriggerEvent">The user trigger event.</param>
        /// <param name="type">The type.</param>
        /// <param name="targetUrl">The target URL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="defaultFromName">The default from name.</param>
        /// <param name="defaultSubject">The default subject.</param>
        /// <param name="defaultMessage">The default message.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task NewNotification(IList<User> users, User userTriggerEvent, NotificationType type, string targetUrl, IList<NotificationParameter> parameters, string defaultFromName, string defaultSubject, string defaultMessage)
        {
            Notification notification = null;

            if (type != NotificationType.Manual)
            {
                var notificationId = Convert.ToInt32(type);
                notification = this.GetCachedNotifications()
                    .FirstOrDefault(n => n.Id == notificationId);
            }

            var settings = new NotificationSettings()
            {
                BaseHtml = this.generalSettings.BodyBaseHtml,
                DefaultFromName = defaultFromName,
                DefaultMessage = defaultMessage,
                DefaultSubject = defaultSubject,
                IsManual = type == NotificationType.Manual,
                SiteUrl = this.generalSettings.SiteUrl
            };

            await this.coreNotificationService.NewEmailNotification<EmailNotification>(
                users.Select(c => (IUserEntity)c).ToList(),
                userTriggerEvent,
                notification,
                targetUrl,
                parameters,
                settings);
        }

        /// <summary>
        /// Gets the cached notifications.
        /// </summary>
        /// <returns>
        /// the value
        /// </returns>
        private IList<Notification> GetCachedNotifications()
        {
            return this.cacheManager.Get(
                CacheKeys.NOTIFICATIONS_ALL,
                () =>
                {
                    return this.notificationRepository.Table.ToList();
                });
        }
    }
}