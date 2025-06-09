using CafeteriaApi.Model;

namespace CafeteriaApi.ViewModel
{
    public class PedidoListViewModel
    {
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public string Status { get; set; }
        public DateTime DataPedido { get; set; }


        public List<string> Produtos { get; set; }
    }
}
