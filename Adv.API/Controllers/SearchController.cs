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
            var result = await flatService
                .FindByCriteriaAsync(criteria.City, criteria.Rooms, criteria.PriceMin, criteria.PriceMax, criteria.RentType)
                .ConfigureAwait(false);
            return Ok(result.Select(dto => (FlatViewModel)dto));
        }
    }
}