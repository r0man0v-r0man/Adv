using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities.Address;
using Microsoft.EntityFrameworkCore;

namespace Adv.DAL.Interfaces.Implementations
{
    public class YandexAddressRepository : IYandexAddressRepository
    {
        private readonly IContextFactory _contextFactory;

        public YandexAddressRepository(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<IList<Component>> GetLocationsAsync()
        {
            try
            {
                using var context = _contextFactory.GetAdvContext();
                return await context.YandexAddresses
                    .SelectMany(x => x.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components
                        .Where(c => c.Kind != "house" && c.Kind != "country" && c.Kind != "street"))
                    .Distinct()
                    .ToListAsync()
                    .ConfigureAwait(false);
            }
            catch (System.Exception)
            {
                throw;
            }

        }
       
    }
}
