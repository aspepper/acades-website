using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acades.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Acades.Business;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Acades.Dto;
using Newtonsoft.Json;

namespace Acades.Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase, IDisposable
    {

        private readonly ILogger<RoleController> _logger;
        private readonly IConfiguration _conf;
        private HttpClient client;

        public RoleController(ILogger<RoleController> logger, IConfiguration conf)
        {
            _logger = logger;
            _conf = conf;
            client = new HttpClient
            {
                BaseAddress = new Uri(string.Concat(conf.GetSection("ApiServiceURL").Value, "api/role/"))
            };
        }

        [HttpGet("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<List<RoleDto>> Get()
        {
            var ret = await client.GetAsync($"get");

            ret.EnsureSuccessStatusCode();
            string responseBody = await ret.Content.ReadAsStringAsync();
            var retorno = JsonConvert.DeserializeObject<List<RoleDto>>(responseBody);

            return retorno;
        }

        public void Dispose()
        {
            client.Dispose();
            client = null;
        }

    }
}