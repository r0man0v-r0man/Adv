using Adv.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adv.DAL.Interfaces
{
    public interface IFlatRepository : IDisposable
    {
        Task<Flat> CreateAsync(Flat flat, CancellationToken ct);
        Task<Flat> GetByIdAsync(int flatId, CancellationToken ct);
        Task<Flat> FindAsync(Expression<Func<Flat, bool>> predicate);
        IAsyncEnumerable<Flat> GetAllAsync(int pageNumber, byte size, int skip, CancellationToken ct);
        Task<bool> RemoveAsync(Flat flat, CancellationToken ct);
        Task<bool> UpdateAsync(Flat flat);
    }
}
