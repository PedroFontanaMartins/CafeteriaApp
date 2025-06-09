using System.Text.Json.Serialization;

namespace CafeteriaApi.Model
{
    public class Restaurante
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Foto { get; set; }
        public string? Endereco { get; set; }
        public decimal? Avaliacao { get; set; }
    }
}
