using CafeteriaApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaApi
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
