using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task<IList<IEnumerable<Component>>> GetProvinceAsync()
        {
            using var context = _contextFactory.GetAdvContext();
            var provincies = await context.YandexAddresses.Select(x =>
                    x.GeoObject.MetaDataProperty.GeocoderMetaData.Address.Components.Where(c => c.Kind == "province")
                        .Select(n => n.Name))
                .Distinct()
                .SelectMany((u, c) => u.Distinct()).ToListAsync().ConfigureAwait(false);

            return new List<IEnumerable<Component>>();
        }
       
    }
}
