using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Adv.DAL.Entities.Adverts;

namespace Adv.DAL.Interfaces
{
    public interface IAdvertRepository : IBaseRepository
    {
        Task<FlatRent> CreateFlatRentAsync(FlatRent flatRent, CancellationToken ct);
    }
}
