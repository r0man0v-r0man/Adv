using Adv.BLL.DTO;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adv.BLL.Services
{
    public class FlatService : IFlatService
    {
        private readonly IDataManager _dataManager;
        public async Task<FlatDTO> GetAsync(int id)
        {
            var result = await _dataManager.GetFlatRepository().GetByIdAsync(id).ConfigureAwait(false);
            return new FlatDTO
            {
                Id = result.Id,
                Description = result.Description
            };
        }
    }
}
