using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities;
using Adv.DAL.Entities.Address;
using Adv.DAL.Entities.Adverts;
using Adv.DAL.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Adv.DAL.Entities.Adverts.Update;

namespace Adv.DAL.Interfaces.Implementations
{
    public class AdvertRepository : IAdvertRepository
    {
        private readonly IContextFactory contextFactory;
        private readonly UserManager<AppUser> userManager;

        const byte SIZE = 20;
        public AdvertRepository(IContextFactory contextFactory, UserManager<AppUser> userManager)
        {
            this.contextFactory = contextFactory;
            this.userManager = userManager;
        }
        public void Dispose() { }

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

        public async Task<IEnumerable<FlatRent>> GetFlatRents(int pageNumber, Component province)
        {
            using var context = contextFactory.GetAdvContext();
            return await context.FlatRents
                .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                .Include(prop => prop.Images)
                .AsNoTracking()
                .Where(prop => prop.IsActive && prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components.Any(c => c.Kind == province.Kind && c.Name == province.Name))
                .OrderByDescending(prop => prop.Created)
                .Skip(SkipCalc(pageNumber))
                .Take(SIZE)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<FlatSale>> GetFlatSales(int pageNumber, Component province)
        {
            using var context = contextFactory.GetAdvContext();
            return await context.FlatSales
                .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                .Include(prop => prop.Images)
                .AsNoTracking()
                .Where(prop => prop.IsActive && prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components.Any(c => c.Kind == province.Kind && c.Name == province.Name))
                .OrderByDescending(prop => prop.Created)
                .Skip(SkipCalc(pageNumber))
                .Take(SIZE)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<HouseRent>> GetHouseRents(int pageNumber, Component province)
        {
            using var context = contextFactory.GetAdvContext();
            return await context.HouseRents
                .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                .Include(prop => prop.Images)
                .AsNoTracking()
                .Where(prop => prop.IsActive && prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components.Any(c => c.Kind == province.Kind && c.Name == province.Name))
                .OrderByDescending(prop => prop.Created)
                .Skip(SkipCalc(pageNumber))
                .Take(SIZE)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<HouseSale>> GetHouseSales(int pageNumber, Component province)
        {
            using var context = contextFactory.GetAdvContext();
            return await context.HouseSales
                .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                .Include(prop => prop.Images)
                .AsNoTracking()
                .Where(prop => prop.IsActive && prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components.Any(c => c.Kind == province.Kind && c.Name == province.Name))
                .OrderByDescending(prop => prop.Created)
                .Skip(SkipCalc(pageNumber))
                .Take(SIZE)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<FlatRent>> GetAnyFlatRentsAsync(int pageNumber)
        {
            using var context = contextFactory.GetAdvContext();
            return await context.FlatRents
                .Include(prop => prop.Images)
                .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                .AsNoTracking()
                .Where(prop => prop.IsActive)
                .OrderByDescending(prop => prop.Created)
                .Skip(SkipCalc(pageNumber))
                .Take(SIZE)
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
                .Skip(SkipCalc(pageNumber))
                .Take(SIZE)
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
                .Where(prop => prop.IsActive)
                .OrderByDescending(prop => prop.Created)
                .Skip(SkipCalc(pageNumber))
                .Take(SIZE)
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
                .Skip(SkipCalc(pageNumber))
                .Take(SIZE)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<FlatRent> GetLastFlatRentAsync()
        {
            try
            {
                using var context = contextFactory.GetAdvContext();
                return await context.FlatRents
                    .Include(prop => prop.Images)
                    .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(prop => prop.Created == context.FlatRents.Max(x => x.Created))
                    .ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int SkipCalc(int pageNumber) => (SIZE * pageNumber) - SIZE;

        public async Task<FlatSale> GetLastFlatSaleAsync()
        {
            try
            {
                using var context = contextFactory.GetAdvContext();
                return await context.FlatSales
                    .Include(prop => prop.Images)
                    .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(prop => prop.Created == context.FlatSales.Max(x => x.Created))
                    .ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HouseRent> GetLastHouseRentAsync()
        {
            try
            {
                using var context = contextFactory.GetAdvContext();
                return await context.HouseRents
                    .Include(prop => prop.Images)
                    .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(prop => prop.Created == context.HouseRents.Max(x => x.Created))
                    .ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HouseSale> GetLastHouseSaleAsync()
        {
            try
            {
                using var context = contextFactory.GetAdvContext();
                return await context.HouseSales
                    .Include(prop => prop.Images)
                    .Include(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(prop => prop.Created == context.HouseSales.Max(x => x.Created))
                    .ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Dictionary<string, Dictionary<int, string>>> GetUserAdvertsAsync(string userId, CancellationToken ct = default)
        {
            try
            {
                var user = await userManager.Users
                    .Include(prop => prop.FlatSales)
                        .ThenInclude(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                    .Include(prop => prop.FlatRents)
                        .ThenInclude(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                    .Include(prop => prop.HouseSales)
                        .ThenInclude(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                    .Include(prop => prop.HouseRents)
                        .ThenInclude(prop => prop.Address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(prop => prop.Id == userId, ct)
                    .ConfigureAwait(false);
                return new Dictionary<string, Dictionary<int, string>>
                {
                    {"flatRent", user.FlatRents.Where(prop => prop.IsActive).ToDictionary(x => x.Id, x =>x.Address.GeoObject.Name)},
                    {"flatSale", user.FlatSales.Where(prop => prop.IsActive).ToDictionary(x => x.Id, x =>x.Address.GeoObject.Name)},
                    {"houseRent", user.HouseRents.Where(prop => prop.IsActive).ToDictionary(x => x.Id, x =>x.Address.GeoObject.Name)},
                    {"houseSale", user.HouseSales.Where(prop => prop.IsActive).ToDictionary(x => x.Id, x =>x.Address.GeoObject.Name)},
                };
                
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<(IEnumerable<int>, IEnumerable<int>, IEnumerable<int>, IEnumerable<int>)> GetAdvertsIds()
        {
            using var context = contextFactory.GetAdvContext();
            var flatRents = await context.FlatRents
                .AsNoTracking()
                .Where(prop => prop.IsActive)
                .Select(prop => prop.Id)
                .ToListAsync()
                .ConfigureAwait(false);
            var flatSales = await context.FlatSales
                .AsNoTracking()
                .Where(prop => prop.IsActive)
                .Select(prop => prop.Id)
                .ToListAsync()
                .ConfigureAwait(false);
            var houseRents = await context.HouseRents
                .AsNoTracking()
                .Where(prop => prop.IsActive)
                .Select(prop => prop.Id)
                .ToListAsync()
                .ConfigureAwait(false);
            var houseSales = await context.HouseSales
                .AsNoTracking()
                .Where(prop => prop.IsActive)
                .Select(prop => prop.Id)
                .ToListAsync()
                .ConfigureAwait(false);
            return (flatRents, flatSales, houseRents, houseSales);
        }

        public async Task<bool> DeleteFlatRentAsync(int id)
        {
            try
            {
                using var context = contextFactory.GetAdvContext();
                var advert = await context.FlatRents
                    .FirstOrDefaultAsync(prop => prop.Id == id)
                    .ConfigureAwait(false);
                if (advert != null)
                {
                    advert.IsActive = false;
                    var result = await context.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
                    return result > 0;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeleteFlatSaleAsync(int id)
        {
            try
            {
                using var context = contextFactory.GetAdvContext();
                var advert = await context.FlatSales
                    .FirstOrDefaultAsync(prop => prop.Id == id)
                    .ConfigureAwait(false);
                if (advert != null)
                {
                    advert.IsActive = false;
                    var result = await context.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
                    return result > 0;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeleteHouseRentAsync(int id)
        {
            try
            {
                using var context = contextFactory.GetAdvContext();
                var advert = await context.HouseRents
                    .FirstOrDefaultAsync(prop => prop.Id == id)
                    .ConfigureAwait(false);
                if (advert != null)
                {
                    advert.IsActive = false;
                    var result = await context.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
                    return result > 0;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeleteHouseSaleAsync(int id)
        {
            try
            {
                using var context = contextFactory.GetAdvContext();
                var advert = await context.HouseSales
                    .FirstOrDefaultAsync(prop =>prop.Id == id, CancellationToken.None)
                    .ConfigureAwait(false);
                if (advert != null)
                {
                    advert.IsActive = false;
                    var result = await context.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
                    return result > 0;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateFlatRentAsync(UpdateAdvert updateModel, int advertId)
        {
            if (updateModel == null)
            {
                return false;
            }
            try
            {
                using var context = contextFactory.GetAdvContext();
                var advert = await context.FlatRents
                    .FirstOrDefaultAsync(item => item.Id == advertId)
                    .ConfigureAwait(false);
                if (advert != null)
                {
                    advert.Price = updateModel.Price;
                    advert.Description = updateModel.Description;
                    advert.Phone = updateModel.Phone;
                    var result = await context.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
                    return result > 0;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}