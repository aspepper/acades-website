using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Acades.Dto;
using Acades.Entities;
using Acades.Entities.Models;
using Microsoft.Extensions.Configuration;

namespace Acades.Business
{
    public class UserBusiness : BaseBusiness
    {

        private readonly IConfiguration configuration;
        private new readonly RepositoryContext context;

        public UserBusiness(RepositoryContext context, IConfiguration configuration) : base(context)
        {
            this.configuration = configuration;
            this.context = context;
        }

        public PersonDto Create(PersonDto model)
        {
            PersonDto personReturn = new();
            var transaction = context.Database.BeginTransaction();
            try
            {
                Person person = new()
                {
                    Name = model.Name,
                    Document = model.Document,
                    BirthDate = model.BirthDate,
                    InsertDate = DateTime.Now,
                    InsertUser = model.InsertUser,
                    UpdateDate = DateTime.Now,
                    UpdateUser = model.InsertUser
                };

                context.Persons.Add(person);
                context.SaveChanges();

                personReturn = Person.ToDto(person);

                foreach (PersonRoleDto personRoleData in model.Roles)
                {
                    PersonRole personRole = new()
                    {
                        PersonId = person.Id,
                        RoleId = personRoleData.RoleId,
                        InsertDate = DateTime.Now,
                        InsertUser = model.InsertUser,
                        UpdateDate = DateTime.Now,
                        UpdateUser = model.InsertUser,
                        IsDeleted = false
                    };

                    context.PersonRoles.Add(personRole);
                    context.SaveChanges();

                    var personRoleDto = PersonRole.ToDto(personRole);
                    if (personReturn.Roles == null) { personReturn.Roles = new List<PersonRoleDto>(); }
                    personReturn.Roles.Add(personRoleDto);

                }

                foreach (UserDto userData in model.Users)
                {

                    User user = new()
                    {
                        PersonId = person.Id,
                        UserName = userData.UserName,
                        Password = AesCrypto.Encrypt(userData.Password, configuration["SecretKey"].ToString()),
                        Email = userData.Email,
                        InsertDate = DateTime.Now,
                        InsertUser = model.InsertUser,
                        UpdateDate = DateTime.Now,
                        UpdateUser = model.InsertUser
                    };

                    context.Users.Add(user);
                    context.SaveChanges();

                    var userDto = User.ToDto(user);
                    if (personReturn.Users == null) { personReturn.Users = new List<UserDto>(); }
                    personReturn.Users.Add(userDto);

                }

                transaction.Commit();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                transaction.Rollback();
            }

            return personReturn;
        }


    }
}
