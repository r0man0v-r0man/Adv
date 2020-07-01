using System.Collections.Generic;
using System.Threading.Tasks;
using Adv.BLL.DTO;

namespace Adv.BLL.Interfaces
{
    public interface IStoreCityService
    {
        Task<IEnumerable<StoreCityDto>> GetStoreCityAsync();
    }
}