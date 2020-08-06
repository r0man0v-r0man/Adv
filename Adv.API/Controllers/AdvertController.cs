using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Adv.API.Models;
using Adv.API.Models.Adverts;
using Adv.API.Models.Profile;
using Adv.BLL.Interfaces;
using Adv.DAL.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService _advertService;
        private readonly string contentRootPath;
        private readonly ISitemapService _sitemapService;

        public AdvertController(IAdvertService advertService, IWebHostEnvironment webHostEnvironment, ISitemapService sitemapService)
        {
            _advertService = advertService;
            _sitemapService = sitemapService;
            contentRootPath = webHostEnvironment?.ContentRootPath;
        }

        #region Методы создания

        [HttpPost("addFlatRent")]
        [Authorize]
        public async Task<ActionResult<int>> AddFlatRent(FlatRentViewModel flatRentViewModel,
            CancellationToken ct = default)
        {
            try
            {
                var result = await _advertService.CreateFlatRentAsync(flatRentViewModel, ct).ConfigureAwait(false);
                await _sitemapService.AddUrl(contentRootPath, "flat/rent/" + result).ConfigureAwait(false);
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
        public async Task<ActionResult<int>> AddFlatSale(FlatSaleViewModel flatSaleViewModel,
            CancellationToken ct = default)
        {
            try
            {
                var result = await _advertService.CreateFlatSaleAsync(flatSaleViewModel, ct).ConfigureAwait(false);
                await _sitemapService.AddUrl(contentRootPath, "flat/sale/" + result).ConfigureAwait(false);

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
        public async Task<ActionResult<int>> AddHouseSale(HouseSaleViewModel houseSaleViewModel,
            CancellationToken ct = default)
        {
            try
            {
                var result = await _advertService.CreateHouseSaleAsync(houseSaleViewModel, ct).ConfigureAwait(false);
                await _sitemapService.AddUrl(contentRootPath, "house/rent/" + result).ConfigureAwait(false);

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
        public async Task<ActionResult<int>> AddHouseRent(HouseRentViewModel houseRentViewModel,
            CancellationToken ct = default)
        {
            try
            {
                var result = await _advertService.CreateHouseRentAsync(houseRentViewModel, ct).ConfigureAwait(false);
                await _sitemapService.AddUrl(contentRootPath, "house/rent/" + result).ConfigureAwait(false);

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
        [HttpPost("getFlatRents")]
        public async Task<ActionResult<IEnumerable<FlatRentViewModel>>> GetFlatRents(FilterOptions filterOptions, int pageNumber)
        {
            try
            {
                var result = await _advertService
                    .GetFlatRentsAsync(pageNumber, filterOptions?.Province)
                    .ConfigureAwait(false);
                return Ok(result.Select(advert => (FlatRentViewModel)advert));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpPost("getFlatSales")]
        public async Task<ActionResult<IEnumerable<FlatSaleViewModel>>> GetFlatSales(FilterOptions filterOptions, int pageNumber)
        {
            try
            {
                var result = await _advertService
                    .GetFlatSalesAsync(pageNumber, filterOptions?.Province)
                    .ConfigureAwait(false);
                return Ok(result.Select(advert => (FlatSaleViewModel)advert));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpPost("getHouseRents")]
        public async Task<ActionResult<IEnumerable<HouseRentViewModel>>> GetHouseRents(FilterOptions filterOptions, int pageNumber)
        {
            try
            {
                var result = await _advertService
                    .GetHouseRentsAsync(pageNumber, filterOptions?.Province)
                    .ConfigureAwait(false);
                return Ok(result.Select(advert => (HouseRentViewModel)advert));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpPost("getHouseSales")]
        public async Task<ActionResult<IEnumerable<HouseSaleViewModel>>> GetHouseSales(FilterOptions filterOptions, int pageNumber)
        {
            try
            {
                var result = await _advertService
                    .GetHouseSalesAsync(pageNumber, filterOptions?.Province)
                    .ConfigureAwait(false);
                return Ok(result.Select(advert => (HouseSaleViewModel)advert));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpGet("getAnyFlatRents")]
        public async Task<ActionResult<IEnumerable<FlatRentViewModel>>> GetAnyFlatRents(int pageNumber)
        {
            try
            {
                var result = await _advertService.GetAnyFlatRentsAsync(pageNumber).ConfigureAwait(false);
                return Ok(result.Select(advert => (FlatRentViewModel)advert));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpGet("getAnyFlatSales")]
        public async Task<ActionResult<IEnumerable<FlatSaleViewModel>>> GetAnyFlatSales(int pageNumber)
        {
            try
            {
                var result = await _advertService.GetAnyFlatSalesAsync(pageNumber).ConfigureAwait(false);
                return Ok(result.Select(advert => (FlatSaleViewModel)advert));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpGet("getAnyHouseSales")]
        public async Task<ActionResult<HouseSaleViewModel>> GetAnyHouseSales(int pageNumber)
        {
            try
            {
                var result = await _advertService.GetAnyHouseSalesAsync(pageNumber).ConfigureAwait(false);
                return Ok(result.Select(advert => (HouseSaleViewModel)advert));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        [HttpGet("getAnyHouseRents")]
        public async Task<ActionResult<HouseRentViewModel>> GetAnyHouseRents(int pageNumber)
        {
            try
            {
                var result = await _advertService.GetAnyHouseRentsAsync(pageNumber).ConfigureAwait(false);
                return Ok(result.Select(advert => (HouseRentViewModel)advert));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getLastFlatRent")]
        public async Task<IActionResult> GetLastFlatRent()
        {
            try
            {
                FlatRentViewModel result = await _advertService.GetLastFlatRentAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("getLastFlatSale")]
        public async Task<IActionResult> GetLastFlatSale()
        {
            try
            {
                FlatSaleViewModel result = await _advertService.GetLastFlatSaleAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("getLastHouseRent")]
        public async Task<IActionResult> GetLastHouseRent()
        {
            try
            {
                HouseRentViewModel result = await _advertService.GetLastHouseRentAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("getLastHouseSale")]
        public async Task<IActionResult> GetLastHouseSale()
        {
            try
            {
                HouseSaleViewModel result = await _advertService.GetLastHouseSaleAsync().ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("getUserAdverts")]
        public async Task<ActionResult<Dictionary<string, Dictionary<int, string>>>> GetUserAdverts(UserAdvertsViewModel userAdvertsViewModel)
        {
            try
            {
                var result = await _advertService
                    .GetUserAdvertsAsync(userAdvertsViewModel?.UserId, new CancellationTokenSource(5000).Token)
                    .ConfigureAwait(false);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        #endregion

    }
}