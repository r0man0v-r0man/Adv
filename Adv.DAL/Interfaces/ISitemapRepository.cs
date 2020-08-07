using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adv.DAL.Interfaces
{
    public interface ISitemapRepository
    {
        Task<XDocument> GetSitemapXmlAsync();
    }
}
