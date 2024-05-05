namespace trilha_net.Infra.CrossCutting.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync();
    }
}
