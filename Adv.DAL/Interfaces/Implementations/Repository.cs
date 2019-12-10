using Adv.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Adv.DAL.Interfaces.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AdvContext _context;
        private readonly DbSet<T> dbSet;
        public Repository(AdvContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public async Task<T> CreateAsync(T item)
        {
            await dbSet.AddAsync(item);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return item;
        }

        public Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async IAsyncEnumerable<T> GetAllAsync()
        {
            await foreach (var T in dbSet.AsAsyncEnumerable().ConfigureAwait(false))
            {
                yield return T;
            }

        }

        public async Task<T> GetByIdAsync(int Id) => await dbSet.FindAsync(Id);

        public async Task RemoveAsync(T item)
        {
            dbSet.Remove(item);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return (await _context.SaveChangesAsync().ConfigureAwait(false)) > 0;
        }
    }
}
