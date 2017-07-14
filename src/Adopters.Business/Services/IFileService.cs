//-----------------------------------------------------------------------
// <copyright file="IFileService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Business.Services
{
    using System.Threading.Tasks;
    using Adopters.Data.Entities;

    /// <summary>
    /// Interface of file service
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>the file</returns>
        Task<File> GetById(int id);

        /// <summary>
        /// Inserts the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="contentFile">bytes of the file</param>
        /// <returns>the task</returns>
        Task Insert(File file, byte[] contentFile);
    }
}