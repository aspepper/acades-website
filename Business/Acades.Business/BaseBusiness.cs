using Acades.Entities;

namespace Acades.Business
{
    public abstract class BaseBusiness
    {
        protected readonly RepositoryContext context;

        protected BaseBusiness(RepositoryContext context)
        {
            this.context = context;
        }
    }
}
