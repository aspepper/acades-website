using System;
using Microsoft.AspNetCore.Http;

namespace Acades.Dto
{
    public class StampWatermarkFormDto
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Text1 { get; set; }

        public string Text2 { get; set; }

        public string Text3 { get; set; }

        public string Password { get; set; }

        public string FileName { get; set; }

        public IFormFile File { get; set; }

        public string IPSource { get; set; }

    }
}
