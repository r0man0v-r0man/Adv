using Adv.BLL.DTO;
using Adv.BLL.Exceptions;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public FlatService(IDataManager dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }
        
        public async Task<FlatDTO> GetAsync(int id, CancellationToken ct = default)
        {
            var flarDAL = await _dataManager.Flats.GetByIdAsync(id, ct).ConfigureAwait(false);
            if (flarDAL is null)
            {
                throw new FlatNotFoundException($"Мы не нашли объявления с номером {id}");
            }
            return _mapper.Map<FlatDTO>(flarDAL);
        }

        public async IAsyncEnumerable<FlatDTO> GetAsync(CancellationToken ct = default)
        {
            var flatsDAL = _dataManager.Flats.GetAllAsync(ct).ConfigureAwait(false);
            await foreach (var flatDAL in flatsDAL)
            {
                yield return _mapper.Map<FlatDTO>(flatDAL);
            }
        }
    }
}
