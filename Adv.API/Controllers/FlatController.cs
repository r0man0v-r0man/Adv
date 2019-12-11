using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatController : ControllerBase
    {
        private readonly ISuperManager _superManager;
        public FlatController(ISuperManager superManager)
        {
            _superManager = superManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct = default)
        {
            try
            {
                return Ok(await _superManager.Flats.GetAllAsync(ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}