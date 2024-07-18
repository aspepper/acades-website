using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acades.Dto;
using Acades.Entities;
using Acades.Entities.Models;
using Microsoft.Extensions.Configuration;

namespace Acades.Business
{
    public class RoleBusiness : BaseBusiness
    {
        private readonly IConfiguration _conf;

        public RoleBusiness(RepositoryContext context, IConfiguration con)
            : base(context)
        {
            this._conf = con;
        }

        public async Task<IList<RoleDto>> GetListRoles()
        {
            var roles = context
                        .Roles
                        .Where(r => r.IsVisible)
                        .AsQueryable();

            return await Task.FromResult(roles.Select(e => Role.ToDto(e)).ToList());
        }

    }
}
