using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities.Adverts;
using Adv.DAL.Exceptions;

namespace Adv.DAL.Interfaces.Implementations
{
    public class AdvertRepository : IAdvertRepository
    {
        private readonly IContextFactory contextFactory;

        public AdvertRepository(IContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public void Dispose()
        {
            
        }
        /// <summary>
        /// создание объявления квартира-сдать
        /// </summary>
        /// <param name="flatRent"></param>
        /// <param name="ct"></param>
        /// <returns>объявление</returns>
        public async Task<FlatRent> CreateFlatRentAsync(FlatRent flatRent, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();
            await context.FlatRents.AddAsync(flatRent, ct).ConfigureAwait(false);
            var result = await context.SaveChangesAsync(ct).ConfigureAwait(false);
            return result >= 0 ? flatRent : throw new BadCreateException("Мы не смогли создать объявление");
        }

    }
}
