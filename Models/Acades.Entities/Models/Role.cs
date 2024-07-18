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

        public string NormalizedName { get; set; }

        public string Area { get; set; }

        public bool IsVisible { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsAdm { get; set; }

        public DateTime InsertDate { get; set; }

        public int InsertUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public int UpdateUser { get; set; }

        public ICollection<PersonRole> Persons { get; set; }

        public static Expression<Func<Role, RoleDto>> ToDto() => (c) => new RoleDto
        {
            Id = c.Id,
            Description = c.Description,
            NormalizedName = c.NormalizedName,
            Area = c.Area,
            IsVisible = c.IsVisible,
            IsAdm = c.IsAdm,
            IsDeleted = c.IsDeleted,
            InsertDate = c.InsertDate,
            InsertUser = c.InsertUser,
            UpdateDate = c.UpdateDate,
            UpdateUser = c.UpdateUser,
            Persons = c.Persons == null ? null : c.Persons.Where(p => !p.IsDeleted).Select(e => PersonRole.ToDto(e)).ToList()
        };

        public static RoleDto ToDto(Role c) => new()
        {
            Id = c.Id,
            Description = c.Description,
            NormalizedName = c.NormalizedName,
            Area = c.Area,
            IsVisible = c.IsVisible,
            IsAdm = c.IsAdm,
            IsDeleted = c.IsDeleted,
            InsertDate = c.InsertDate,
            InsertUser = c.InsertUser,
            UpdateDate = c.UpdateDate,
            UpdateUser = c.UpdateUser
        };
    }   
}   
