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
    }
}
