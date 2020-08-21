using Adv.DAL.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;
using Imgur.API.Endpoints;
using Imgur.API.Models;

namespace Adv.DAL.Interfaces.Implementations
{
    public class FileRepository : IFileRepository
    {
        private readonly IImageEndpoint _imageEndpoint;
        public FileRepository(IImageEndpoint imageEndpoint)
        {
            _imageEndpoint = imageEndpoint;
        }
        /// <summary>
        /// удаление картинки
        /// </summary>
        /// <param name="fileName">uid картинки, имя без пути и расширения</param>
        /// <returns></returns>
        public async Task<bool> DeleteFileAsync(string deleteHash)
        {
            try
            {
                var deleted = await _imageEndpoint.DeleteImageAsync(deleteHash).ConfigureAwait(false);
                return deleted;
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
        /// <summary>
        /// Загрузка картинки 
        /// </summary>
        /// <param name="file">файл</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<IImage> UploadFileAsync(IFormFile file, CancellationToken ct)
        {
            try
            {
                return await _imageEndpoint.UploadImageAsync(file?.OpenReadStream(), cancellationToken: ct).ConfigureAwait(false);
            }
            catch (ImgurException e)
            {
                throw;
            }
        }


        public void Dispose()
        {
        }
    }
}
