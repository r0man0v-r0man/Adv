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
            var flatsDTO = _superManager.Flats.GetAsync(ct).ConfigureAwait(false);

            await foreach (var flat in flatsDTO)
            {
                yield return flat;
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FlatViewModel>> Get(int id, CancellationToken ct = default)
        {
            try
            {
                var result = await _superManager.Flats.GetAsync(id, ct).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<FlatViewModel>> Post(FlatViewModel flatModel, CancellationToken ct = default)
        {
            if (!(flatModel is null))
            {
                try
                {
                    FlatViewModel result = await _superManager.Flats.CreateAsync(flatModel, ct).ConfigureAwait(false);
                    return result;
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                    throw;
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    
}
