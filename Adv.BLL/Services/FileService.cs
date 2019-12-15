using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adv.BLL.Services
{
    public class FileService : IFileService
    {
        public async Task<string> CloudUploadFileAsync(IFormFile file, CancellationToken ct = default)
        {
            throw new NotImplementedException();//implement upload via cloud
        }
    }
}
