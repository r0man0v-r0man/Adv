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
        public async Task<bool> CloudDeleteFileAsync(string fileName)
        {
            try
            {
                var container = GetBlobContainer(AzureConnectionString, ContainerName);
                if (await container.ExistsAsync().ConfigureAwait(false))
                {
                    var file = container.GetBlobReference(fileName);
                    await file.DeleteIfExistsAsync().ConfigureAwait(false);
                }
                return true;
            }
            catch
            {
                return false;
                throw;
            }
        }

        public async Task<string> CloudUploadFileAsync(IFormFile file, CancellationToken ct)
        {
            var container = GetBlobContainer(AzureConnectionString, ContainerName);
            if (await container.ExistsAsync().ConfigureAwait(false))
            {
                var blockBlob = container.GetBlockBlobReference(SetUniqueName(file));

                await blockBlob.UploadFromStreamAsync(file.OpenReadStream()).ConfigureAwait(false);

                return blockBlob.Uri.ToString();
            }
            else
            {
                throw new BadCloudUploadException($"Загрузить файл {file.FileName} не получилось! Попробуйте еще раз");
            }
        }
        /// <summary>
        /// Получаем облачный контейнер
        /// </summary>
        /// <param name="azureConnectionString">Строка подключения</param>
        /// <param name="containerName">Имя контейнера</param>
        /// <returns></returns>
        private CloudBlobContainer GetBlobContainer(string azureConnectionString, string containerName)
        {
            var storageAccount = CloudStorageAccount.Parse(azureConnectionString);

            var blobClient = storageAccount.CreateCloudBlobClient();

            return blobClient.GetContainerReference(containerName);
        }
        /// <summary>
        /// Установка уникального имени для файла
        /// </summary>
        /// <param name="file">Файл для переименования</param>
        /// <returns></returns>
        private string SetUniqueName(IFormFile file)
        {
            var uniqueName = Guid.NewGuid().ToString();
            var fileExtension = Path.GetExtension(file.FileName);
            return string.Concat(uniqueName, fileExtension);
        }

        public void Dispose()
        {
        }
    }
}
