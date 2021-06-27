using System.Collections.Generic;
using System.Security.Claims;

namespace Acades.Dto
{
    public class StampSimpleDto
    {

        public string FileName { get; set; }

        public string Name   { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Document { get; set; }

        public bool PrintCustomerData { get; set; }

        public string PdfURL { get; set; }

        public byte[] PdfFile { get; set; }

        public TextPropertiesDto[] Texts { get; set; }

        public int UserId { get; set; }

    }
}
