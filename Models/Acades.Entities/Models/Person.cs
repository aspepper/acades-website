using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Acades.Dto;

namespace Acades.Entities.Models
{
    public class Person
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

        public ICollection<User> Users { get; set; }

        public ICollection<PersonRole> Roles { get; set; }

        public ICollection<File> Files { get; set; }


        public static Expression<Func<Person, PersonDto>> ToDto() => c => new PersonDto
        {
            Id = c.Id,
            Name = c.Name,
            Document = c.Document,
            BirthDate = c.BirthDate,
            Users = c.Users == null ? null : c.Users.Where(p => !p.IsDeleted).Select(e => User.ToDto(e)).ToList(),
            Roles = c.Roles == null ? null : c.Roles.Where(p => !p.IsDeleted).Select(e => PersonRole.ToDto(e)).ToList(),
            Files = c.Files == null ? null : c.Files.Where(p => !p.IsDeleted).Select(e => File.ToDto(e)).ToList(),
            IsDeleted = c.IsDeleted,
            InsertDate = c.InsertDate,
            InsertUser = c.InsertUser,
            UpdateDate = c.UpdateDate,
            UpdateUser = c.UpdateUser
        };

        public static PersonDto ToDto(Person c) => new()
        {
            Id = c.Id,
            Name = c.Name,
            Document = c.Document,
            BirthDate = c.BirthDate,
            Users = c.Users?.Where(p => !p.IsDeleted)
            .Select(p => new UserDto
            {
                Id = p.Id,
                Person = null,
                UserName = p.UserName,
                Email = p.Email,
                PersonId = c.Id,
                Password = p.Password,
                IsDeleted = p.IsDeleted,
                InsertDate = p.InsertDate,
                InsertUser = p.InsertUser,
                UpdateDate = p.UpdateDate,
                UpdateUser = p.UpdateUser
            }).ToList(),
            Roles = c.Roles?.Where(p => !p.IsDeleted)
            .Select(p => new PersonRoleDto
            {
                Id = p.Id,
                PersonId = c.Id,
                Person = null,
                RoleId = p.RoleId,
                Role = p.Role == null ? null : Role.ToDto(p.Role),
                IsDeleted = p.IsDeleted,
                InsertDate = p.InsertDate,
                InsertUser = p.InsertUser,
                UpdateDate = p.UpdateDate,
                UpdateUser = p.UpdateUser
            }).ToList(),
            Files = c.Files?.Where(p => !p.IsDeleted)
            .Select(p => new FileDto
            {
                Id = p.Id,
                FileTypeId = p.FileTypeId,
                FileType = null,
                FileName = p.FileName,
                FileNameOriginal = p.FileNameOriginal,
                FileExtension = p.FileExtension,
                Path = p.Path,
                PersonId = c.Id,
                IsDeleted = p.IsDeleted,
                InsertDate = p.InsertDate,
                InsertUser = p.InsertUser,
                UpdateDate = p.UpdateDate,
                UpdateUser = p.UpdateUser
            }).ToList(),
            IsDeleted = c.IsDeleted,
            InsertDate = c.InsertDate,
            InsertUser = c.InsertUser,
            UpdateDate = c.UpdateDate,
            UpdateUser = c.UpdateUser
        };

    }
}
