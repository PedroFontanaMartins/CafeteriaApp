using CafeteriaApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaApi
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<UsuarioRestauranteAdm> UsuarioRestaurante { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoProduto> PedidoProduto { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
