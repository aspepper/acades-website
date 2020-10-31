using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acades.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Acades.Business;
using Microsoft.Extensions.Options;
using Acades.Entities;
using Microsoft.Extensions.Configuration;
using Acades.Dto;

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
        [HttpGet("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IList<RoleDto>> Get()
        {
            var roles = await buzz.GetListRoles();

            return roles;

        }


    }
}