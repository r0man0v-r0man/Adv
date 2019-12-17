using Adv.API.Models;
using Adv.BLL.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public FlatController(ISuperManager superManager, IMapper mapper)
        {
            _superManager = superManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async IAsyncEnumerable<FlatViewModel> Get(CancellationToken ct = default)
        {
            var flatsDTO = _superManager.Flats.GetAsync(ct).ConfigureAwait(false);

            await foreach (var flat in flatsDTO)
            {
                yield return _mapper.Map<FlatViewModel>(flat);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FlatViewModel>> Get(int id, CancellationToken ct = default)
        {
            try
            {
                var result = await _superManager.Flats.GetAsync(id, ct).ConfigureAwait(false);
                return Ok(_mapper.Map<FlatViewModel>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                throw;
            }
        }
    }

    
}
