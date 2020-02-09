using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities;
using Adv.DAL.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Adv.DAL.Interfaces.Implementations
{
    public sealed class FlatRepository : IFlatRepository
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

        private async IAsyncEnumerable<Flat> GetAllAsync([EnumeratorCancellation] CancellationToken ct = default)
        {
            using var context = contextFactory.GetAdvContext();
            await foreach (var Flat in context.Flats.AsNoTracking().AsAsyncEnumerable().WithCancellation(ct).ConfigureAwait(false))
            {
                yield return Flat;
            }
        }

        public async IAsyncEnumerable<Flat> GetAllAsync(int pageNumber, byte size, int skip, [EnumeratorCancellation] CancellationToken ct)
        {
            using var context = contextFactory.GetAdvContext();

            await foreach (var flat in context.Flats.Include(x=>x.AppUser).AsNoTracking()
                                                      .Where(prop => prop.IsActive == true)
                                                      .OrderByDescending(property => property.Created)
                                                      .Skip(skip)
                                                      .Take(size)
                                                      .AsAsyncEnumerable()
                                                      .WithCancellation(ct)
                                                      .ConfigureAwait(false))
            {
                yield return flat;
            }
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

        public Task<bool> UpdateAsync(Flat flat)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
