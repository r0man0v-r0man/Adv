using System.Collections.Generic;
using System.Threading.Tasks;
using Adv.DAL.Entities;

namespace Adv.DAL.Interfaces
{
    public interface IStoreCityRepository : IBaseRepository
    {
        Task<IEnumerable<StoreCity>> GetStoreCityAsync();
    }
}