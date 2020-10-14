using System;
using Acades.Contracts;
using Acades.Entities;
using Acades.Entities.Models;

namespace Acades.Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
