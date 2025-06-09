using CafeteriaApi.Model;
using CafeteriaApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioRestauranteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioRestauranteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{restauranteId}/getProprietarioRestaurante")]
        public async Task<IActionResult> ListarProdutosRestaurante(int restauranteId)
        {
            var usuarios = await _context.UsuarioRestaurante.Where(x => x.IdRestaurante == restauranteId).ToListAsync();
            return Ok(usuarios);
        }
    }
}
