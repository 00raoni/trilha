using trilha_net.Infra.CrossCutting.Interfaces;
using trilha_net.Infra.Data.Context;

namespace trilha_net.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjetoContext _context;

        public UnitOfWork(ProjetoContext context) => _context = context;

        public async Task CommitAsync() => await _context.SaveChangesAsync(default);

        public void Commit() => _context.SaveChanges();

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
