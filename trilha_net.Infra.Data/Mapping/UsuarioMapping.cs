using trilha_net.Domain.Models;
using trilha_net.Infra.CrossCutting.Models;
using trilha_net.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace trilha_net.Infra.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.DefaultEntityMapping(Table.Usuario.Name, Table.Usuario.Schema);

            builder.Property(a => a.Nome).HasMaxLength(150);
            builder.Property(a => a.Email).HasMaxLength(200);
            builder.Property(a => a.Status);
            builder.Property(a => a.CPF).HasMaxLength(12);
            builder.Property(a => a.Login).HasMaxLength(50);
            builder.Property(a => a.Senha).HasMaxLength(30);
            builder.Property(a => a.DataNascimento);            
        }
    }
}

