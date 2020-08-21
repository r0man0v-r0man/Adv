using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities.Address;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                return context.YandexAddresses
                     .SelectMany(address => address.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components
                         .Where(component => component.Kind != "house" && component.Kind != "country" && component.Kind != "street"))
                     .AsNoTracking()
                     .AsEnumerable()
                     .GroupBy(groupBy => groupBy.Name)
                     .Select(item => item.First())
                     .ToList();

            }
            catch (System.Exception)
            {
                throw;
            }

        }

    }
}
