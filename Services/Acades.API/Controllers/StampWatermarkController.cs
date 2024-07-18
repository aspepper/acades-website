using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Acades.Business;
using Acades.Dto;
using Acades.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Acades.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StampWatermarkController : ControllerBase
    {

        protected StampWatermarkTextBusiness buzz;
        private readonly ILogger<StampWatermarkController> logger;
        private readonly IActionContextAccessor accessor;

        public StampWatermarkController(RepositoryContext context, ILogger<StampWatermarkController> logger, IConfiguration conf, IActionContextAccessor accessor)
        {
            buzz = new StampWatermarkTextBusiness(context, conf);
            this.logger = logger;
            this.accessor = accessor;
        }

        [HttpPost]
        [Route("StampTextsToPDF")]
        [Authorize(Roles = "ADMINISTRATOR,PDFPROTSERVICEUSER")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> StampTextsToPDF([FromBody] StampSimpleDto stampSimple, [FromServices] StampWatermarkTextBusiness stampWatermarkTextBusiness)
        {
            try
            {
                logger.LogInformation(JsonConvert.SerializeObject(stampSimple));
                var userdata = (((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.UserData).Value);
                stampSimple.UserId = int.Parse(userdata);
                stampSimple.IPSource = accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();
                var newPDF = await stampWatermarkTextBusiness.ManipulatePdf(stampSimple);
                return File(newPDF, "application/pdf", stampSimple.FileName);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("StampTextsToPDFFromLoad")]
        [Authorize(Roles = "ADMINISTRATOR,PDFPROTSERVICEUSER")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> StampTextsToPDFFromLoad([FromBody] StampSimpleDto stampSimple, [FromServices] StampWatermarkTextBusiness stampWatermarkTextBusiness)
        {
            try
            {
                logger.LogInformation(JsonConvert.SerializeObject(stampSimple));
                var userdata = (((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.UserData).Value);
                stampSimple.UserId = int.Parse(userdata);
                stampSimple.IPSource = accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();
                var newPDF = await stampWatermarkTextBusiness.ManipulatePdfFromURL(stampSimple);
                return File(newPDF, "application/pdf", stampSimple.FileName);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}