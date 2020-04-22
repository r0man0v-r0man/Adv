using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities;
using Adv.DAL.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Adv.DAL.Entities.Enums;

namespace Adv.DAL.Interfaces.Implementations
{
    public class FlatRepository : IFlatRepository
    {
        private readonly IContextFactory contextFactory;

        public FlatRepository(IContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public async Task<Flat> CreateAsync(Flat flat, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();
            await context.Flats.AddAsync(flat, ct).ConfigureAwait(false);
            var result = await context.SaveChangesAsync(ct).ConfigureAwait(false);
            return result >= 0 ? flat : throw new FlatBadCreateException($"Мы не смогли создать объявление");
        }


        public Task<Flat> FindAsync(Expression<Func<Flat, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<Flat>> GetAllAsync(int pageNumber, byte size, int skip, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();

            var flats = await context.Flats.Include(x => x.AppUser).AsNoTracking()
                                                      .Where(prop => prop.IsActive == true)
                                                      .OrderByDescending(property => property.Created)
                                                      .Skip(skip)
                                                      .Take(size).ToListAsync().ConfigureAwait(false);
            return flats;
        }

        public async Task<Flat> GetByIdAsync(int flatId, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();
            var result = await context.Flats.Include(x => x.AppUser).AsNoTracking().FirstOrDefaultAsync(x => x.Id == flatId, ct).ConfigureAwait(false);
            return result ?? throw new FlatNotFoundException($"Мы не нашли объявления с номером {flatId}");
        }

        public async Task<bool> RemoveAsync(Flat flat, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();
            var result = context.Flats.Remove(flat);
            switch (result.State)
            {
                case EntityState.Deleted:
                    await context.SaveChangesAsync(ct).ConfigureAwait(false);
                    return true;
                default:
                    return false;
            }
        }

        public async Task<bool> UpdateAsync(FlatUpdate updatedProperties, int id, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();
            var flat = await context.Flats.FindAsync(id).ConfigureAwait(false);
            if (flat != null)
            {
                flat.Description = updatedProperties?.Description;
                flat.Price = updatedProperties.Price;
                flat.Phone = updatedProperties.Phone;

                var isUpdated = context.Flats.Update(flat);
                switch (isUpdated.State)
                {
                    case EntityState.Modified:
                        await context.SaveChangesAsync(ct).ConfigureAwait(false);
                        return true;
                    default:
                        return false;
                }
            }
            throw new FlatNotFoundException($"Мы не нашли объявления с номером {id}");
        }
        public async Task<IEnumerable<Flat>> FindByCriteriaAsync(byte city, byte rooms, decimal priceMin, decimal priceMax, byte rentType, int pageNumber, byte size, int skip)
        {
            using var context = contextFactory.GetAdvContext();
            if (rooms >= 4)
            {
                return await context.Flats
                .AsNoTracking()
                .Where(flat =>
                    flat.Price >= priceMin && flat.Price <= priceMax &&
                    flat.City == (Cities.CityName)city &&
                    flat.Rooms >= rooms &&
                    flat.Duration == (Duration.RentTime)rentType &&
                    flat.IsActive == true)
                .OrderByDescending(flat => flat.Created)
                .Skip(skip)
                .Take(size)
                .ToListAsync().ConfigureAwait(false);
            }
            else
            {
                return await context.Flats
                .AsNoTracking()
                .Where(flat =>
                    flat.Price >= priceMin && flat.Price <= priceMax &&
                    flat.City == (Cities.CityName)city &&
                    flat.Rooms == rooms &&
                    flat.Duration == (Duration.RentTime)rentType &&
                    flat.IsActive == true)
                .OrderByDescending(flat => flat.Created)
                .Skip(skip)
                .Take(size)
                .ToListAsync().ConfigureAwait(false);
            }
            
        }


        public void Dispose()
        {
     
        }


        public async Task<IEnumerable<Flat>> GetUserFlatsAsync(string userId, int pageCount, byte size, int skip, CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();

            var flats = await context.Flats.Include(x => x.AppUser).AsNoTracking()
                                                      .Where(prop => prop.IsActive == true && prop.AppUserId == userId)
                                                      .OrderByDescending(property => property.Created)
                                                      .Skip(skip)
                                                      .Take(size).ToListAsync().ConfigureAwait(false);
            return flats;
        }
    }
}
