using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acades.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Acades.Business;

namespace Acades.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrerController : ControllerBase
    {
        // GET: api/Carrer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Carrer/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Carrer
        [HttpPost("Save")]
        public async Task<int> Post([FromBody] Person person, [FromServices] CarrerBusiness buzz)
        {
            var Id = await buzz.Insert(person);
            return Id;
        }

        // PUT: api/Carrer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
