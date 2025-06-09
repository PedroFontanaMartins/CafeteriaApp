using CafeteriaApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestauranteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RestauranteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CriarRestaurante([FromBody] Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            await _context.SaveChangesAsync();
            return Ok(restaurante);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarRestaurantes()
        {
            var restaurantes = await _context.Restaurantes.ToListAsync();
            return Ok(restaurantes);
        }
    }
}
