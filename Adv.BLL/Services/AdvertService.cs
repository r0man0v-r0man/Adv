using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Adv.BLL.DTO.Address;
using Adv.BLL.DTO.Adverts;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Adv.BLL.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IAdvertRepository advertRepository;
        private readonly IMemoryCache memoryCache;

        private MemoryCacheEntryOptions MemoryCacheEntryOptions { get; }
        private const string flatRentCacheKey = "flatRent";
        private const string flatSaleCacheKey = "flatSale";
        private const string houseRentCacheKey = "houseRent";
        private const string houseSaleCacheKey = "houseSale";

        private const string lastFlatRentCacheKey = "lastFlatRent";
        private const string lastFlatSaleCacheKey = "lastFlatSale";
        private const string lastHouseRentCacheKey = "lastHouseRent";
        private const string lastHouseSaleCacheKey = "lastHouseSale";

        private const string userAdvertsKey = "userAdverts";
        public AdvertService(IAdvertRepository advertRepository,
                             IMemoryCache memoryCache,
                             IConfiguration configuration)
        {
            this.advertRepository = advertRepository;
            this.memoryCache = memoryCache;
            MemoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromHours(configuration.GetValue<int>("MemoryCacheEntryOptions:SlidingExpiration")),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };
        }

        public async Task<int> CreateFlatRentAsync(FlatRentDto flatRentDto, CancellationToken ct)
        {
            return await advertRepository.CreateFlatRentAsync(flatRentDto, ct).ConfigureAwait(false);
        }

        public async Task<int> CreateFlatSaleAsync(FlatSaleDto flatSaleDto, CancellationToken ct)
        {
            return await advertRepository.CreateFlatSaleAsync(flatSaleDto, ct).ConfigureAwait(false);
        }

        public async Task<int> CreateHouseRentAsync(HouseRentDto houseRentDto, CancellationToken ct)
        {
            return await advertRepository.CreateHouseRentAsync(houseRentDto, ct).ConfigureAwait(false);
        }

        public async Task<int> CreateHouseSaleAsync(HouseSaleDto houseSaleDto, CancellationToken ct)
        {
            return await advertRepository.CreateHouseSaleAsync(houseSaleDto, ct).ConfigureAwait(false);
        }

        public async Task<FlatRentDto> GetFlatRentAsync(int id, CancellationToken ct)
        {
            return await memoryCache.GetOrCreateAsync(flatRentCacheKey + id, async cacheEntry =>
            {
                cacheEntry.SlidingExpiration = MemoryCacheEntryOptions.SlidingExpiration;
                FlatRentDto advert = await advertRepository.GetFlatRentAsync(id, ct).ConfigureAwait(false);
                return advert;
            }).ConfigureAwait(false);
            
        }

        public async Task<FlatSaleDto> GetFlatSaleAsync(int id, CancellationToken ct)
        {
            return await memoryCache.GetOrCreateAsync(flatSaleCacheKey + id, async cacheEntry =>
            {
                cacheEntry.SlidingExpiration = MemoryCacheEntryOptions.SlidingExpiration;
                FlatSaleDto advert = await advertRepository.GetFlatSaleAsync(id, ct).ConfigureAwait(false);
                return advert;
            }).ConfigureAwait(false);
            
        }

        public async Task<HouseRentDto> GetHouseRentAsync(int id, CancellationToken ct)
        {
            return await memoryCache.GetOrCreateAsync(houseRentCacheKey + id, async cacheEntry =>
            {
                cacheEntry.SlidingExpiration = MemoryCacheEntryOptions.SlidingExpiration;
                HouseRentDto advert = await advertRepository.GetHouseRentAsync(id, ct).ConfigureAwait(false);
                return advert;
            }).ConfigureAwait(false);
           
        }
        public async Task<HouseSaleDto> GetHouseSaleAsync(int id, CancellationToken ct)
        {
            return await memoryCache.GetOrCreateAsync(houseSaleCacheKey + id, async cacheEntry =>
            {
                cacheEntry.SlidingExpiration = MemoryCacheEntryOptions.SlidingExpiration;
                HouseSaleDto advert = await advertRepository.GetHouseSaleAsync(id, ct).ConfigureAwait(false);
                return advert;
            }).ConfigureAwait(false);
          
        }
        public async Task<IEnumerable<FlatRentDto>> GetFlatRentsAsync(int pageNumber, ComponentDto province)
        {
            var adverts = await advertRepository.GetFlatRents(pageNumber, province).ConfigureAwait(false);

            return adverts.Select(advert => (FlatRentDto)advert);
        }

        public async Task<IEnumerable<FlatSaleDto>> GetFlatSalesAsync(int pageNumber, ComponentDto province)
        {
            var adverts = await advertRepository.GetFlatSales(pageNumber, province).ConfigureAwait(false);

            return adverts.Select(advert => (FlatSaleDto)advert);
        }

        public async Task<IEnumerable<HouseRentDto>> GetHouseRentsAsync(int pageNumber, ComponentDto province)
        {
            var adverts = await advertRepository.GetHouseRents(pageNumber, province).ConfigureAwait(false);

            return adverts.Select(advert => (HouseRentDto)advert);
        }

        public async Task<IEnumerable<HouseSaleDto>> GetHouseSalesAsync(int pageNumber, ComponentDto province)
        {
            var adverts = await advertRepository.GetHouseSales(pageNumber, province).ConfigureAwait(false);

            return adverts.Select(advert => (HouseSaleDto)advert);
        }

        public async Task<IEnumerable<FlatRentDto>> GetAnyFlatRentsAsync(int pageNumber)
        {
            var adverts = await advertRepository.GetAnyFlatRentsAsync(pageNumber).ConfigureAwait(false);
            return adverts.Select(advert => (FlatRentDto)advert);
        }

        public async Task<IEnumerable<FlatSaleDto>> GetAnyFlatSalesAsync(int pageNumber)
        {
            var adverts = await advertRepository.GetAnyFlatSalesAsync(pageNumber).ConfigureAwait(false);
            return adverts.Select(advert => (FlatSaleDto)advert);
        }

        public async Task<IEnumerable<HouseRentDto>> GetAnyHouseRentsAsync(int pageNumber)
        {
            var adverts = await advertRepository.GetAnyHouseRentsAsync(pageNumber).ConfigureAwait(false);
            return adverts.Select(advert => (HouseRentDto)advert);
        }

        public async Task<IEnumerable<HouseSaleDto>> GetAnyHouseSalesAsync(int pageNumber)
        {
            var adverts = await advertRepository.GetAnyHouseSalesAsync(pageNumber).ConfigureAwait(false);
            return adverts.Select(advert => (HouseSaleDto)advert);
        }

        public async Task<FlatRentDto> GetLastFlatRentAsync()
        {
            return await memoryCache.GetOrCreateAsync(lastFlatRentCacheKey, async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = MemoryCacheEntryOptions.AbsoluteExpirationRelativeToNow;
                FlatRentDto advert = await advertRepository.GetLastFlatRentAsync().ConfigureAwait(false);
                return advert;
            }).ConfigureAwait(false);
        }

        public async Task<FlatSaleDto> GetLastFlatSaleAsync()
        {
            return await memoryCache.GetOrCreateAsync(lastFlatSaleCacheKey, async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = MemoryCacheEntryOptions.AbsoluteExpirationRelativeToNow;
                FlatSaleDto advert = await advertRepository.GetLastFlatSaleAsync().ConfigureAwait(false);
                return advert;
            }).ConfigureAwait(false);
        }

        public async Task<HouseRentDto> GetLastHouseRentAsync()
        {
            return await memoryCache.GetOrCreateAsync(lastHouseRentCacheKey, async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = MemoryCacheEntryOptions.AbsoluteExpirationRelativeToNow;
                HouseRentDto advert = await advertRepository.GetLastHouseRentAsync().ConfigureAwait(false);
                return advert;
            }).ConfigureAwait(false);
        }

        public async Task<HouseSaleDto> GetLastHouseSaleAsync()
        {
            return await memoryCache.GetOrCreateAsync(lastHouseSaleCacheKey, async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = MemoryCacheEntryOptions.AbsoluteExpirationRelativeToNow;
                HouseSaleDto advert = await advertRepository.GetLastHouseSaleAsync().ConfigureAwait(false);
                return advert;
            }).ConfigureAwait(false);
        }

        public async Task<Dictionary<string, Dictionary<int, string>>> GetUserAdvertsAsync(string userId, CancellationToken ct = default)
        {
            return await memoryCache.GetOrCreateAsync(userAdvertsKey + userId, async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = MemoryCacheEntryOptions.AbsoluteExpirationRelativeToNow;
                return await advertRepository.GetUserAdvertsAsync(userId, ct).ConfigureAwait(false);
            }).ConfigureAwait(false);
        }
    }
}
