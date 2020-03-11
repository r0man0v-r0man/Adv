using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adv.API.Models.Criteria;
using Adv.API.Models.Flat;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IFlatService flatService;

        public SearchController(IFlatService flatService)
        {
            this.flatService = flatService;
        }

        [HttpPost]
        public async Task<ActionResult<List<FlatViewModel>>> SearchFlats(SearchFlatCriteria criteria)
        {
            var a = HttpContext;
            const byte SIZE = 20;
            var skip = (SIZE * criteria.PageNumber) - SIZE;
            var result = await flatService
                .FindByCriteriaAsync(criteria.City, criteria.Rooms, criteria.PriceMin, criteria.PriceMax, criteria.RentType, criteria.PageNumber, SIZE, skip)
                .ConfigureAwait(false);
            return Ok(result.Select(dto => (FlatViewModel)dto));
        }
    }
}