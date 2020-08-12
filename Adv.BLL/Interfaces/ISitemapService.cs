using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adv.BLL.Interfaces
{
    public interface ISitemapService
    {
        Task<XDocument> GetSitemapAsync();
    }
}
