using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Adv.API.Models.Adverts;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService _advertService;
        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }
        [HttpPost("addFlatRent")]
        [Authorize]
        public async Task<ActionResult<FlatRentViewModel>> AddFlatRent(FlatRentViewModel flatRentViewModel,
            CancellationToken ct = default)
        {
            try
            {
                FlatRentViewModel result = await _advertService.CreateFlatRentAsync(flatRentViewModel, ct).ConfigureAwait(false);
                return CreatedAtAction(nameof(AddFlatRent),result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpPost("addFlatSale")]
        [Authorize]
        public async Task<ActionResult<FlatSaleViewModel>> AddFlatSale(FlatSaleViewModel flatSaleViewModel,
            CancellationToken ct = default)
        {
            return Ok();
        }
        [HttpPost("addHouseSale")]
        [Authorize]
        public async Task<ActionResult<HouseSaleViewModel>> AddHouseSale(HouseSaleViewModel houseSaleViewModel,
            CancellationToken ct = default)
        {
            return Ok();
        }
        [HttpPost("addHouseRent")]
        [Authorize]
        public async Task<ActionResult<HouseRentViewModel>> AddHouseRent(HouseRentViewModel houseRentViewModel,
            CancellationToken ct = default)
        {
            return Ok();
        }
    }
}