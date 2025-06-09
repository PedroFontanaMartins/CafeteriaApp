using CafeteriaApi.Model;
using CafeteriaApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CriarProduto([FromBody] ProdutoViewModel produto)
        {
            Produto produtoEntity = new Produto()
            {
                IdRestaurante = produto.IdRestaurante,
                Nome = produto.Nome,
                Valor = produto.Valor,
            };

            _context.Produto.Add(produtoEntity);
            await _context.SaveChangesAsync();
            return Ok(produto);
        }

        [HttpGet("{restauranteId}/listar")]
        public async Task<IActionResult> ListarProdutosRestaurante(int restauranteId)
        {
            var restaurantes = await _context.Produto.Where(x=> x.IdRestaurante == restauranteId).ToListAsync();
            return Ok(restaurantes);
        }
    }
}
