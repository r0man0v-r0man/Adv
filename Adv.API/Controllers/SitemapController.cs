using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitemapController : ControllerBase
    {
        private readonly ISitemapService sitemapService;
        private readonly string ContentRootPath;
        public SitemapController(ISitemapService sitemapService, IWebHostEnvironment webHostEnvironment)
        {
            this.sitemapService = sitemapService;
            ContentRootPath = webHostEnvironment?.ContentRootPath;
        }
        [Route("/sitemap.xml")]
        public async Task<IActionResult> Sitemap()
        {
            var doc = await sitemapService.GetSitemapAsync()
                .ConfigureAwait(false);

            return Content(doc.ToString());
        }
    }
}
