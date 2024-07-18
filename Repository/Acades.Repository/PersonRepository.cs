using System;
using Acades.Contracts;
using Acades.Entities;
using Acades.Entities.Models;

namespace Acades.Repository
{
    public class PersonRepository(RepositoryContext repositoryContext) : RepositoryBase<Person>(repositoryContext), IPersonRepository
    {
    }
}
