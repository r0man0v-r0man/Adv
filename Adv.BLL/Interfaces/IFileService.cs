using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Adv.BLL.Interfaces
{
    public interface IFileService
    {
        Task<string> CloudUploadFileAsync(IFormFile file, CancellationToken ct);
        Task<bool> CloudDeleteFileAsync(string fileName);
    }
}
