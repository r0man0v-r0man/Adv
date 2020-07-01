using Adv.DAL.Exceptions;
using Imgur.API.Authentication.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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

        private string ImgurClientId { get; }
        private string ImgurClientSecretId { get; }

        public FileRepository(IConfiguration configuration)
        {
            _config = configuration;

            ImgurClientId = _config.GetValue<string>("Imgur:ClientId");
            ImgurClientSecretId = _config.GetValue<string>("Imgur:ClientSecretKey");
        }
        /// <summary>
        /// удаление картинки
        /// </summary>
        /// <param name="fileName">uid картинки, имя без пути и расширения</param>
        /// <returns></returns>
        public async Task<bool> DeleteFileAsync(string deleteHash)
        {
            try
            {
                var client = new ImgurClient(ImgurClientId);
                var endpoint = new ImageEndpoint(client);
                var deleted = await endpoint.DeleteImageAsync(deleteHash).ConfigureAwait(false);
                return deleted;
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
        /// <summary>
        /// Загрузка картинки 
        /// </summary>
        /// <param name="file">файл</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<IImage> UploadFileAsync(IFormFile file, CancellationToken ct)
        {
            try
            {
                var client = new ImgurClient(ImgurClientId, ImgurClientSecretId);
                var endpoint = new ImageEndpoint(client);

                return await endpoint.UploadImageStreamAsync(file.OpenReadStream()).ConfigureAwait(false);
            }
            catch (ImgurException e)
            {
                throw;
            }
        }


        public void Dispose()
        {
        }
    }
}
