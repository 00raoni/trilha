using Microsoft.EntityFrameworkCore;

namespace trilha_net.Infra.Data.Extensions
{
    public static class ModelBuilderExtension
    {        
        public static ModelBuilder SetStringToNotUnicode(this ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                            .SelectMany(t => t.GetProperties())
                            .Where(
                                   p => p.ClrType == typeof(string)    // Entity is a string
                            ))
            {
                property.SetIsUnicode(false);
            }

            return modelBuilder;
        }
    }
}
