using Adv.DAL.Exceptions;
using Imgur.API.Authentication.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;

namespace Adv.DAL.Interfaces.Implementations
{
    public class FileRepository : IFileRepository
    {
        private readonly IConfiguration _config;
        private string AzureConnectionString { get; }
        private string ContainerName { get; }

        private string ImgurClientId { get; }
        private string ImgurClientSecretId { get; }

        public FileRepository(IConfiguration configuration)
        {
            _config = configuration;
            AzureConnectionString = _config.GetConnectionString("AzureStorageConnectionString");
            ContainerName = "files";

            ImgurClientId = _config.GetValue<string>("Imgur:ClientId");
            ImgurClientSecretId = _config.GetValue<string>("Imgur:ClientSecretKey");
        }
        /// <summary>
        /// удаление картинки
        /// </summary>
        /// <param name="fileName">uid картинки, имя без пути и расширения</param>
        /// <returns></returns>
        public async Task<bool> DeleteFileAsync(string fileName)
        {
            var client = new ImgurClient(ImgurClientId, ImgurClientSecretId);
            var endpoint = new ImageEndpoint(client);
            var deleted = await endpoint.DeleteImageAsync(fileName).ConfigureAwait(false);
            return deleted;
        }
        /// <summary>
        /// Загрузка картинки 
        /// </summary>
        /// <param name="file">файл</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<string> UploadFileAsync(IFormFile file, CancellationToken ct)
        {
            try
            {
                var client = new ImgurClient(ImgurClientId, ImgurClientSecretId);
                var endpoint = new ImageEndpoint(client);
                IImage image;
                image = await endpoint.UploadImageStreamAsync(file.OpenReadStream()).ConfigureAwait(false);
                

                return image.Link;
            }
            catch (ImgurException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public void Dispose()
        {
        }
    }
}
