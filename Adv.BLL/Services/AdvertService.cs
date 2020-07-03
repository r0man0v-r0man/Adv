using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Adv.BLL.DTO;
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
        public AdvertService(IAdvertRepository advertRepository,
                             IMemoryCache memoryCache,
                             IConfiguration configuration)
        {
            this.advertRepository = advertRepository;
            this.memoryCache = memoryCache;
            MemoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromHours(configuration.GetValue<int>("MemoryCacheEntryOptions:SlidingExpiration"))
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
        // public async Task<IEnumerable<FlatRentDto>> GetFlatRentsAsync(int pageNumber, CityDto city)
        // {
        //     var adverts = await advertRepository.GetFlatRents(pageNumber, city).ConfigureAwait(false);
        //
        //     return adverts.Select(advert => (FlatRentDto)advert);
        // }
        //
        // public async Task<IEnumerable<FlatSaleDto>> GetFlatSalesAsync(int pageNumber, CityDto city)
        // {
        //     var adverts = await advertRepository.GetFlatSales(pageNumber, city).ConfigureAwait(false);
        //
        //     return adverts.Select(advert => (FlatSaleDto)advert);
        // }
        //
        // public async Task<IEnumerable<HouseRentDto>> GetHouseRentsAsync(int pageNumber, CityDto city)
        // {
        //     var adverts = await advertRepository.GetHouseRents(pageNumber, city).ConfigureAwait(false);
        //
        //     return adverts.Select(advert => (HouseRentDto)advert);
        // }
        //
        // public async Task<IEnumerable<HouseSaleDto>> GetHouseSalesAsync(int pageNumber, CityDto city)
        // {
        //     var adverts = await advertRepository.GetHouseSales(pageNumber, city).ConfigureAwait(false);
        //
        //     return adverts.Select(advert => (HouseSaleDto)advert);
        // }

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
        
    }
}
