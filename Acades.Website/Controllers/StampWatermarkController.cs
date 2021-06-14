using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Acades.Business;
using Acades.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Acades.Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StampWatermarkController : ControllerBase
    {

        private readonly ILogger<StampWatermarkController> _logger;
        private readonly IConfiguration _conf;

        public StampWatermarkController(ILogger<StampWatermarkController> logger, IConfiguration conf)
        {
            _logger = logger;
            _conf = conf;
        }

        [HttpPost("StampTextsToPDF")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> StampTextsToPDF([FromBody] StampSimpleDto stampSimple, [FromServices] StampWatermarkTextBusiness stampWatermarkTextBusiness)
        {
            Debug.WriteLine(stampSimple);
            var newPDF = await stampWatermarkTextBusiness.ManipulatePdf(stampSimple);
            return File(newPDF, "application/pdf", stampSimple.FileName);
        }

        [HttpPost("StampTextsToPDFFromLoad")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> StampTextsToPDFFromLoad([FromBody] StampSimpleDto stampSimple, [FromServices] StampWatermarkTextBusiness stampWatermarkTextBusiness)
        {
            Debug.WriteLine(stampSimple);
            var newPDF = await stampWatermarkTextBusiness.ManipulatePdfFromURL(stampSimple);
            return File(newPDF, "application/pdf", stampSimple.FileName);
        }

    }
}