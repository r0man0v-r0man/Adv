using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adv.BLL.Interfaces
{
    public interface ISitemapService
    {
        Task<XDocument> GetSitemapAsync();
        /// <summary>
        /// Добавление url -> loc в файл sitemap.xml
        /// </summary>
        /// <param name="sitemapPath">ContentRootPath from IWebHostEnvironment</param>
        /// <param name="url">URL страницы</param>
        /// <returns></returns>
        Task AddUrl(string sitemapPath, string url);
    }
}
