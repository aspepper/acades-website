using System;
using System.Threading.Tasks;
using Acades.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace Acades.Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerController : ControllerBase, IDisposable
    {

        private readonly ILogger<CareerController> logger;
        private readonly IConfiguration configuration;
        private HttpClient client;

        public CareerController(ILogger<CareerController> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
            client = new HttpClient
            { BaseAddress = new Uri(string.Concat(configuration.GetSection("ApiServiceURL").Value, "api/carrer/")) };
        }

        [HttpGet]
        [Route("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Get()
        {
            var ret = await Task.FromResult<int>(1);

            return Ok(ret);
        }

        [HttpPost]
        [Route("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Save([FromBody] Person person)
        {
            try
            {
                var personContext = JsonConvert.SerializeObject(person);
                var httpContext = new StringContent(personContext, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var ret = await client.PostAsync($"Save", httpContext);

                ret.EnsureSuccessStatusCode();
                string responseBody = await ret.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<int>(responseBody);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return BadRequest(JsonConvert.SerializeObject(ex));
            }
        }

        public void Dispose()
        {
            client.Dispose();
            client = null;
        }

    }
}