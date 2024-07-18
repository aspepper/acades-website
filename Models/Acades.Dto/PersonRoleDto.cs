using System;
namespace Acades.Dto
{
    public class PersonRoleDto
    {

        public int Id { get; set; }

        public PersonDto Person { get; set; }

        public int PersonId { get; set; }

        public RoleDto Role { get; set; }

        public int RoleId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime InsertDate { get; set; }

        public int InsertUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public int UpdateUser { get; set; }

    }
}
