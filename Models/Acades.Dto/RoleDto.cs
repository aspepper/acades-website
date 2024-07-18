using System;
using System.Collections.Generic;

namespace Acades.Dto
{
    public class RoleDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string NormalizedName { get; set; }

        public string Area { get; set; }

        public bool IsVisible { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsAdm { get; set; }

        public DateTime InsertDate { get; set; }

        public int InsertUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public int UpdateUser { get; set; }

        public IList<PersonRoleDto> Persons { get; set; } = new List<PersonRoleDto>();

    }
}
