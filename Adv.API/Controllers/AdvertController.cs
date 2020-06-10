using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Adv.API.Models.Adverts;
using Adv.BLL.Interfaces;
using Adv.DAL.Exceptions;
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

        #region Методы создания

        [HttpPost("addFlatRent")]
        [Authorize]
        public async Task<ActionResult<FlatRentViewModel>> AddFlatRent(FlatRentViewModel flatRentViewModel,
            CancellationToken ct = default)
        {
            try
            {
                FlatRentViewModel result = await _advertService.CreateFlatRentAsync(flatRentViewModel, ct).ConfigureAwait(false);
                return CreatedAtAction(nameof(AddFlatRent), result);
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
            try
            {
                FlatSaleViewModel result = await _advertService.CreateFlatSaleAsync(flatSaleViewModel, ct).ConfigureAwait(false);
                return CreatedAtAction(nameof(AddFlatSale), result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpPost("addHouseSale")]
        [Authorize]
        public async Task<ActionResult<HouseSaleViewModel>> AddHouseSale(HouseSaleViewModel houseSaleViewModel,
            CancellationToken ct = default)
        {
            try
            {
                HouseSaleViewModel result = await _advertService.CreateHouseSaleAsync(houseSaleViewModel, ct).ConfigureAwait(false);
                return CreatedAtAction(nameof(AddHouseSale), result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpPost("addHouseRent")]
        [Authorize]
        public async Task<ActionResult<HouseRentViewModel>> AddHouseRent(HouseRentViewModel houseRentViewModel,
            CancellationToken ct = default)
        {
            try
            {
                HouseRentViewModel result = await _advertService.CreateHouseRentAsync(houseRentViewModel, ct).ConfigureAwait(false);
                return CreatedAtAction(nameof(AddHouseRent), result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        #endregion

        #region Методы получения
        [HttpGet("getFlatRent")]
        public async Task<ActionResult<FlatRentViewModel>> GetFlatRent(int id, CancellationToken ct = default)
        {
            try
            {
                FlatRentViewModel result = await _advertService.GetFlatRentAsync(id, ct).ConfigureAwait(false);
                return result != null ? (ActionResult<FlatRentViewModel>) Ok(result) : NotFound();
            }
            catch (NotFoundAdvertException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpGet("getFlatSale")]
        public async Task<ActionResult<FlatSaleViewModel>> GetFlatSale(int id, CancellationToken ct = default)
        {
            try
            {
                FlatSaleViewModel result = await _advertService.GetFlatSaleAsync(id, ct).ConfigureAwait(false);
                return result != null ? (ActionResult<FlatSaleViewModel>) Ok(result) : NotFound();
            }
            catch (NotFoundAdvertException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpGet("getHouseRent")]
        public async Task<ActionResult<HouseRentViewModel>> GetHouseRent(int id, CancellationToken ct = default)
        {
            try
            {
                HouseRentViewModel result = await _advertService.GetHouseRentAsync(id, ct).ConfigureAwait(false);
                return result != null ? (ActionResult<HouseRentViewModel>)Ok(result) : NotFound();
            }
            catch (NotFoundAdvertException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpGet("getHouseSale")]
        public async Task<ActionResult<HouseSaleViewModel>> GetHouseSale(int id, CancellationToken ct = default)
        {
            try
            {
                HouseSaleViewModel result = await _advertService.GetHouseSaleAsync(id, ct).ConfigureAwait(false);
                return result != null ? (ActionResult<HouseSaleViewModel>)Ok(result) : NotFound();
            }
            catch (NotFoundAdvertException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpGet("getFlatRents/{pageNumber}")]
        public async IAsyncEnumerable<FlatRentViewModel> GetFlatRents(int pageNumber)
        {
            const byte SIZE = 20;
            var skip = (SIZE * pageNumber) - SIZE;
            var result = _advertService.GetFlatRentsAsync(pageNumber, SIZE, skip).ConfigureAwait(false);
            await foreach (var advert in result)
            {
                yield return advert;
            }
        }
        #endregion

    }
}