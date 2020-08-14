using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Adv.BLL.Services
{
    public class SitemapService : ISitemapService
    {
        private readonly IAdvertRepository advertRepository;
        private readonly IMemoryCache memoryCache;
        private MemoryCacheEntryOptions MemoryCacheEntryOptions { get; }

        public SitemapService(IAdvertRepository advertRepository, IMemoryCache memoryCache)
        {
            this.advertRepository = advertRepository;
            this.memoryCache = memoryCache;
            MemoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
            };
        }
        public async Task<XDocument> GetSitemapAsync()
        {
            return await memoryCache.GetOrCreateAsync("sitemap", async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = MemoryCacheEntryOptions.AbsoluteExpirationRelativeToNow;
                XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
                XElement root = new XElement(xmlns + "urlset");
                var ids = await advertRepository.GetAdvertsIds().ConfigureAwait(false);
                root.Add(new XElement(xmlns + "url", new XElement(xmlns + "loc", "https://halupa.by")));
                root.Add(new XElement(xmlns + "url", new XElement(xmlns + "loc", "https://halupa.by/flats")));
                root.Add(new XElement(xmlns + "url", new XElement(xmlns + "loc", "https://halupa.by/houses")));
                foreach (var id in ids.Item1)
                {
                    XElement urlElement = new XElement(
                        xmlns + "url",
                        new XElement(xmlns + "loc", $"https://halupa.by/flat/rent/{id}"));
                    root.Add(urlElement);
                }
                foreach (var id in ids.Item2)
                {
                    XElement urlElement = new XElement(
                        xmlns + "url",
                        new XElement(xmlns + "loc", $"https://halupa.by/flat/sale/{id}"));
                    root.Add(urlElement);
                }
                foreach (var id in ids.Item3)
                {
                    XElement urlElement = new XElement(
                        xmlns + "url",
                        new XElement(xmlns + "loc", $"https://halupa.by/house/rent/{id}"));
                    root.Add(urlElement);
                }
                foreach (var id in ids.Item4)
                {
                    XElement urlElement = new XElement(
                        xmlns + "url",
                        new XElement(xmlns + "loc", $"https://halupa.by/house/sale/{id}"));
                    root.Add(urlElement);
                }
                return new XDocument(root);
            }).ConfigureAwait(false);
        }
    }
}
