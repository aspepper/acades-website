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
using Acades.Dto;
using System.Collections.Generic;

namespace Acades.Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase, IDisposable
    {

        private readonly ILogger<FileController> _logger;
        private readonly IConfiguration _conf;
        private HttpClient client;

        public FileController(ILogger<FileController> logger, IConfiguration conf)
        {
            _logger = logger;
            _conf = conf;
            client = new HttpClient
            {
                BaseAddress = new Uri(string.Concat(conf.GetSection("ApiServiceURL").Value, "api/file/"))
            };
        }

        [HttpGet("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Get()
        {
            try
            {
                var ret = await client.GetAsync($"get");

                ret.EnsureSuccessStatusCode();
                string responseBody = await ret.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<List<FileDto>>(responseBody);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Save([FromBody] File file)
        {
            try
            {
                var dataContext = JsonConvert.SerializeObject(file);

                var httpContext = new StringContent(dataContext, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var ret = await client.PostAsync($"Save", httpContext);

                ret.EnsureSuccessStatusCode();
                string responseBody = await ret.Content.ReadAsStringAsync();
                var retorno = JsonConvert.DeserializeObject<int>(responseBody);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
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