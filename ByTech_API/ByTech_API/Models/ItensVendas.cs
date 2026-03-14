namespace ByTech_API.Models
{
    public class ItensVendas
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitarioPago { get; set; }

        public Produtos Produto { get; set; }
        public PedidosVenda Venda { get; set; }
    }
}
