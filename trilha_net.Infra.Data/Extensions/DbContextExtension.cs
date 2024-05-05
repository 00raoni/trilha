using Microsoft.EntityFrameworkCore;

namespace trilha_net.Infra.Data.Extensions
{
    public static class DbContextExtension
    {
        public static void AutoTruncateStringToMaxLength(this DbContext db)
        {
            var entries = db?.ChangeTracker?.Entries();
            if (entries == null)
            {
                return;
            }

            foreach (var entry in entries)
            {
                var propertyValues = entry.CurrentValues.Properties.Where(p => p.ClrType == typeof(string));

                foreach (var prop in propertyValues)
                {
                    var maxLength = prop.GetMaxLength();
                    if (!maxLength.HasValue)
                    {
                        continue;
                    }

                    if (entry.CurrentValues[prop.Name] != null)
                    {
                        string? stringValue = entry.CurrentValues[prop.Name]?.ToString() ?? string.Empty;
                        stringValue = TruncateString(stringValue, maxLength.Value);

                        entry.CurrentValues[prop.Name] = stringValue;
                    }
                }
            }
        }

        private static string TruncateString(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return value.Length <= maxLength ? value : value[..maxLength];
        }
    }
}
