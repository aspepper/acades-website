using System;
using System.Collections.Generic;

namespace Acades.Dto
{
    public class PersonDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Document { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime InsertDate { get; set; }

        public int InsertUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public int UpdateUser { get; set; }

        public IList<UserDto> Users { get; set; } = new List<UserDto>();

        public IList<PersonRoleDto> Roles { get; set; } = new List<PersonRoleDto>();

        public IList<FileDto> Files { get; set; } = new List<FileDto>();

    }
}
