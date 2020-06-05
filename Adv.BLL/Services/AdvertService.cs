using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Adv.BLL.DTO.Adverts;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;

namespace Adv.BLL.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IAdvertRepository advertRepository;

        public AdvertService(IAdvertRepository advertRepository)
        {
            this.advertRepository = advertRepository;
        }

        public async Task<FlatRentDto> CreateFlatRentAsync(FlatRentDto flatRentDto, CancellationToken ct)
        {
            return await advertRepository.CreateFlatRentAsync(flatRentDto, ct).ConfigureAwait(false);
        }

        public async Task<FlatSaleDto> CreateFlatSaleAsync(FlatSaleDto flatSaleDto, CancellationToken ct)
        {
            return await advertRepository.CreateFlatSaleAsync(flatSaleDto, ct).ConfigureAwait(false);
        }

        public async Task<HouseRentDto> CreateHouseRentAsync(HouseRentDto houseRentDto, CancellationToken ct)
        {
            return await advertRepository.CreateHouseRentAsync(houseRentDto, ct).ConfigureAwait(false);
        }

        public async Task<HouseSaleDto> CreateHouseSaleAsync(HouseSaleDto houseSaleDto, CancellationToken ct)
        {
            return await advertRepository.CreateHouseSaleAsync(houseSaleDto, ct).ConfigureAwait(false);
        }

        public async Task<FlatRentDto> GetFlatRentAsync(int id, CancellationToken ct)
        {
            return await advertRepository.GetFlatRentAsync(id, ct).ConfigureAwait(false);
        }

        public async Task<FlatSaleDto> GetFlatSaleAsync(int id, CancellationToken ct)
        {
            return await advertRepository.GetFlatSaleAsync(id, ct).ConfigureAwait(false);
        }

        public async Task<HouseRentDto> GetHouseRentAsync(int id, CancellationToken ct)
        {
            return await advertRepository.GetHouseRentAsync(id, ct).ConfigureAwait(false);
        }
    }
}
