using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adv.DAL.Interfaces
{
    public interface ISitemapRepository
    {
        Task GetSitemapXmlAsync();
    }
}
