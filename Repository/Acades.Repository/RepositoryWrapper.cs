using Acades.Contracts;
using Acades.Entities;

namespace Acades.Repository
{
    public class RepositoryWrapper(RepositoryContext repositoryContext) : IRepositoryWrapper
    {
        private readonly RepositoryContext repoContext = repositoryContext;
        private IPersonRepository person;

        public IPersonRepository Person
        {
            get
            {
                person ??= new PersonRepository(repoContext);
                return person;
            }
        }

        public void Save()
        {
            repoContext.SaveChanges();
        }
    }
}
