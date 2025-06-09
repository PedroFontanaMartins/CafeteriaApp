using CafeteriaApi.Model;

namespace CafeteriaApi.ViewModel
{
    public class PedidoListViewModel
    {
        public decimal ValorTotal { get; set; }
        public string Status { get; set; }
        public DateTime DataPedido { get; set; }


        public List<string> Produtos { get; set; }
    }
}
