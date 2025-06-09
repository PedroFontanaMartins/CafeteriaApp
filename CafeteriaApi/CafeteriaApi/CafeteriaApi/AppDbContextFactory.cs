using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CafeteriaApi
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Use aqui sua connection string local para o PostgreSQL
            var connectionString = "Host=shuttle.proxy.rlwy.net;Port=37395;Database=railway;Username=postgres;Password=LqRliGLdxrPZRNpiqixWqMKELUSqPxrF";

            optionsBuilder.UseNpgsql(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
