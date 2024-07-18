using System;
using System.Linq.Expressions;
using Acades.Dto;

namespace Acades.Entities.Models
{
    public class    PersonRole
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

        public static Expression<Func<PersonRole, PersonRoleDto>> ToDto() => c => new PersonRoleDto
        {
            Id = c.Id,
            PersonId = c.Person.Id,
            Person = c.Person == null ? null : Person.ToDto(c.Person),
            RoleId = c.Role.Id,
            Role = c.Role == null ? null : Role.ToDto(c.Role),
            IsDeleted = c.IsDeleted,
            InsertDate = c.InsertDate,
            InsertUser = c.InsertUser,
            UpdateDate = c.UpdateDate,
            UpdateUser = c.UpdateUser
        };

        public static PersonRoleDto ToDto(PersonRole c) => new()
        {
            Id = c.Id,
            PersonId = c.Person.Id,
            Person = c.Person == null ? null : Person.ToDto(c.Person),
            RoleId = c.RoleId,
            Role = c.Role == null ? null : Role.ToDto(c.Role),
            IsDeleted = c.IsDeleted,
            InsertDate = c.InsertDate,
            InsertUser = c.InsertUser,
            UpdateDate = c.UpdateDate,
            UpdateUser = c.UpdateUser
        };
    }
}
