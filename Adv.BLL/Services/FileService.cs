using Adv.BLL.Exceptions;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;
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
        private readonly IDataManager dataManager;
        public FileService(IDataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public async Task<bool> DeleteAsync(string fileName)
        {
            var result = await dataManager.Files.CloudDeleteFileAsync(fileName).ConfigureAwait(false);
            return result;
        }

        public async Task DeleteAsync(Dictionary<string, string> flatsImages, CancellationToken ct)
        {
            foreach (var image in flatsImages)
            {
                await dataManager.Files.CloudDeleteFileAsync(image.Value).ConfigureAwait(false);
            }
        }

        public async Task<string> UploadAsync(IFormFile file, CancellationToken ct)
        {
            var result = await dataManager.Files.CloudUploadFileAsync(file, ct).ConfigureAwait(false);
            return result;
        }
    }
}
