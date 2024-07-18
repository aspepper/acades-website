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
using Newtonsoft.Json;

namespace Acades.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrerController : ControllerBase
    {

        protected CarrerBusiness buzz;

        public CarrerController(RepositoryContext context, IConfiguration conf)
        {
            buzz = new CarrerBusiness(context, conf);
        }

        // GET: api/Carrer
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Carrer/5
        [HttpGet]
        [Route("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Carrer
        [HttpPost]
        [Route("Save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Post([FromBody] Person person)
        {
            try
            {
                var Id = await buzz.Insert(person);
                return Ok(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex));
            }
        }

        // PUT: api/Carrer/5
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public void Delete(int id)
        {
        }
    }
}
