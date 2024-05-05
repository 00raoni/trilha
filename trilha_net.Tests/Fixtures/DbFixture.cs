using Microsoft.EntityFrameworkCore;
using trilha_net.Infra.Data.Context;

namespace trilha_net.Tests.Fixtures
{
    public class DbFixture:IDisposable
    {
        private readonly ProjetoContext _context;
        public readonly string DataBaseName = $"context_{Guid.NewGuid()}";
        public readonly string ConnectionString;
        private bool _disposed;

        public DbFixture()
        {
            ConnectionString = $"Server=(localdb)\\MSSQLLocalDB;Database={DataBaseName};Trusted_Connection=True;MultipleActiveResultSets=true";
            var builder = new DbContextOptionsBuilder<ProjetoContext>();
            builder.UseSqlServer(ConnectionString);

            _context = new ProjetoContext(builder.Options);
            _context.Database.Migrate();
        }
        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if (disposing)
                {
                    _context.Database.EnsureDeleted();                 
                }
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
