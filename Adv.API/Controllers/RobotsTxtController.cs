using Microsoft.AspNetCore.Mvc;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotsTxtController : ControllerBase
    {
        [Route("/robots.txt")]
        public string RobotsTxt()
        {
            return
                "User-agent: *\r\nDisallow: /login\r\nDisallow: /register\r\nDisallow: /create-advert\r\nSitemap: https://halupa.by/sitemap.xml";
        }
    }
}
