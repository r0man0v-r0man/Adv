using Microsoft.AspNetCore.Mvc;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayeerController : ControllerBase
    {
        [Route("/payeer_1136892187.txt")]
        public string PayeerSubmit()
        {
            return "1136892187";
        }
    }
}
