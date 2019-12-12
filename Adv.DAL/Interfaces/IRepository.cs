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
        Task<T> CreateAsync(T item);
        Task<T> GetByIdAsync(int Id, CancellationToken ct = default);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        IAsyncEnumerable<T> GetAllAsync(CancellationToken ct = default);
        Task RemoveAsync(T item);
        Task<bool> UpdateAsync(T item);
    }
}
