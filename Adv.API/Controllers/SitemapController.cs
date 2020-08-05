using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitemapController : ControllerBase
    {
        private readonly ISitemapService sitemapService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public SitemapController(ISitemapService sitemapService, IWebHostEnvironment webHostEnvironment)
        {
            this.sitemapService = sitemapService;
            this.webHostEnvironment = webHostEnvironment;
        }
        [Route("/sitemap.xml")]
        public async Task<IActionResult> Sitemap()
        {
            var env = webHostEnvironment.ContentRootPath;
            var doc = XDocument.Load(Path.Combine(env, @"sitemap.xml"));
            return Content(doc.ToString(), "text/xml");
        }
    }
}
