using System.Text.Json.Serialization;

namespace CafeteriaApi.Model
{
    public class UsuarioRestauranteAdm
    {
        public int Id { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }

        [JsonIgnore]
        public Restaurante Restaurante { get; set; }
        public int IdRestaurante { get; set; }  
    }
}
