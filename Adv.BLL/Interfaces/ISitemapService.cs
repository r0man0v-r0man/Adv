using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adv.BLL.Interfaces
{
    public interface ISitemapService
    {
        Task<XDocument> GetSitemapAsync(string path);
        Task AddUrl(string sitemapPath, string url);
    }
}
