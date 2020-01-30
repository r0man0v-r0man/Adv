using Adv.DAL.Context;
using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
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
            return result >= 0 ? flat : null;
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

            await foreach (var flat in context.Flats.AsNoTracking()
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

            return await context.Flats.AsNoTracking().FirstOrDefaultAsync(x => x.Id == flatId, ct).ConfigureAwait(false);
        }

        public Task<bool> RemoveAsync(Flat flat)
        {
            throw new NotImplementedException();
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
