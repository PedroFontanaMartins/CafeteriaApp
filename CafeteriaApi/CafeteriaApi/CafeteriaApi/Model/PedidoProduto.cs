using System.Text.Json.Serialization;

namespace CafeteriaApi.Model
{
    public class PedidoProduto
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonIgnore]
        public Produto Produto { get; set; }
        public int IdProduto { get; set; }
    }
}
