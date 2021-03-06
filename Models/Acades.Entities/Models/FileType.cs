﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Acades.Dto;

namespace Acades.Entities.Models
{
    public class FileType
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime InsertDate { get; set; }

        public int InsertUser { get; set; }

        public DateTime UpdateDate { get; set; }

        public int UpdateUser { get; set; }

        public ICollection<File> Files { get; set; }

        public static Expression<Func<FileType, FileTypeDto>> ToDto() => (c) => new FileTypeDto
        {
            Id = c.Id,
            Description = c.Description,
            Files = c.Files == null ? null : c.Files.Where(p => !p.IsDeleted).Select(f => File.ToDto(f)).ToList(),
            IsDeleted = c.IsDeleted,
            InsertDate = c.InsertDate,
            InsertUser = c.InsertUser,
            UpdateDate = c.UpdateDate,
            UpdateUser = c.UpdateUser,
        };

        public static FileTypeDto ToDto(FileType c) => new()
        {
            Id = c.Id,
            Description = c.Description,
            IsDeleted = c.IsDeleted,
            InsertDate = c.InsertDate,
            InsertUser = c.InsertUser,
            UpdateDate = c.UpdateDate,
            UpdateUser = c.UpdateUser
        };

    }
}
