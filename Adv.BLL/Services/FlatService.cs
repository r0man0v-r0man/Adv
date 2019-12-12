using Adv.BLL.DTO;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            var result = await _dataManager.Flats.GetByIdAsync(id, ct).ConfigureAwait(false);
            return new FlatDTO
            {
                Id = result.Id,
                Description = result.Description
            };
        }

        public async IAsyncEnumerable<FlatDTO> GetAsync(CancellationToken ct = default)
        {
            var flats = _dataManager.Flats.GetAllAsync(ct).ConfigureAwait(false);
            await foreach (var flat in flats)
            {
                yield return new FlatDTO
                {
                    Id = flat.Id,
                    Description = flat.Description
                };
            }
        }
    }
}
