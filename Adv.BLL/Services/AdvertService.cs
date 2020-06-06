using System;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly IConfiguration _config;

        private MemoryCacheEntryOptions MemoryCacheEntryOptions { get; }
        private const string flatRentCacheKey = "flatRent";
        private const string flatSaleCacheKey = "flatSale";
        private const string houseRentCacheKey = "houseRent";
        private const string houseSaleCacheKey = "houseSale";
        public AdvertService(IAdvertRepository advertRepository,
                             IMemoryCache memoryCache,
                             IConfiguration configuration)
        {
            this.advertRepository = advertRepository;
            this.memoryCache = memoryCache;
            _config = configuration;
            MemoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromHours(_config.GetValue<int>("MemoryCacheEntryOptions:SlidingExpiration"))
            };
        }

        public async Task<FlatRentDto> CreateFlatRentAsync(FlatRentDto flatRentDto, CancellationToken ct)
        {
            FlatRentDto advert = await advertRepository.CreateFlatRentAsync(flatRentDto, ct).ConfigureAwait(false);
            memoryCache.Set(flatRentCacheKey + advert.Id, advert, MemoryCacheEntryOptions);
            return advert;
        }

        public async Task<FlatSaleDto> CreateFlatSaleAsync(FlatSaleDto flatSaleDto, CancellationToken ct)
        {
            FlatSaleDto advert = await advertRepository.CreateFlatSaleAsync(flatSaleDto, ct).ConfigureAwait(false);
            memoryCache.Set(flatSaleCacheKey + advert.Id, advert, MemoryCacheEntryOptions);
            return advert;
        }

        public async Task<HouseRentDto> CreateHouseRentAsync(HouseRentDto houseRentDto, CancellationToken ct)
        {
            HouseRentDto advert = await advertRepository.CreateHouseRentAsync(houseRentDto, ct).ConfigureAwait(false);
            memoryCache.Set(houseRentCacheKey + advert.Id, advert, MemoryCacheEntryOptions);
            return advert;
        }

        public async Task<HouseSaleDto> CreateHouseSaleAsync(HouseSaleDto houseSaleDto, CancellationToken ct)
        {
            HouseSaleDto advert = await advertRepository.CreateHouseSaleAsync(houseSaleDto, ct).ConfigureAwait(false);
            memoryCache.Set(houseSaleCacheKey + advert.Id, advert, MemoryCacheEntryOptions);
            return advert;
        }

        public async Task<FlatRentDto> GetFlatRentAsync(int id, CancellationToken ct)
        {
            if (memoryCache.TryGetValue(flatRentCacheKey + id, out FlatRentDto advertFromCache))
            {
                return advertFromCache;
            }
            else
            {
                FlatRentDto advert = await advertRepository.GetFlatRentAsync(id, ct).ConfigureAwait(false);
                memoryCache.Set(flatRentCacheKey + advert.Id, advert, MemoryCacheEntryOptions);
                return advert;
            }
        }

        public async Task<FlatSaleDto> GetFlatSaleAsync(int id, CancellationToken ct)
        {
            if (memoryCache.TryGetValue(flatRentCacheKey + id, out FlatSaleDto advertFromCache))
            {
                return advertFromCache;
            }
            else
            {
                FlatSaleDto advert = await advertRepository.GetFlatSaleAsync(id, ct).ConfigureAwait(false);
                memoryCache.Set(flatSaleCacheKey + advert.Id, advert, MemoryCacheEntryOptions);
                return advert;
            }
        }

        public async Task<HouseRentDto> GetHouseRentAsync(int id, CancellationToken ct)
        {
            if (memoryCache.TryGetValue(houseRentCacheKey + id, out HouseRentDto advertFromCache))
            {
                return advertFromCache;
            }
            else
            {
                HouseRentDto advert = await advertRepository.GetHouseRentAsync(id, ct).ConfigureAwait(false);
                memoryCache.Set(houseRentCacheKey + advert.Id, advert, MemoryCacheEntryOptions);
                return advert;
            }
        }
        public async Task<HouseSaleDto> GetHouseSaleAsync(int id, CancellationToken ct)
        {
            if (memoryCache.TryGetValue(houseSaleCacheKey + id, out HouseSaleDto advertFromCache)
            {
                return advertFromCache;
            }
            else
            {
                HouseSaleDto advert = await advertRepository.GetHouseSaleAsync(id, ct).ConfigureAwait(false);
                memoryCache.Set(houseSaleCacheKey + advert.Id, advert, MemoryCacheEntryOptions);
                return advert;
            }
        }
    }
}
