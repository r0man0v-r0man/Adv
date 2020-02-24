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
        Task<string> CloudUploadFileAsync(IFormFile file, CancellationToken ct);
        Task<bool> CloudDeleteFileAsync(string fileName);
    }
}
