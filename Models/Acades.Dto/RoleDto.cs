﻿using System;
using System.Collections.Generic;

namespace Acades.Dto
{
    public class RoleDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime InsertDate { get; set; }

        public int InsertUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public int UpdateUser { get; set; }

        public IList<PersonRoleDto> Persons { get; set; }

    }
}
