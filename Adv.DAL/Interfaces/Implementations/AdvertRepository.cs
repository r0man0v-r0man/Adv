﻿  
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Adv.DAL.Context.Extensions;
using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities;
using Adv.DAL.Entities.Adverts;
using Adv.DAL.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public async Task<int> CreateFlatRentAsync(FlatRent flatRent, CancellationToken ct)
        {
            try
            {
                using var context = contextFactory.GetAdvContext();
                await context.FlatRents.AddAsync(flatRent, ct).ConfigureAwait(false);
                var result = await context.SaveChangesAsync(ct).ConfigureAwait(false);
                return result > 0 ? flatRent.Id : throw new BadCreateException("Мы не смогли создать объявление");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<int> CreateFlatSaleAsync(FlatSale flatSale, CancellationToken ct)
        {
            try
            {
                using var context = contextFactory.GetAdvContext();
                await context.FlatSales.AddAsync(flatSale, ct).ConfigureAwait(false);
                var result = await context.SaveChangesAsync(ct).ConfigureAwait(false);
                return result > 0 ? flatSale.Id : throw new BadCreateException("Мы не смогли создать объявление");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public async Task<int> CreateHouseRentAsync(HouseRent houseRent, CancellationToken ct)
        {
            try
            {
                using var context = contextFactory.GetAdvContext();
                await context.HouseRents.AddAsync(houseRent, ct).ConfigureAwait(false);
                var result = await context.SaveChangesAsync(ct).ConfigureAwait(false);
                return result > 0 ? houseRent.Id : throw new BadCreateException("Мы не смогли создать объявление");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
            
        }

        public async Task<int> CreateHouseSaleAsync(HouseSale houseSale, CancellationToken ct)
        {
            try
            {
                using var context = contextFactory.GetAdvContext();
                await context.HouseSales.AddAsync(houseSale, ct).ConfigureAwait(false);
                var result = await context.SaveChangesAsync(ct).ConfigureAwait(false);
                return result > 0 ? houseSale.Id : throw new BadCreateException("Мы не смогли создать объявление");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public async Task<FlatRent> GetFlatRentAsync(int id, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();
            var result = await context.FlatRents
                .Include(prop => prop.Images)
                .Include(prop => prop.Address.GeoObject.Point)
                .Include(prop => prop.Address.GeoObject.BoundedBy.Envelope)
                .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
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
                .Include(prop => prop.Address.GeoObject.Point)
                .Include(prop => prop.Address.GeoObject.BoundedBy.Envelope)
                .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
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
                .Include(prop => prop.Address.GeoObject.Point)
                .Include(prop => prop.Address.GeoObject.BoundedBy.Envelope)
                .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
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
                .Include(prop => prop.Address.GeoObject.Point)
                .Include(prop => prop.Address.GeoObject.BoundedBy.Envelope)
                .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                .AsNoTracking()
                .FirstOrDefaultAsync(advert => advert.Id == id, ct)
                .ConfigureAwait(false);
            return result ?? throw new NotFoundAdvertException();
        }

        // public async Task<IEnumerable<FlatRent>> GetFlatRents(int pageNumber, City city)
        // {
        //     using var context = contextFactory.GetAdvContext();
        //     return await context.FlatRents
        //         .Include(prop => prop.Address)
        //         .ThenInclude(prop => prop.City)
        //         .Include(prop => prop.Images)
        //         .AsNoTracking()
        //         .Where(prop => prop.IsActive && prop.Address.CityId == city.Id)
        //         .OrderByDescending(prop => prop.Created)
        //         .GetAdvertsByPage(pageNumber)
        //         .ToListAsync()
        //         .ConfigureAwait(false);
        // }
        //
        // public async Task<IEnumerable<FlatSale>> GetFlatSales(int pageNumber, City city)
        // {
        //     using var context = contextFactory.GetAdvContext();
        //     return await context.FlatSales
        //         .Include(prop => prop.Address)
        //         .ThenInclude(prop => prop.City)
        //         .Include(prop => prop.Images)
        //         .AsNoTracking()
        //         .Where(prop => prop.IsActive && prop.Address.CityId == city.Id)
        //         .OrderByDescending(prop => prop.Created)
        //         .GetAdvertsByPage(pageNumber)
        //         .ToListAsync()
        //         .ConfigureAwait(false);
        // }
        //
        // public async Task<IEnumerable<HouseRent>> GetHouseRents(int pageNumber, City city)
        // {
        //     using var context = contextFactory.GetAdvContext();
        //     return await context.HouseRents
        //         .Include(prop => prop.Address)
        //         .ThenInclude(prop => prop.City)
        //         .Include(prop => prop.Images).AsNoTracking()
        //         .Where(prop => prop.IsActive && prop.Address.CityId == city.Id)
        //         .OrderByDescending(prop => prop.Created)
        //         .GetAdvertsByPage(pageNumber)
        //         .ToListAsync()
        //         .ConfigureAwait(false);
        // }
        //
        // public async Task<IEnumerable<HouseSale>> GetHouseSales(int pageNumber, City city)
        // {
        //     using var context = contextFactory.GetAdvContext();
        //     return await context.HouseSales
        //         .Include(prop => prop.Address)
        //         .ThenInclude(prop => prop.City)
        //         .Include(prop => prop.Images).AsNoTracking()
        //         .Where(prop => prop.IsActive && prop.Address.CityId == city.Id)
        //         .OrderByDescending(prop => prop.Created)
        //         .GetAdvertsByPage(pageNumber)
        //         .ToListAsync()
        //         .ConfigureAwait(false);
        // }

        public async Task<IEnumerable<FlatRent>> GetAnyFlatRentsAsync(int pageNumber)
        {
            using var context = contextFactory.GetAdvContext();
            return await context.FlatRents
                .Include(prop => prop.Images)
                .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                .AsNoTracking()
                .Where(prop => prop.IsActive)
                .OrderByDescending(prop => prop.Created)
                .GetAdvertsByPage(pageNumber)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<FlatSale>> GetAnyFlatSalesAsync(int pageNumber)
        {
            using var context = contextFactory.GetAdvContext();
            return await context.FlatSales
                .Include(prop => prop.Images)
                .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                .AsNoTracking()
                .Where(prop => prop.IsActive)
                .OrderByDescending(prop => prop.Created)
                .GetAdvertsByPage(pageNumber)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<HouseRent>> GetAnyHouseRentsAsync(int pageNumber)
        {
            using var context = contextFactory.GetAdvContext();
            return await context.HouseRents
                .Include(prop => prop.Images)
                .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                .AsNoTracking()
                .Where(prop => prop.IsActive )
                .OrderByDescending(prop => prop.Created)
                .GetAdvertsByPage(pageNumber)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<HouseSale>> GetAnyHouseSalesAsync(int pageNumber)
        {
            using var context = contextFactory.GetAdvContext();
            return await context.HouseSales
                .Include(prop => prop.Images)
                .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                .AsNoTracking()
                .Where(prop => prop.IsActive)
                .OrderByDescending(prop => prop.Created)
                .GetAdvertsByPage(pageNumber)
                .ToListAsync()
                .ConfigureAwait(false);
        }

    }
}