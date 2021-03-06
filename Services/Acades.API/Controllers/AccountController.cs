using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acades.Business;
using Acades.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acades.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {


        [HttpPost]
        [Route("Add")]
        [AllowAnonymous]
        public Task<Boolean> Save([FromBody] PersonDto personData, [FromServices] UserBusiness userBusiness)
        {
            var user = userBusiness.Create(personData);
            return Task.FromResult(user != null);

        }

    }
}