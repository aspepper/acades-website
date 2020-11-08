using System;
using System.Linq.Expressions;
using Acades.Dto;

namespace Acades.Entities.Models
{
    public class File
    {

        public int Id { get; set; }

        public int FileTypeId { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string FileNameOriginal { get; set; }

        public string FileExtension { get; set; }

        public string Path { get; set; }

        public int? PersonId { get; set; }

        public Person Person { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime InsertDate { get; set; }

        public int InsertUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public int UpdateUser { get; set; }

        public static Expression<Func<File, FileDto>> ToDto()
        {
            return (c) => new FileDto
            {
                Id = c.Id,
                FileTypeId = c.FileTypeId,
                FileType = FileType.ToDto(c.FileType),
                FileName = c.FileName,
                FileNameOriginal = c.FileNameOriginal,
                FileExtension = c.FileExtension,
                Path = c.Path,
                PersonId = c.PersonId,
                Person = Person.ToDto(c.Person),
                IsDeleted = c.IsDeleted,
                InsertDate = c.InsertDate,
                InsertUser = c.InsertUser,
                UpdateDate = c.UpdateDate,
                UpdateUser = c.UpdateUser,
            };
        }

        public static FileDto ToDto(File c)
        {
            return new FileDto
            {
                Id = c.Id,
                FileTypeId = c.FileTypeId,
                FileType = FileType.ToDto(c.FileType),
                FileName = c.FileName,
                FileNameOriginal = c.FileNameOriginal,
                FileExtension = c.FileExtension,
                Path = c.Path,
                PersonId = c.PersonId,
                Person = Person.ToDto(c.Person),
                IsDeleted = c.IsDeleted,
                InsertDate = c.InsertDate,
                InsertUser = c.InsertUser,
                UpdateDate = c.UpdateDate,
                UpdateUser = c.UpdateUser
            };
        }


    }
}
