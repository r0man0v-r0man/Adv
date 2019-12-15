using Adv.API.Models;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatController : ControllerBase
    {
        private readonly ISuperManager _superManager;
        public FlatController(ISuperManager superManager)
        {
            _superManager = superManager;
        }

        [HttpGet]
        public async IAsyncEnumerable<FlatViewModel> Get(CancellationToken ct = default)
        {
            var flats = _superManager.Flats.GetAsync(ct).ConfigureAwait(false);

            await foreach (var flat in flats)
            {
                yield return new FlatViewModel
                {
                    Description = flat.Description,
                    Id = flat.Id,
                    District = flat.District
                };
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FlatViewModel>> Get(int id, CancellationToken ct = default)
        {
            try
            {
                var result = await _superManager.Flats.GetAsync(id, ct).ConfigureAwait(false);
                return Ok(new FlatViewModel
                {
                    Description = result.Description,
                    Id = result.Id,
                    District = result.District
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }

    
}
