using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Adv.BLL.DTO.Address;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Adv.BLL.Services
{
    public class YandexAddressService : IYandexAddressService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IYandexAddressRepository _yandexAddressRepository;

        private const string ProvinceCacheKey = "province";
        public YandexAddressService(IYandexAddressRepository yandexAddressRepository, IMemoryCache memoryCache)
        {
            _yandexAddressRepository = yandexAddressRepository;
            _memoryCache = memoryCache;
        }
        public async Task<IList<ComponentDto>> GetLocationsAsync()
        {
            return await _memoryCache.GetOrCreateAsync(ProvinceCacheKey, async cacheEntry =>
            {
                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(15);
                var result = await _yandexAddressRepository.GetLocationsAsync().ConfigureAwait(false);
                return result.Select(x => (ComponentDto) x).ToImmutableList();
            }).ConfigureAwait(false);
        }
    }
}
