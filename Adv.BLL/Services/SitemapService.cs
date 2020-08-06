using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Adv.BLL.Interfaces;

namespace Adv.BLL.Services
{
    public class SitemapService : ISitemapService
    {
        private const string BASE_URL = "https://halupa.by/";
        private const string SitemapPath = @"clientapp/src/assets/sitemap.xml";

        public async Task<XDocument> GetSitemapAsync(string path)
        {
            return await Task.Run(() => XDocument.Load(Path.Combine(path, SitemapPath))).ConfigureAwait(false);
        }

        public async Task AddUrl(string sitemapPath, string url)
        {
            var path = Path.Combine(sitemapPath, SitemapPath);
            var sitemap = await GetSitemapAsync(path).ConfigureAwait(false);
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
