using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Adv.BLL.Interfaces
{
    public interface IFileService
    {
        Task<Dictionary<string, string>> UploadAsync(IFormFile file, CancellationToken ct);
        Task<bool> DeleteAsync(string fileName);
        /// <summary>
        /// Delete all Flat's images
        /// </summary>
        /// <param name="flatsImages"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task DeleteAsync(Dictionary<string,string> flatsImages, CancellationToken ct);
    }
}
