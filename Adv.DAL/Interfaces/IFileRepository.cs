using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using Imgur.API.Models;

namespace Adv.DAL.Interfaces
{
    public interface IFileRepository : IBaseRepository
    {
        Task<bool> DeleteFileAsync(string deleteHash);
        Task<IImage> UploadFileAsync(IFormFile file, CancellationToken ct);
    }
}
