using Adv.API.Models;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatController : ControllerBase
    {
        private readonly ISuperManager _superManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public FlatController(ISuperManager superManager, 
            IHttpContextAccessor httpContextAccessor

            )
        {
            _superManager = superManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("getAll/{pageNumber}")]
        public async IAsyncEnumerable<FlatViewModel> GetAll(int pageNumber, [EnumeratorCancellation] CancellationToken ct = default)
        {
            const byte SIZE = 20;
            var skip = (SIZE * pageNumber) - SIZE;
            var flats = _superManager.Flats.GetAllAsync(pageNumber, SIZE, skip, ct).ConfigureAwait(false);
            await foreach (FlatViewModel flat in flats.WithCancellation(ct))
            {
                yield return flat;
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FlatViewModel>> Get(int id, CancellationToken ct = default)
        {
            try
            {
                FlatViewModel result = await _superManager.Flats.GetAsync(id, ct).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<FlatViewModel>> Post(FlatViewModel flatModel, CancellationToken ct = default)
        {
            if (!(flatModel is null))
            {
                try
                {
                    FlatViewModel result = await _superManager.Flats.CreateAsync(flatModel, ct).ConfigureAwait(false);
                    return CreatedAtAction(nameof(Post), result);
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
