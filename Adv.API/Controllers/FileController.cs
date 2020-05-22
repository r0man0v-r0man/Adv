using Adv.API.Models.Files;
using Adv.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly IFileService fileService;
        public FileController(IFileService fileService)
        {
            this.fileService = fileService;
        }
        [HttpPost]
        public async Task<ActionResult<FileModel>> Post(IFormFile file, CancellationToken ct = default)
        {
            if (file is null) return StatusCode(StatusCodes.Status503ServiceUnavailable);
            try
            {
                var result = await fileService.UploadAsync(file, ct).ConfigureAwait(false);
                return CreatedAtAction(nameof(Post),
                    new FileModel
                    {
                        LinkProps = result["link"],
                        Name = Path.GetFileName(result["link"]),
                        Size = file.Length,
                        Uid = Path.GetFileNameWithoutExtension(result["link"]),
                        DeleteHash = result["deleteHash"]
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }
        [HttpDelete("{deleteHash}")]
        public async Task<IActionResult> Delete(string deleteHash)
        {
            if (string.IsNullOrEmpty(deleteHash))
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }

            var result = await fileService
                .DeleteAsync(deleteHash).ConfigureAwait(false);

            return result ? Ok(result) : (IActionResult)BadRequest(result);

        }
    }
}