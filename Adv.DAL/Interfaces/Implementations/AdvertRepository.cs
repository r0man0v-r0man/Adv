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
        public void Dispose(){ }

        public async Task<FlatRent> CreateFlatRentAsync(FlatRent flatRent, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();
            await context.FlatRents.AddAsync(flatRent, ct).ConfigureAwait(false);
            var result = await context.SaveChangesAsync(ct).ConfigureAwait(false);
            return result >= 0 ? flatRent : throw new BadCreateException("Мы не смогли создать объявление");
        }

        public async Task<FlatSale> CreateFlatSaleAsync(FlatSale flatSale, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();
            await context.FlatSales.AddAsync(flatSale, ct).ConfigureAwait(false);
            var result = await context.SaveChangesAsync(ct).ConfigureAwait(false);
            return result >= 0 ? flatSale : throw new BadCreateException("Мы не смогли создать объявление");
        }
    }
}
