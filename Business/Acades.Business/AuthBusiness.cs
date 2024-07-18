using System;
using System.Linq;
using Acades.Dto;
using Acades.Entities;
using Acades.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Acades.Business
{
    public class AuthBusiness: BaseBusiness
    {

        private readonly IConfiguration configuration;

        public AuthBusiness(RepositoryContext context, IConfiguration config) : base(context)
        {
            configuration = config;
        }

        /// <summary>
        /// Get User Data Whether User and Password Has Been Validation Done
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserDto SignIn(string userName, string password)
        {
            var secretKey = configuration.GetSection("SecretKey").Value;

            var userDto = context.Users
                                 .Include(u => u.Person)
                                 .ThenInclude(p => p.Roles)
                                 .ThenInclude(pr => pr.Role)
                                 .Where(u => u.UserName.ToLower() == userName.ToLower())
                                 .Select(User.ToDto())
                                 .FirstOrDefault();

            if (AesCrypto.Decrypt(userDto.Password, secretKey) != password) { userDto = null; }
            return userDto;
        }

    }
}
