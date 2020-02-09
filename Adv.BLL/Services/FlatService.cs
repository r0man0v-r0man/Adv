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
        private readonly IDataManager _dataManager;
        public FlatService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }
        /// <summary>
        /// Return flat
        /// </summary>
        /// <param name="flatId">Flat Id</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<FlatDTO> GetAsync(int flatId, CancellationToken ct)
        {
            var flat = await _dataManager.Flats.GetByIdAsync(flatId, ct).ConfigureAwait(false);
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
        public async IAsyncEnumerable<FlatDTO> GetAllAsync(int pageNumber, byte size, int skip, [EnumeratorCancellation] CancellationToken ct)
        {
            var flats =  _dataManager.Flats.GetAllAsync(pageNumber, size, skip, ct).ConfigureAwait(false);

            await foreach (var flat in flats.WithCancellation(ct))
            {
                yield return flat;
            }
        }

        public async Task<FlatDTO> CreateAsync(FlatDTO newFlat, CancellationToken ct)
        {
            if (newFlat is null)
            {
                throw new ArgumentNullException(nameof(newFlat));
            }

            var result = await _dataManager.Flats.CreateAsync(newFlat, ct).ConfigureAwait(false);
            
            return result;
        }

        public async Task<bool> DeleteAsync(int flatId, CancellationToken ct)
        {
            FlatDTO flat = await _dataManager.Flats.GetByIdAsync(flatId, ct).ConfigureAwait(false);
            var tasks = new List<Task<bool>>();

            foreach (var image in flat.Images)
            {
                tasks.Add(_dataManager.Files.CloudDeleteFileAsync(Path.GetFileName(image.Value)));
            }
            tasks.Add(_dataManager.Flats.RemoveAsync(flat, ct));
            var result = await Task.WhenAll(tasks).ConfigureAwait(false);

            return result.All(x => x == true) ? true : false;
        }
    }
}
