using System.Text.Json.Serialization;

namespace CafeteriaApi.Model
{
    public class Pedido
    {
        public int Id { get; set; }

        public decimal ValorTotal { get; set; }

        public string Status { get; set; }

        [ForeignKey("IdRestaurante")]
        [JsonIgnore]
        public Restaurante Restaurante { get; set; }
        public int IdRestaurante { get; set; }
    }
}
