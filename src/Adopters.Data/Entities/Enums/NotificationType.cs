//-----------------------------------------------------------------------
// <copyright file="NotificationType.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Data.Entities
{
    /// <summary>
    /// The Notification Type
    /// </summary>
    public enum NotificationType
    {
        /// <summary>
        /// The manual
        /// </summary>
        Manual = 0,

        /// <summary>
        /// The welcome
        /// </summary>
        Welcome = 1,

        /// <summary>
        /// A comment in my report
        /// </summary>
        NewCommentOnReport = 18,

        /// <summary>
        /// New child comment on my comment
        /// </summary>
        NewSubcommentOnMyComment = 19,

        /// <summary>
        /// New comment on someone else comment
        /// </summary>
        NewSubcommentOnSomeoneElseComment = 20,
    }
}