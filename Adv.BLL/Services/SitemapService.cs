using System;
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
        private readonly IAdvertRepository advertRepository;

        public SitemapService(IAdvertRepository advertRepository)
        {
            this.advertRepository = advertRepository;
        }

        public async Task<XDocument> GetSitemapAsync()
        {
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
        }
    }
}
