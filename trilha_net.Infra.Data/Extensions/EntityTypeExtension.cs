using trilha_net.Infra.CrossCutting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace trilha_net.Infra.Data.Extensions
{
    public static class EntityTypeExtension
    {
        public static void DefaultEntityMapping<TEntity>(this EntityTypeBuilder<TEntity> builder, string name, string? schema)
        where TEntity : Entity
        {
            builder.ToTable(name, schema);

            builder.HasIndex(e => e.CreatedAtUtc);
            builder.HasIndex(e => e.UpdatedAtUtc);            
        }
    }
}
