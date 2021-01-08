using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CasaBoxAPI
{
    public class CasaBoxContextFactory : IDesignTimeDbContextFactory<CasaBoxContext>
    {
        public CasaBoxContextFactory()
        {
        }

        public CasaBoxContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CasaBoxContext>();
            var connectionString = "Server=tcp:casaboxsqlserver.database.windows.net,1433;Initial Catalog=casabox-db;Persist Security Info=False;User ID=sqlserver;Password=xr7cdWFT4psNeza5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            builder.UseSqlServer(connectionString);
            builder.UseLazyLoadingProxies();
            builder.EnableSensitiveDataLogging(true);

            return new CasaBoxContext(builder.Options);
        }
    }
}
