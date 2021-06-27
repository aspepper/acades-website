using System;
namespace Acades.Entities.Models
{
    public class PdfServiceRegister
    {

        public int Id { get; set; }

        public int? UserId { get; set; }

        public DateTime GeneratedDate { get; set; }

        public string FileName { get; set; }

        public string FilePdfUrl { get; set; }

        public string OwnerName { get; set; }

        public string OwnerEmail { get; set; }

        public string OwnerDocument { get; set; }

        public bool PrintCustomerData { get; set; }

        public string Error { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime InsertDate { get; set; }

        public int InsertUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public int UpdateUser { get; set; }

    }
}
