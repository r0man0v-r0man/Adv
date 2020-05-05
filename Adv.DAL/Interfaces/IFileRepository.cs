using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adv.DAL.Interfaces
{
    public interface IFileRepository : IBaseRepository
    {
        Task<bool> DeleteFileAsync(string fileName);
        Task<string> UploadFileAsync(IFormFile file, CancellationToken ct);
    }
}
