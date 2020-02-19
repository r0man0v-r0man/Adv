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
        private readonly IFileRepository fileRepository;
        public FileService(IFileRepository fileRepository)
        {
            this.fileRepository = fileRepository;
        }
        public async Task<bool> DeleteAsync(string fileName)
        {
            var result = await fileRepository.CloudDeleteFileAsync(fileName).ConfigureAwait(false);
            return result;
        }

        public async Task DeleteAsync(Dictionary<string, string> flatsImages, CancellationToken ct)
        {
            foreach (var image in flatsImages)
            {
                await fileRepository.CloudDeleteFileAsync(image.Value).ConfigureAwait(false);
            }
        }

        public async Task<string> UploadAsync(IFormFile file, CancellationToken ct)
        {
            var result = await fileRepository.CloudUploadFileAsync(file, ct).ConfigureAwait(false);
            return result;
        }
    }
}
