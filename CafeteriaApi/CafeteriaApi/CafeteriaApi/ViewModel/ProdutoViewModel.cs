using CafeteriaApi.Model;
using System.Text.Json.Serialization;

namespace CafeteriaApi.ViewModel
{
    public class ProdutoViewModel
    {
        public string Nome { get; set; }

        public decimal Valor { get; set; }

        public int IdRestaurante { get; set; }
    }
}
