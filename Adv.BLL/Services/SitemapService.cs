using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Adv.BLL.Services
{
    public class SitemapService : ISitemapService
    {
        private readonly ISitemapRepository sitemapRepository;
        private readonly IMemoryCache memoryCache;
        private MemoryCacheEntryOptions MemoryCacheEntryOptions { get; }

        public SitemapService(ISitemapRepository sitemapRepository, IMemoryCache memoryCache)
        {
            this.sitemapRepository = sitemapRepository;
            this.memoryCache = memoryCache;
            MemoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
            };
        }

        public async Task<XDocument> GenerateSitemapAsync()
        {
            return await memoryCache.GetOrCreateAsync("sitemap", async cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = MemoryCacheEntryOptions.AbsoluteExpirationRelativeToNow;
                return await sitemapRepository.GenerateSitemapAsync().ConfigureAwait(false);
            }).ConfigureAwait(false);
        }
    }
}
