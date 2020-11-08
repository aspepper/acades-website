using System;
namespace Acades.Dto
{
    public class FileDto
    {

        public int Id { get; set; }

        public int FileTypeId { get; set; }

        public FileTypeDto FileType { get; set; }

        public string FileName { get; set; }

        public string FileNameOriginal { get; set; }

        public string FileExtension { get; set; }

        public string Path { get; set; }

        public int? PersonId { get; set; }

        public PersonDto Person { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime InsertDate { get; set; }

        public int InsertUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public int UpdateUser { get; set; }

    }
}
