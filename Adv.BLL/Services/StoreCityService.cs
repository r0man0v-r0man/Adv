using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adv.BLL.DTO;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Adv.BLL.Services
{
    public class StoreCityService : IStoreCityService
    {
        private readonly IStoreCityRepository _storeCityRepository;
        private readonly IMemoryCache _memoryCache;
        
        private MemoryCacheEntryOptions MemoryCacheEntryOptions { get; }
        private const string StoreCityKey = "STORE_CITY";
        
        public StoreCityService(
            IMemoryCache memoryCache, 
            IStoreCityRepository storeCityRepository,
            IConfiguration configuration)
        {
            _storeCityRepository = storeCityRepository;
            _memoryCache = memoryCache;
            MemoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromHours(configuration.GetValue<int>("MemoryCacheEntryOptions:SlidingExpiration"))
            };
        }
        public async Task<IEnumerable<StoreCityDto>> GetStoreCityAsync()
        {
            return await _memoryCache.GetOrCreateAsync(StoreCityKey, async cacheEntry =>
            {
                cacheEntry.SlidingExpiration = MemoryCacheEntryOptions.SlidingExpiration;
                var storeCities = await _storeCityRepository
                    .GetStoreCityAsync()
                    .ConfigureAwait(false);
                return storeCities.Select(storeCity => (StoreCityDto)storeCity);
            }).ConfigureAwait(false);
        }
    }
}