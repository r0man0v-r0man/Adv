﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Get(CancellationToken ct = default)
        {
            try
            {
                var result = _superManager.GetFlats().GetAsync(2);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}