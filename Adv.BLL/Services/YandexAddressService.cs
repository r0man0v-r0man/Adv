using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Adv.BLL.DTO.Address;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;

namespace Adv.BLL.Services
{
    public class YandexAddressService : IYandexAddressService
    {
        private readonly IYandexAddressRepository _yandexAddressRepository;
        public YandexAddressService(IYandexAddressRepository yandexAddressRepository)
        {
            _yandexAddressRepository = yandexAddressRepository;
        }
        public async Task<IList<IEnumerable<ComponentDto>>> GetProvinceAsync()
        {
            var provincies = await _yandexAddressRepository.GetProvinceAsync().ConfigureAwait(false);
            return new List<IEnumerable<ComponentDto>>();
        }
    }
}
