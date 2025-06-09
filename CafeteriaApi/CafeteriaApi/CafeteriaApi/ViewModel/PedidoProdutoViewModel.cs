using CafeteriaApi.Model;
using System.Text.Json.Serialization;

namespace CafeteriaApi.ViewModel
{
    public class PedidoProdutoViewModel
    {
        public int IdRestaurante { get; set; }

        public List<ProdutoPedidoViewModel> Produtos { get; set; }
    }

    public class ProdutoPedidoViewModel
    {
        public int IdProduto { get; set; }
    }
}
