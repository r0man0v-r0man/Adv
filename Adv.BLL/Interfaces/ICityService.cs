using Adv.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adv.BLL.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetCitiesAsync();
    }
}
