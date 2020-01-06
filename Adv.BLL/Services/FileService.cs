using Adv.BLL.Exceptions;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adv.BLL.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _config;
        private string AzureConnectionString { get; }
        private string ContainerName { get; }
        public FileService(IConfiguration configuration)
        {
            _config = configuration;
            AzureConnectionString = _config.GetConnectionString("AzureStorageConnectionString");
            ContainerName = "files";
        }
        public async Task<string> CloudUploadFileAsync(IFormFile file, CancellationToken ct = default)
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

        public async Task<bool> CloudDeleteFileAsync(string fileName)
        {
            try
            {
                var container = GetBlobContainer(AzureConnectionString, ContainerName);
                if (await container.ExistsAsync().ConfigureAwait(false))
                {
                    var file = container.GetBlobReference(fileName);
                    if (await file.ExistsAsync().ConfigureAwait(false))
                    {
                        await file.DeleteAsync().ConfigureAwait(false);
                    }
                }
                return true;
            }
            catch
            {
                return false;
                throw;
            }
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
    }
}
