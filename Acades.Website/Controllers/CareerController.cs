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

        private readonly ILogger<CareerController> _logger;
        private readonly IConfiguration _conf;
        private HttpClient client;

        public CareerController(ILogger<CareerController> logger, IConfiguration conf)
        {
            _logger = logger;
            _conf = conf;
            client = new HttpClient();
            client.BaseAddress = new Uri(string.Concat(conf.GetSection("ApiServiceURL").Value, "api/Carrer/"));
        }

        [HttpGet("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Get()
        {

            var ret = await Task.FromResult<int>(1);

            return Ok(ret);
        }

        [HttpPost("save")]
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
            catch(Exception ex){
                return BadRequest(ex);
            }
        }

        public void Dispose()
        {
            client.Dispose();
            client = null;
        }

    }
}