using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StampWatermakService.Business;
using StampWatermarkEntity.Models;

namespace StampWatermakService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StampWatermarkController : ControllerBase
    {

        private readonly ILogger<StampWatermarkController> _logger;

        public StampWatermarkController(ILogger<StampWatermarkController> logger)
        {
            _logger = logger;
        }

        [HttpPost("StampTextsToPDF")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> StampTextsToPDF([FromBody] StampSimple stampSimple)
        {
            Debug.WriteLine(stampSimple);
            var buzz = new StampWatermarkText();
            var newPDF = await buzz.ManipulatePdf(stampSimple);
            return File(newPDF, "application/pdf", stampSimple.FileName);
        }

    }

}