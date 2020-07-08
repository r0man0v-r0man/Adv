using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IList<string>> GetProvinceAsync()
        {
            return await _memoryCache.GetOrCreateAsync(ProvinceCacheKey, async cacheEntry =>
            {
                cacheEntry.SlidingExpiration = TimeSpan.FromHours(2);
                return await _yandexAddressRepository.GetProvinceAsync().ConfigureAwait(false);
            }).ConfigureAwait(false);
        }
    }
}
