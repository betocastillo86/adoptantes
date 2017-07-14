//-----------------------------------------------------------------------
// <copyright file="FileService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using System.Threading.Tasks;
    using Adopters.Business.Configuration;
    using Adopters.Data.Entities;
    using Beto.Core.Data;
    using Beto.Core.Data.Files;
    using Beto.Core.EventPublisher;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// File Service
    /// </summary>
    /// <seealso cref="Adopters.Business.Services.IFileService" />
    public class FileService : IFileService
    {
        /// <summary>
        /// The file helper
        /// </summary>
        private readonly IFilesHelper fileHelper;

        /// <summary>
        /// The file repository
        /// </summary>
        private readonly IRepository<File> fileRepository;

        /// <summary>
        /// The general settings
        /// </summary>
        private readonly IGeneralSettings generalSettings;

        /// <summary>
        /// The publisher
        /// </summary>
        private readonly IPublisher publisher;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileService"/> class.
        /// </summary>
        /// <param name="fileRepository">The file repository.</param>
        /// <param name="publisher">The publisher.</param>
        /// <param name="fileHelper">The file helper.</param>
        /// <param name="generalSettings">The general settings.</param>
        public FileService(
            IRepository<File> fileRepository,
            IPublisher publisher,
            IFilesHelper fileHelper,
            IGeneralSettings generalSettings)
        {
            this.fileRepository = fileRepository;
            this.publisher = publisher;
            this.fileHelper = fileHelper;
            this.generalSettings = generalSettings;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// the file
        /// </returns>
        public async Task<File> GetById(int id)
        {
            return await this.fileRepository.Table.FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Inserts the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="contentFile">bytes of the file</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task Insert(File file, byte[] contentFile)
        {
            await this.fileRepository.InsertAsync(file);

            await this.publisher.EntityInserted(file);

            this.fileHelper.SaveFile(file, contentFile, this.generalSettings.DefaultPictureWidth, this.generalSettings.DefaultPictureHeight);
        }
    }
}