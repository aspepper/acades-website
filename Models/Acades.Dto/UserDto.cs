using System;
namespace Acades.Dto
{
    public class UserDto
    {

        public int Id { get; set; }

        public PersonDto Person { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int PersonId { get; set; }

        public string Password { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime InsertDate { get; set; }

        public int InsertUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public int UpdateUser { get; set; }

    }
}
