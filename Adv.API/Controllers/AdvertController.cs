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
            return Ok();
        }
        [HttpPost("addFlatSale")]
        [Authorize]
        public async Task<ActionResult<FlatRentViewModel>> AddFlatSale(FlatSaleViewModel flatSaleViewModel,
            CancellationToken ct = default)
        {
            return Ok();
        }
    }
}