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
    public class ComponentsController : ControllerBase
    {
        private readonly IYandexAddressService _yandexAddressService;
        public ComponentsController(IYandexAddressService yandexAddressService)
        {
            _yandexAddressService = yandexAddressService;
        }
        [HttpGet("getProvince")]
        public async Task<ActionResult<IEnumerable<ComponentViewModel>>> GetProvince()
        {
            try
            {
                var result = await _yandexAddressService.GetProvinceAsync().ConfigureAwait(false);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
