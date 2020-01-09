using Adv.API.Models.Enums;
using Adv.API.Models.Files;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
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
        public async Task<ActionResult<FileModel>> Post(IFormFile file, CancellationToken ct = default)
        {
            if (!(file is null))
            {
                try
                {
                    var result = await _superManager.Files.CloudUploadFileAsync(file, ct).ConfigureAwait(false);
                    return CreatedAtAction(nameof(Post),
                        new FileModel
                        {
                            LinkProps = result,
                            Name = Path.GetFileName(result),
                            Size = file.Length,
                            Status = FileResponseStatus.Response.Success.ToString().ToLower(CultureInfo.GetCultureInfo(1049)),
                            Uid = Path.GetFileNameWithoutExtension(result)
                        });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                    throw;
                }
            }

            return StatusCode(StatusCodes.Status503ServiceUnavailable);
        }
        [HttpDelete("{fileName}")]
        public async Task<IActionResult> Delete(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }

            var result = await _superManager.Files
                .CloudDeleteFileAsync(fileName).ConfigureAwait(false);

            return result ? Ok(result) : (IActionResult)BadRequest(result);

        }
    }
}