using System;
using System.Linq.Expressions;
using Acades.Dto;

namespace Acades.Entities.Models
{
    public class PersonRole
    {

        public int Id { get; set; }

        public Person Person { get; set; }

        public int PersonId { get; set; }

        public Role Role { get; set; }

        public int RoleId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime InsertDate { get; set; }

        public int InsertUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public int UpdateUser { get; set; }

        public static Expression<Func<PersonRole, PersonRoleDto>> ToDto()
        {
            return c => new PersonRoleDto
            {
                Id = c.Id,
                Person = Person.ToDto(c.Person),
                PersonId = c.Person.Id,
                Role = Role.ToDto(c.Role),
                RoleId = c.Role.Id,
                IsDeleted = c.IsDeleted,
                InsertDate = c.InsertDate,
                InsertUser = c.InsertUser,
                UpdateDate = c.UpdateDate,
                UpdateUser = c.UpdateUser
            };
        }

        public static PersonRoleDto ToDto(PersonRole c)
        {
            return new PersonRoleDto
            {
                Id = c.Id,
                Person = Person.ToDto(c.Person),
                PersonId = c.Person.Id,
                Role = Role.ToDto(c.Role),
                RoleId = c.Role.Id,
                IsDeleted = c.IsDeleted,
                InsertDate = c.InsertDate,
                InsertUser = c.InsertUser,
                UpdateDate = c.UpdateDate,
                UpdateUser = c.UpdateUser
            };
        }

    }
}
