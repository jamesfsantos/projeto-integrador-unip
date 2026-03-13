namespace ByTech_API.Models
{
    public class PedidoVenda
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotalPedido { get; set; }
    }
}
