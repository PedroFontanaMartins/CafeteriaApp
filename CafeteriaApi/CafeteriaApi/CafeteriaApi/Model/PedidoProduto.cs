using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CafeteriaApi.Model
{
    public class PedidoProduto
    {
        public int Id { get; set; }

        [ForeignKey("IdProduto")]
        [JsonIgnore]
        public Produto Produto { get; set; }
        public int IdProduto { get; set; }

        [ForeignKey("IdPedido")]
        [JsonIgnore]
        public Pedido Pedido { get; set; }
        public int IdPedido { get; set; }
    }
}
