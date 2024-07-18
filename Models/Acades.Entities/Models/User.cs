using System;
using System.Linq.Expressions;
using Acades.Dto;

namespace Acades.Entities.Models
{
    public class User
    {

        public int Id { get; set; }

        public Person Person { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int PersonId { get; set; }

        public string Password { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime InsertDate { get; set; }

        public int InsertUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public int UpdateUser { get; set; }

        public static Expression<Func<User, UserDto>> ToDto() => (c) => new UserDto
        {
            Id = c.Id,
            Person = c.Person == null ? null : Person.ToDto(c.Person),
            UserName = c.UserName,
            Email = c.Email,
            PersonId = c.PersonId,
            Password = c.Password,
            IsDeleted = c.IsDeleted,
            InsertDate = c.InsertDate,
            InsertUser = c.InsertUser,
            UpdateDate = c.UpdateDate,
            UpdateUser = c.UpdateUser,
        };

        public static UserDto ToDto(User c) => new()
        {
            Id = c.Id,
            Person = c.Person == null ? null : Person.ToDto(c.Person),
            UserName = c.UserName,
            Email = c.Email,
            PersonId = c.PersonId,
            Password = c.Password,
            IsDeleted = c.IsDeleted,
            InsertDate = c.InsertDate,
            InsertUser = c.InsertUser,
            UpdateDate = c.UpdateDate,
            UpdateUser = c.UpdateUser
        };

    }
}
