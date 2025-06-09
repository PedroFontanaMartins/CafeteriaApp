using CafeteriaApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] Usuario usuario)
        {
            try
            {
                if (await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email))
                    return BadRequest("E-mail já cadastrado.");

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return Ok("Usuário cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao cadastrar usuário: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u =>
                u.Email == usuario.Email && u.Senha == usuario.Senha);

            if (user == null)
                return Unauthorized("Credenciais inválidas.");

            return Ok(new
            {
                Id = user.Id,
                Mensagem = "Login bem-sucedido."
            });
        }
    }
}

