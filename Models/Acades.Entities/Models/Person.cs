using System;
using System.Collections.Generic;
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


        public static Expression<Func<Person, PersonDto>> ToDto()
        {
            return c => new PersonDto
            {
                Id = c.Id,
                Name = c.Name,
                Document = c.Document,
                BirthDate = c.BirthDate,
                IsDeleted = c.IsDeleted,
                InsertDate = c.InsertDate,
                InsertUser = c.InsertUser,
                UpdateDate = c.UpdateDate,
                UpdateUser = c.UpdateUser
            };
        }
        public static PersonDto ToDto(Person c)
        {
            return new PersonDto
            {
                Id = c.Id,
                Name = c.Name,
                Document = c.Document,
                BirthDate = c.BirthDate,
                IsDeleted = c.IsDeleted,
                InsertDate = c.InsertDate,
                InsertUser = c.InsertUser,
                UpdateDate = c.UpdateDate,
                UpdateUser = c.UpdateUser
            };
        }

    }
}
