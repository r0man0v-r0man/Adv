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

namespace Adv.BLL.Services
{
    public class FlatService : IFlatService
    {
        private readonly IDataManager _dataManager;
        public FlatService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }
        
        public async Task<FlatDTO> GetAsync(int id, CancellationToken ct = default)
        {
            var flat = await _dataManager.Flats.GetByIdAsync(id, ct).ConfigureAwait(false);
            if (flat is null)
            {
                throw new FlatNotFoundException($"Мы не нашли объявления с номером {id}");
            }
            return flat;
        }

        public async IAsyncEnumerable<FlatDTO> GetAsync(CancellationToken ct = default)
        {
            var flats = _dataManager.Flats.GetAllAsync(ct).ConfigureAwait(false);
            await foreach (var flat in flats)
            {
                yield return flat;
            }
        }

        public async IAsyncEnumerable<FlatDTO> GetAsync(int pageNumber, byte size, int skip, CancellationToken ct = default)
        {
            var flats =  _dataManager.Flats.GetAllAsync(pageNumber, size, skip, ct).ConfigureAwait(false);
            await foreach (var flat in flats)
            {
                yield return flat;
            }
        }

        public async Task<FlatDTO> CreateAsync(FlatDTO newFlat, CancellationToken ct = default)
        {
            return await _dataManager.Flats.CreateAsync(newFlat, ct).ConfigureAwait(false);
        }
    }
}
