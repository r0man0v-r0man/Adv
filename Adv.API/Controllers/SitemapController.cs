using System.Threading.Tasks;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitemapController : ControllerBase
    {
        private readonly ISitemapService sitemapService;

        public SitemapController(ISitemapService sitemapService)
        {
            this.sitemapService = sitemapService;
        }
        [Route("/sitemap.xml")]
        public async Task<IActionResult> Sitemap()
        {
            var doc = await sitemapService.GenerateSitemapAsync()
                .ConfigureAwait(false);
            
            return Content(doc.ToString(), "text/xml");
        }
    }
}
