using Adv.DAL.Context.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adv.DAL.Interfaces.Implementations
{
    public class SitemapRepository : ISitemapRepository
    {
        private readonly IContextFactory contextFactory;

        public SitemapRepository(IContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<XDocument> GenerateSitemapAsync()
        {
            var context = contextFactory.GetAdvContext();
            var flatRentsIds = await context.FlatRents.AsNoTracking().Select(prop => prop.Id).ToListAsync().ConfigureAwait(false);
            var flatSalesIds = await context.FlatSales.AsNoTracking().Select(prop => prop.Id).ToListAsync().ConfigureAwait(false);
            var houseRentsIds = await context.HouseRents.AsNoTracking().Select(prop => prop.Id).ToListAsync().ConfigureAwait(false);
            var houseSalesIds = await context.HouseSales.AsNoTracking().Select(prop => prop.Id).ToListAsync().ConfigureAwait(false);
            var locList = new List<XElement>
            {
                new XElement("url", new XElement("loc", $"https://halupa.by/")),
                new XElement("url", new XElement("loc", $"https://halupa.by/flats")),
                new XElement("url", new XElement("loc", $"https://halupa.by/houses"))
            };
            locList.AddRange(flatRentsIds.Select(id => new XElement("url", new XElement("loc", $"https://halupa.by/flat/rent/{id}"))));
            locList.AddRange(flatSalesIds.Select(id => new XElement("url", new XElement("loc", $"https://halupa.by/flat/sale/{id}"))));
            locList.AddRange(houseRentsIds.Select(id => new XElement("url", new XElement("loc", $"https://halupa.by/house/rent/{id}"))));
            locList.AddRange(houseSalesIds.Select(id => new XElement("url", new XElement("loc", $"https://halupa.by/house/sale/{id}"))));

            return await Task.Run(() => new XDocument(new XElement("urlset", locList))).ConfigureAwait(false);
        }
    }
}
