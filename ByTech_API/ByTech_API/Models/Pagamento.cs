using ByTech_API.Enums;

namespace ByTech_API.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public string Metodo { get; set; }
        public string Status { get; set; }
        public DateTime? DataConfirmacao { get; set; }
        public Pedido Pedido { get; set; }
        
    }
}
