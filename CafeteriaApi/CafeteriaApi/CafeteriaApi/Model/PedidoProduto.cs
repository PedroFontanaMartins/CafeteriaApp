using System.Text.Json.Serialization;

namespace CafeteriaApi.Model
{
    public class PedidoProduto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public Produto Produto { get; set; }
        public int IdProduto { get; set; }
    }
}
