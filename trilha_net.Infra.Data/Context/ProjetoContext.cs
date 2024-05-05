using trilha_net.Domain.Models;
using trilha_net.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace trilha_net.Infra.Data.Context
{

    public class ProjetoContext : DbContext
    {
        public ProjetoContext(DbContextOptions<ProjetoContext> options)
           : base(options)
        {            
        }

        public ProjetoContext()
        {

        }
        public DbSet<Usuario> Usuario { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjetoContext).Assembly);

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;          

            base.OnModelCreating(modelBuilder);

            modelBuilder.SetStringToNotUnicode();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            OnBeforeSaving();

            int affectedRows = await base.SaveChangesAsync(cancellationToken);

            return affectedRows;
        }
        private void OnBeforeSaving()
        {
            CreateDateRewrite();

            this.AutoTruncateStringToMaxLength();
        }
        private void CreateDateRewrite()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.CurrentValues["CreatedAtUtc"] = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.CurrentValues["UpdatedAtUtc"] = DateTime.UtcNow;
                }
            }
        }
    }
}

