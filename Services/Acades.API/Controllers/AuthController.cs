using Acades.API.Models;
using Acades.API.Services;
using Acades.Business;
using Acades.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Acades.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ILogger<AuthController> logger, IConfiguration configuration) : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<dynamic>> Authentication([FromBody] UserAuth userParam, [FromServices] RepositoryContext context, [FromServices] IConfiguration config)
        {
            try
            {
                logger.LogInformation("Entrei no Authentication");
                var user = new AuthBusiness(context, config).SignIn(userParam.UserName, userParam.Password);

                if (user == null)
                {
                    return NotFound(new { message = "Usuário ou Senha invávlido." });
                }

                var token = TokenService.GenerateToken(user, config);

                user.Password = "";
                return Ok(new
                {
                    user,
                    token
                });
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }

        }
    }
}