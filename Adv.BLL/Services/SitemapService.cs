using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Adv.BLL.Interfaces;
using Adv.DAL.Interfaces;

namespace Adv.BLL.Services
{
    public class SitemapService : ISitemapService
    {
        private const string BASE_URL = "https://halupa.by/";
        private const string SitemapPath = @"clientapp/src/assets/sitemap.xml";
        private readonly ISitemapRepository sitemapRepository;
        public SitemapService(ISitemapRepository sitemapRepository)
        {
            this.sitemapRepository = sitemapRepository;
        }
        public async Task<XDocument> GetSitemapAsync()
        {
            return await sitemapRepository.GetSitemapXmlAsync().ConfigureAwait(false);
        }

        public async Task AddUrl(string sitemapPath, string url)
        {
            var path = Path.Combine(sitemapPath, SitemapPath);
            var sitemap = await GetSitemapAsync().ConfigureAwait(false);
            var root = sitemap.Root;
            var urlElement = new XElement("url");
            var locElement = new XElement("loc", BASE_URL + url);
            urlElement.Add(locElement);
            root?.Add(urlElement);
            await using var stream = new FileStream(path, FileMode.Open);
            await sitemap.SaveAsync(stream, SaveOptions.None, CancellationToken.None)
                .ConfigureAwait(false);
            
        }
    }
}
