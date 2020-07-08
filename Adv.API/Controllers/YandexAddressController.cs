using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet("getProvince")]
        public async Task<ActionResult<IEnumerable<string>>> GetProvince()
        {
            try
            {
                var result = await _yandexAddressService.GetProvinceAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
