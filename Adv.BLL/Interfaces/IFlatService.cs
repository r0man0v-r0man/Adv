using Adv.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adv.BLL.Interfaces
{
    public interface IFlatService
    {
        Task<FlatDTO> GetAsync(int id, CancellationToken ct = default);
        IAsyncEnumerable<FlatDTO> GetAsync(CancellationToken ct = default);
    }
}
