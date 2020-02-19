using Adv.API.Models;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatController : ControllerBase
    {
        private readonly IFlatService flatService;

        public FlatController(IFlatService flatService)
        {
            this.flatService = flatService;
        }

        [HttpGet("getAll/{pageNumber}")]
        public async Task<ActionResult<List<FlatViewModel>>> GetAll(int pageNumber, CancellationToken ct = default)
        {

            const byte SIZE = 20;
            var skip = (SIZE * pageNumber) - SIZE;
            try
            {
                var flats = await flatService.GetAllAsync(pageNumber, SIZE, skip, ct).ConfigureAwait(false);
                return flats.Select(flatDto => (FlatViewModel)flatDto).ToList();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest(ex.Message);
                throw;
            }



        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FlatViewModel>> Get(int id, CancellationToken ct = default)
        {
            try
            {
                FlatViewModel result = await flatService.GetAsync(id, ct).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id, CancellationToken ct = default)
        {
            try
            {
                var result = await flatService.DeleteAsync(id, ct).ConfigureAwait(false);
                return result ? Ok(result) : (IActionResult)BadRequest(result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

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
                    var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    if (currentUserId == flatModel.UserId)
                    {
                        FlatViewModel result = await flatService.CreateAsync(flatModel, ct).ConfigureAwait(false);
                        return CreatedAtAction(nameof(Post), result);
                    }
                    else
                    {
                        return BadRequest();
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);

                    return BadRequest(ex.Message);
                    throw;
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }


}
