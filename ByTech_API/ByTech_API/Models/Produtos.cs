namespace ByTech_API.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public decimal Preco_Venda { get; set; }
        public int Estoque_Atual { get; set; }
        public string Marca { get; set; }

    }
}
