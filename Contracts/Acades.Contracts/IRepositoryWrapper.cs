namespace Acades.Contracts
{
    public interface IRepositoryWrapper
    {
        IPersonRepository Person { get; }
        void Save();
    }
}
