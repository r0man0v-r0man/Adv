using Adv.API.Models.Enums;
using Adv.API.Models.Files;
using Adv.API.Models.Files.Link;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Adv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ISuperManager _superManager;
        public FileController(ISuperManager superManager)
        {
            _superManager = superManager;
        }
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file, CancellationToken ct = default)
        {
            if (!(file is null))
            {
                try
                {
                    var result = await _superManager.Files.CloudUploadFileAsync(file, ct).ConfigureAwait(false);
                    return CreatedAtAction(nameof(Post),
                        new FileModel
                        {
                            LinkProps = new Links { Download = result },
                            Name = Path.GetFileName(result),
                            Size = file.Length,
                            Status = FileResponseStatus.Response.Success.ToString().ToLower()
                        });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return StatusCode(StatusCodes.Status503ServiceUnavailable);
        }
    }
}