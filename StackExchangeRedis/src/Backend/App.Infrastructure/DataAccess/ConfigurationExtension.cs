using App.Domain.Enums;
using Microsoft.Extensions.Configuration;

namespace App.Infrastructure.Extensions
{
    public static class ConfigurationExtension
    {
        public static bool IsUnitTestEnvironment(this IConfiguration configuration)
        {
            return configuration.GetValue<bool>("InMemoryTest");
           
        }

        public static DatabaseType DatabaseType(this IConfiguration configuration)
        {
            var databaseType = configuration.GetConnectionString("DatabaseType");

            return (DatabaseType)Enum.Parse(typeof(DatabaseType), databaseType!);
        }

        public static string ConnectionString(this IConfiguration configuration)
        {
            var databaseType = configuration.DatabaseType();

            if (databaseType == App.Domain.Enums.DatabaseType.SQLServer)
            {
                return configuration.GetConnectionString("ConnectionSQLServer")!;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
