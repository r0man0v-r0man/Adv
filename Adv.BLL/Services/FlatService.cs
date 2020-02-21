using Adv.BLL.DTO;
using Adv.BLL.Exceptions;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Adv.DAL.Entities;
using System.Runtime.CompilerServices;
using System.IO;
using System.Linq;

namespace Adv.BLL.Services
{
    public class FlatService : IFlatService
    {
        private readonly IFlatRepository flatRepository;
        private readonly IFileRepository fileRepository;
        public FlatService(IFlatRepository flatRepository, IFileRepository fileRepository)
        {
            this.flatRepository = flatRepository;
            this.fileRepository = fileRepository;
        }
        /// <summary>
        /// Return flat
        /// </summary>
        /// <param name="flatId">Flat Id</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<FlatDTO> GetAsync(int flatId, CancellationToken ct)
        {
            var flat = await flatRepository.GetByIdAsync(flatId, ct).ConfigureAwait(false);
            return flat;
        }

        /// <summary>
        /// Returns all flats from flatRepository
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="size"></param>
        /// <param name="skip"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<List<FlatDTO>> GetAllAsync(int pageNumber, byte size, int skip, CancellationToken ct)
        {
            var flats = await flatRepository.GetAllAsync(pageNumber, size, skip, ct).ConfigureAwait(false);

            return flats.Select(flat => (FlatDTO) flat).ToList();
        }

        public async Task<FlatDTO> CreateAsync(FlatDTO newFlat, CancellationToken ct)
        {
            if (newFlat is null)
            {
                throw new ArgumentNullException(nameof(newFlat));
            }

            var result = await flatRepository.CreateAsync(newFlat, ct).ConfigureAwait(false);
            
            return result;
        }

        public async Task<bool> DeleteAsync(int flatId, CancellationToken ct)
        {
            FlatDTO flat = await flatRepository.GetByIdAsync(flatId, ct).ConfigureAwait(false);
            var tasks = flat.Images.Select(image => fileRepository.CloudDeleteFileAsync(Path.GetFileName(image.Value))).ToList();

            tasks.Add(flatRepository.RemoveAsync(flat, ct));
            var result = await Task.WhenAll(tasks).ConfigureAwait(false);

            return result.All(x => x == true) ? true : false;
        }

        public async Task<bool> UpdateAsync(FlatDTO updatedFlat, CancellationToken ct)
        {
            var result = await flatRepository.UpdateAsync(updatedFlat, ct).ConfigureAwait(false);
            return result;
        }
    }
}
