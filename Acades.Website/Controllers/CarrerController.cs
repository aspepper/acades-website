using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Acades.Entities.Models;
using Microsoft.Extensions.Configuration;

namespace Acades.Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrerController : ControllerBase
    {

        private readonly ILogger<CarrerController> _logger;
        private readonly IConfiguration _conf;

        public CarrerController(ILogger<CarrerController> logger, IConfiguration conf)
        {
            _logger = logger;
            _conf = conf;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public int Get(int id) => id;

        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Save([FromBody] Person person)
        {

            var ret = await Task.FromResult<int>(1);

            return Ok(ret);
        }


    }
}