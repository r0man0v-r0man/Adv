using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adv.DAL.Interfaces.Implementations
{
    public class CityRepository : ICityRepository
    {
        private readonly IContextFactory contextFactory;
        // кэшируем в потокобезопасном словаре для повышения    
        // производительности    
        private static ConcurrentDictionary<int, City> citiesCache;

        public CityRepository(IContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }
        public void Dispose()
        {
            
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            if (citiesCache == null)
            {
                using var advContext = contextFactory.GetAdvContext();
                citiesCache = new ConcurrentDictionary<int, City>(advContext.Cities.ToDictionary(c => c.Id));
            }
            return await Task.Run<IEnumerable<City>>(() => citiesCache.Values).ConfigureAwait(false);
        }
    }
}
