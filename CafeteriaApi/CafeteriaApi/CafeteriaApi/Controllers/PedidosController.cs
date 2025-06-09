using CafeteriaApi.Model;
using CafeteriaApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] PedidoProdutoViewModel pedidoProd)
        {
            try
            {
                // Cria o pedido
                Pedido pedido = new Pedido()
                {
                    IdRestaurante = pedidoProd.IdRestaurante,
                    Status = "Em andamento",
                    IdUsuario = pedidoProd.IdUsuario,
                };

                // Adiciona o pedido e salva para gerar o ID
                _context.Pedido.Add(pedido);
                await _context.SaveChangesAsync();

                // Lista para salvar os IDs dos produtos
                var idsProdutos = pedidoProd.Produtos.Select(x => x.IdProduto).ToList();

                // Adiciona as relações PedidoProduto
                foreach (var idProduto in idsProdutos)
                {
                    PedidoProduto pp = new PedidoProduto
                    {
                        IdProduto = idProduto,
                        IdPedido = pedido.Id
                    };

                    _context.PedidoProduto.Add(pp);
                }

                await _context.SaveChangesAsync();

                // Consulta os valores reais dos produtos
                var produtosDoBanco = await _context.Produto
                    .Where(p => idsProdutos.Contains(p.Id))
                    .ToListAsync();

                decimal valorTotal = produtosDoBanco.Sum(p => p.Valor);

                // Atualiza o pedido com o valor total
                pedido.ValorTotal = valorTotal;
                _context.Pedido.Update(pedido);
                await _context.SaveChangesAsync();

                return Ok(new { pedido.Id, ValorTotal = valorTotal, Mensagem = "Pedido cadastrado com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao cadastrar pedido: {ex.Message}");
            }
        }


        [HttpGet("{pedidoId}/despachar")]
        public async Task<IActionResult> DespacharPedido(int pedidoId)
        {
            try
            {
                var pedido = await _context.Pedido.FirstOrDefaultAsync(p => p.Id == pedidoId);

                if (pedido == null)
                {
                    return NotFound("Pedido não encontrado.");
                }

                pedido.Status = "Despachado";
                await _context.SaveChangesAsync();

                return Ok(new { pedido.Id, pedido.Status, Mensagem = "Pedido despachado com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao despachar pedido: {ex.Message}");
            }
        }

        [HttpGet("{restauranteId}/listaPedidosRestaurante")]
        public async Task<IActionResult> ListPedidosRestaurante(int restauranteId)
        {
            try
            {
                var pedidos = _context.Pedido.Where(p => p.IdRestaurante == restauranteId).ToList();

                if (pedidos == null)
                {
                    return NotFound("Pedido não encontrado.");
                }

                return Ok(new { pedidos });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao despachar pedido: {ex.Message}");
            }
        }

    }
}
