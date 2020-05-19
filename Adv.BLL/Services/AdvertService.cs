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
            var result = await advertRepository.CreateFlatRentAsync(flatRentDto, ct).ConfigureAwait(false);
            return result;
        }
    }
}
