using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adv.DAL.Interfaces.Implementations
{
    public class StoreCityRepository : IStoreCityRepository
    {
        private readonly IContextFactory _contextFactory;

        public StoreCityRepository(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void Dispose() { }

        public async Task<IEnumerable<StoreCity>> GetStoreCityAsync()
        {
            try
            {
                using var context = _contextFactory.GetAdvContext();
                return await context.StoreCities
                    .AsNoTracking()
                    .ToListAsync()
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw;
            }
            
        }
    }
}