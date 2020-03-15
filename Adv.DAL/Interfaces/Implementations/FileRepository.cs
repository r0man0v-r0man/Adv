using Adv.DAL.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Adv.DAL.Interfaces.Implementations
{
    public class FileRepository : IFileRepository
    {
        private readonly IConfiguration _config;
        private string AzureConnectionString { get; }
        private string ContainerName { get; }
        public FileRepository(IConfiguration configuration)
        {
            _config = configuration;
            AzureConnectionString = _config.GetConnectionString("AzureStorageConnectionString");
            ContainerName = "files";
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

                using var output = new MemoryStream();
                using var image = Image.Load(file.OpenReadStream());
                image.Mutate(x => x.Resize(30, 30));
                image.SaveAsJpeg(output);
                output.Position = 0;
                await blockBlob.UploadFromStreamAsync(output).ConfigureAwait(false);

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
