using System;
using System.Threading.Tasks;
using Acades.Entities;
using Acades.Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Acades.Business
{
    public class CarrerBusiness : BaseBusiness
    {

        private readonly IConfiguration _conf;

        public CarrerBusiness(RepositoryContext context, IConfiguration con)
            : base(context)
        {
            this._conf = con;
        }

        public async Task<int> Insert(Person person)
        {
            context.Add(person);
            _ = context.SaveChanges(true);

            return await Task.FromResult<int>(person.Id);

        }

    }
}
