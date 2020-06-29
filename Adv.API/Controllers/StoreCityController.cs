using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adv.API.Models;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreCityController : ControllerBase
    {
        private readonly IStoreCityService _storeCityService;

        public StoreCityController(IStoreCityService storeCityService)
        {
            _storeCityService = storeCityService ?? throw new ArgumentNullException(nameof(storeCityService));
        }
        
        [HttpGet("getStoreCity")]
        public async Task<ActionResult<IEnumerable<StoreCityViewModel>>> GetStoreCity()
        {
            try
            {
                var result = await _storeCityService
                    .GetStoreCityAsync()
                    .ConfigureAwait(false);
                return Ok(result.Select(city=> (StoreCityViewModel)city));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
           
        }
    }
}