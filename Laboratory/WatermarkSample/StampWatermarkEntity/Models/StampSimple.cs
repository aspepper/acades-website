using System;
namespace StampWatermarkEntity.Models
{
    public class StampSimple
    {

        public string FileName { get; set; }

        public byte[] ImageSource { get; set; }

        public TextProperties[] Texts { get; set; }

    }
}
