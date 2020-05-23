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

        public async Task<HouseRentDTO> CreateHouseRentAsync(HouseRentDTO houseRentDto, CancellationToken ct)
        {
            return await advertRepository.CreateHouseRentAsync(houseRentDto, ct).ConfigureAwait(false);
        }
    }
}
