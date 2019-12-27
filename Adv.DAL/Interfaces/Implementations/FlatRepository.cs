using Adv.DAL.Context;
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
    public class FlatRepository : IFlatRepository
    {
        private readonly AdvContext _context;
        public FlatRepository(AdvContext context)
        {
            _context = context;
        }

        public async Task<Flat> CreateAsync(Flat flat, CancellationToken ct)
        {
            await _context.Flats.AddAsync(flat, ct).ConfigureAwait(false);
            var result = await _context.SaveChangesAsync(ct).ConfigureAwait(false);
            return result >= 0 ? flat : null;
        }


        public Task<Flat> FindAsync(Expression<Func<Flat, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        private async IAsyncEnumerable<Flat> GetAllAsync([EnumeratorCancellation] CancellationToken ct = default)
        {
            await foreach (var Flat in _context.Flats.AsNoTracking().AsAsyncEnumerable().WithCancellation(ct).ConfigureAwait(false))
            {
                yield return Flat;
            }
        }

        public async IAsyncEnumerable<Flat> GetAllAsync(int pageNumber, byte size, int skip, [EnumeratorCancellation] CancellationToken ct)
        {
            await foreach (var flat in _context.Flats.AsNoTracking()
                                                      .OrderBy(property => property.Created)
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
            return await _context.Flats.FirstOrDefaultAsync(x => x.Id == flatId, ct).ConfigureAwait(false);
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }
    }
}
