using System;
using System.Threading.Tasks;
using Acades.Business;
using Acades.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Acades.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        protected RoleBusiness buzz;

        public RoleController(RepositoryContext context, IConfiguration conf)
        {
            buzz = new RoleBusiness(context, conf);
        }

        // GET: api/Carrer/5
        [HttpGet]
        [Route("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var roles = await buzz.GetListRoles();

                return Ok(roles);
            }
            catch(Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex));
            }

        }


    }
}