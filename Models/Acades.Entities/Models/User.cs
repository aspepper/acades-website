using System;
namespace Acades.Entities.Models
{
    public class User
    {

        public int Id { get; set; }

        public Person Person { get; set; }

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
