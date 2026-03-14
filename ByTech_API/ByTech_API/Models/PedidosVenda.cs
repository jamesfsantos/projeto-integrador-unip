namespace ByTech_API.Models
{
    public class PedidosVenda
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Data_Pedido { get; set; }
        public decimal Valor_Total_Pedido { get; set; }

        
    }
}
