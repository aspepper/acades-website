using System;
using System.Threading.Tasks;
using Acades.Website.Models;
using Acades.Website.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acades.Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private IBlobService _blobService;

        public UploadController(IBlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpPost("blob"), DisableRequestSizeLimit]
        public async Task<ActionResult> UploadToBlob()
        {
            IFormFile file = Request.Form.Files[0];
            if (file == null)
            {
                return BadRequest();
            }

            var ext = System.IO.Path.GetExtension(file.FileName);

            var f = new FileUploaded()
            {
                FileNameOriginal = file.FileName,
                Extension = ext.Replace(".",""),
                FileName = string.Format(@"{0}{1}", Guid.NewGuid(), ext)
            };

            var result = await _blobService.UploadFileBlobAsync(
                    "files",
                    file.OpenReadStream(),
                    file.ContentType,
                    f.FileName);

            f.AbsoluteUri = result.AbsoluteUri;

            return Ok(f);
        }

    }
}