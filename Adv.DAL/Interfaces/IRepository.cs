using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adv.DAL.Interfaces
{
    public interface IRepository<T>: IDisposable where T: class 
    {
        Task<T> CreateAsync(T item, CancellationToken ct = default);
        Task<T> GetByIdAsync(int Id);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        IAsyncEnumerable<T> GetAllAsync(CancellationToken ct = default);
        IAsyncEnumerable<T> GetAllAsync(int pageNumber, byte size, int skip, CancellationToken ct = default);
        Task RemoveAsync(T item);
        Task<bool> UpdateAsync(T item);
    }
}
