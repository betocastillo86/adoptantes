﻿//-----------------------------------------------------------------------
// <copyright file="ReportExtensions.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Models
{
    using System;
    using System.Collections.Generic;
    using Adopters.Data.Entities;
    using Beto.Core.Data.Files;

    /// <summary>
    /// Report Extensions for models
    /// </summary>
    public static class ReportExtensions
    {
        /// <summary>
        /// To the base model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="filesHelper">The files helper.</param>
        /// <param name="contentUrlFunction">The content URL function.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>the model</returns>
        public static BaseReportModel ToBaseModel(
            this Report entity,
            IFilesHelper filesHelper = null,
            Func<string, string> contentUrlFunction = null,
            int width = 0,
            int height = 0)
        {
            return new BaseReportModel()
            {
                Id = entity.Id,
                CountComments = entity.CountComments,
                CountDislikes = entity.CountDislikes,
                CountLikes = entity.CountLikes,
                CreationDate = entity.CreationDate,
                Description = entity.Description,
                Email = entity.Email,
                FacebookProfile = entity.FacebookProfile,
                Image = entity.FileId.HasValue ? entity.File.ToModel(filesHelper, contentUrlFunction, width, height) : null,
                Location = entity.Location.ToModel(),
                Name = entity.Name,
                Positive = entity.Positive,
                TwitterProfile = entity.TwitterProfile,
                User = entity.User.ToBaseModel()
            };
        }

        /// <summary>
        /// To the models.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <param name="filesHelper">The files helper.</param>
        /// <param name="contentUrlFunction">The content URL function.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>the models</returns>
        public static IList<BaseReportModel> ToModels(
            this ICollection<Report> entities,
            IFilesHelper filesHelper = null,
            Func<string, string> contentUrlFunction = null,
            int width = 0,
            int height = 0)
        {
            var models = new List<BaseReportModel>();

            foreach (var entity in entities)
            {
                models.Add(entity.ToBaseModel(filesHelper, contentUrlFunction, width, height));
            }

            return models;
        }
    }
}