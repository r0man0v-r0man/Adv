using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adv.API.Models;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService cityService;

        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
        }

        [HttpGet("getCities")]
        public async Task<ActionResult<IEnumerable<CityViewModel>>> GetCities()
        {
            var result = await cityService.GetCitiesAsync().ConfigureAwait(false);
            return Ok(result.Select(c=> (CityViewModel)c));
        }
    }
}
