using Adv.BLL.DTO;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adv.BLL.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        public async Task<IEnumerable<CityDto>> GetCitiesAsync()
        {
            var cities = await cityRepository.GetCitiesAsync().ConfigureAwait(false);
            return cities.Select(city => (CityDto)city);
        }
    }
}
