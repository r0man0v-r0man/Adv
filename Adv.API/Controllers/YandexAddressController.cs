using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adv.API.Models.Address;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YandexAddressController : ControllerBase
    {
        private readonly IYandexAddressService _yandexAddressService;
        public YandexAddressController(IYandexAddressService yandexAddressService)
        {
            _yandexAddressService = yandexAddressService;
        }
        [HttpGet("getLocations")]
        public async Task<ActionResult<IEnumerable<ComponentViewModel>>> GetLocations()
        {
            try
            {
                var result = await _yandexAddressService.GetLocationsAsync().ConfigureAwait(false);
                return Ok(result.Select(x => (ComponentViewModel)x));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
