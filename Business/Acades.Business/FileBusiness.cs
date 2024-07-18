using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acades.Dto;
using Acades.Entities;
using Acades.Entities.Models;
using Microsoft.Extensions.Configuration;

namespace Acades.Business
{
    public class FileBusiness : BaseBusiness
    {
        private readonly IConfiguration _conf;

        public FileBusiness(RepositoryContext context, IConfiguration con)
            : base(context)
        {
            this._conf = con;
        }

        public async Task<IList<FileDto>> GetListAll()
        {
            var files = context
                        .Files
                        .AsQueryable();

            return await Task.FromResult(files.Select(e => File.ToDto(e)).ToList());
        }

        public async Task<int> Insert(File file)
        {
            context.Files.Add(file);
            _ = context.SaveChanges(true);

            return await Task.FromResult<int>(file.Id);

        }

        public async Task<int> Update(File file)
        {
            context.Files.Update(file);
            _ = context.SaveChanges(true);

            return await Task.FromResult<int>(file.Id);

        }
    }
}
