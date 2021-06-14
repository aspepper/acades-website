using System;
namespace Acades.Dto
{
    public class StampSimpleDto
    {

        public string FileName { get; set; }

        public string URL { get; set; }

        public byte[] ImageSource { get; set; }

        public TextPropertiesDto[] Texts { get; set; }

    }
}
