using System;
using System.IO;
using System.Threading.Tasks;
using Acades.Business;
using Acades.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Acades.Website.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StampWatermarkController : ControllerBase
    {

        private readonly ILogger<StampWatermarkController> logger;
        private readonly IConfiguration configuration;
        private readonly IActionContextAccessor accessor;

        public StampWatermarkController(ILogger<StampWatermarkController> logger, IConfiguration configuration, IActionContextAccessor accessor)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.accessor = accessor;
        }

        [HttpPost]
        [Route("StampTextsToPDF")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> StampTextsToPDF([FromForm] StampWatermarkFormDto stamp, [FromServices] StampWatermarkTextBusiness stampWatermarkTextBusiness)
        {
            try
            {
                logger.LogInformation("Entrei no StampTextsToPDF");
                using MemoryStream ms = new();
                var stampSimple = new StampSimpleDto();
                stamp.File.CopyTo(ms);

                stampSimple.Name = stamp.Name;
                stampSimple.Texts = new TextPropertiesDto[]
                {
                new TextPropertiesDto { Text = stamp.Text1, Color = "Blue", FontName="Helvetica-Bold", FontSize=20, Opacity=0.5f, PosX=480f, PosY=700F, Radio=5.60f },
                (String.IsNullOrEmpty(stamp.Text2) ? null : new TextPropertiesDto { Text = stamp.Text2 , Color = "Green", FontName="Helvetica-Bold", FontSize=20f, Opacity=0.5f, PosX=300f, PosY=400f, Radio=5.60f}),
                (String.IsNullOrEmpty(stamp.Text3) ? null : new TextPropertiesDto { Text = stamp.Text3, Color = "Red", FontName="Helvetica-Bold", FontSize=20f, Opacity=0.5f, PosX=100f, PosY=130f, Radio=5.60f })
                };

                stampSimple.UserId = 0;
                stampSimple.Email = stamp.Email;
                stampSimple.FileName = stamp.File.FileName;
                stampSimple.Password = stamp.Password;
                stampSimple.PdfFile = ms.ToArray();
                stampSimple.IPSource = accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();

                return Ok(await stampWatermarkTextBusiness.ManipulatePdf(stampSimple));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        [HttpPost]
        [Route("StampTextsToPDFFromLoad")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> StampTextsToPDFFromLoad([FromBody] StampSimpleDto stampSimple, [FromServices] StampWatermarkTextBusiness stampWatermarkTextBusiness)
        {
            try
            {
                logger.LogInformation("Entrei no StampTextsToPDF");
                var newPDF = await stampWatermarkTextBusiness.ManipulatePdfFromURL(stampSimple);
                return Ok(File(newPDF, "application/pdf", stampSimple.FileName));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

    }

}