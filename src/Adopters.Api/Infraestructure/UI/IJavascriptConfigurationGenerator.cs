//-----------------------------------------------------------------------
// <copyright file="IJavascriptConfigurationGenerator.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Adopters.Api.Infraestructure.UI
{
    /// <summary>
    /// Interface of <c>javascript</c> generator
    /// </summary>
    public interface IJavascriptConfigurationGenerator
    {
        /// <summary>
        /// Creates the <c>javascript</c> configuration file.
        /// </summary>
        void CreateJavascriptConfigurationFile();
    }
}