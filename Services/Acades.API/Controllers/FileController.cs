using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acades.Business;
using Acades.Entities;
using Acades.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Acades.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        protected FileBusiness buzz;

        public FileController(RepositoryContext context, IConfiguration conf)
        {
            buzz = new FileBusiness(context, conf);
        }

        [HttpGet("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var roles = await buzz.GetListAll();

                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex));
            }

        }

        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Save([FromBody] File file)
        {
            try
            {
                int id;
                if (file.Id == 0)
                {
                    id = await buzz.Insert(file);
                }
                else
                {
                    id = await buzz.Update(file);
                }

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex));
            }

        }

    }
}