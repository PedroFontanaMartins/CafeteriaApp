using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CafeteriaApi.Model
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }

        [ForeignKey("IdRestaurante")]
        [JsonIgnore]
        public Restaurante Restaurante { get; set; }
        public int IdRestaurante { get; set; }
    }
}
