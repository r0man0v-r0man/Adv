﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Adv.DAL.Context.Extensions;
using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities.Adverts;
using Adv.DAL.Exceptions;
using Microsoft.EntityFrameworkCore;

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

        public async Task<HouseRent> CreateHouseRentAsync(HouseRent houseRent, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();
            await context.HouseRents.AddAsync(houseRent, ct).ConfigureAwait(false);
            var result = await context.SaveChangesAsync(ct).ConfigureAwait(false);
            return result >= 0 ? houseRent : throw new BadCreateException("Мы не смогли создать объявление");
        }

        public async Task<HouseSale> CreateHouseSaleAsync(HouseSale houseSale, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();
            await context.HouseSales.AddAsync(houseSale, ct).ConfigureAwait(false);
            var result = await context.SaveChangesAsync(ct).ConfigureAwait(false);
            return result >= 0 ? houseSale : throw new BadCreateException("Мы не смогли создать объявление");
        }

        public async Task<FlatRent> GetFlatRentAsync(int id, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();
            var result = await context.FlatRents
                .Include(prop => prop.Images)
                .AsNoTracking()
                .FirstOrDefaultAsync(flat => flat.Id == id, ct)
                .ConfigureAwait(false);
            return result ?? throw new NotFoundAdvertException();
        }

        public async Task<FlatSale> GetFlatSaleAsync(int id, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();
            var result = await context.FlatSales
                .Include(prop => prop.Images)
                .AsNoTracking()
                .FirstOrDefaultAsync(flat => flat.Id == id, ct)
                .ConfigureAwait(false);
            return result ?? throw new NotFoundAdvertException();
        }

        public async Task<HouseRent> GetHouseRentAsync(int id, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();
            var result = await context.HouseRents
                .Include(prop => prop.Images)
                .AsNoTracking()
                .FirstOrDefaultAsync(advert => advert.Id == id, ct)
                .ConfigureAwait(false);
            return result ?? throw new NotFoundAdvertException();
        }
        public async Task<HouseSale> GetHouseSaleAsync(int id, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();
            var result = await context.HouseSales
                .Include(prop => prop.Images)
                .AsNoTracking()
                .FirstOrDefaultAsync(advert => advert.Id == id, ct)
                .ConfigureAwait(false);
            return result ?? throw new NotFoundAdvertException();
        }

        public async Task<IEnumerable<FlatRent>> GetFlatRents(int pageNumber)
        {

            using var context = contextFactory.GetAdvContext();
            return await context.FlatRents.Include(prop => prop.Images).AsNoTracking()
                                                          .Where(prop => prop.IsActive == true)
                                                          .OrderByDescending(prop => prop.Created)
                                                          .GetAdvertsByPage(pageNumber)
                                                          .ToListAsync()
                                                          .ConfigureAwait(false);
        }

        public async Task<IEnumerable<FlatSale>> GetFlatSales(int pageNumber)
        {

            using var context = contextFactory.GetAdvContext();
            return await context.FlatSales.Include(prop => prop.Images).AsNoTracking()
                                                          .Where(prop => prop.IsActive == true)
                                                          .OrderByDescending(prop => prop.Created)
                                                          .GetAdvertsByPage(pageNumber)
                                                          .ToListAsync()
                                                          .ConfigureAwait(false);

        }

        public async Task<IEnumerable<HouseRent>> GetHouseRents(int pageNumber)
        {

            using var context = contextFactory.GetAdvContext();
            return await context.HouseRents.Include(prop => prop.Images).AsNoTracking()
                                                          .Where(prop => prop.IsActive == true)
                                                          .OrderByDescending(prop => prop.Created)
                                                          .GetAdvertsByPage(pageNumber)
                                                          .ToListAsync()
                                                          .ConfigureAwait(false);

        }

        public async Task<IEnumerable<HouseSale>> GetHouseSales(int pageNumber)
        {
            using var context = contextFactory.GetAdvContext();
            return await context.HouseSales.Include(prop => prop.Images).AsNoTracking()
                                                          .Where(prop => prop.IsActive == true)
                                                          .OrderByDescending(prop => prop.Created)
                                                          .GetAdvertsByPage(pageNumber)
                                                          .ToListAsync()
                                                          .ConfigureAwait(false);
        }
    }
}
