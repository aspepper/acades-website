using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Acades.Dto;

namespace Acades.Entities.Models
{
    public class Role
    {

        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime InsertDate { get; set; }

        public int InsertUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public int UpdateUser { get; set; }

        public ICollection<PersonRole> Persons { get; set; }

        public static Expression<Func<Role, RoleDto>> ToDto()
        {
            return (c) => new RoleDto
            {
                Id = c.Id,
                Description = c.Description,
                IsDeleted = c.IsDeleted,
                InsertDate = c.InsertDate,
                InsertUser = c.InsertUser,
                UpdateDate = c.UpdateDate,
                UpdateUser = c.UpdateUser,
                Persons = c.Persons != null ? c.Persons.Select(e => PersonRole.ToDto(e)).ToList() : null
            };
        }
        public static RoleDto ToDto(Role c)
        {
            return new RoleDto
            {
                Id = c.Id,
                Description = c.Description,
                IsDeleted = c.IsDeleted,
                InsertDate = c.InsertDate,
                InsertUser = c.InsertUser,
                UpdateDate = c.UpdateDate,
                UpdateUser = c.UpdateUser,
                Persons = c.Persons?.Select(e => PersonRole.ToDto(e)).ToList()
            };
        }
    }
}
