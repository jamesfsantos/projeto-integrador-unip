namespace ByTech_API.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public int Estoque_Atual { get; set; }
        public string Marca { get; set; }

    }
}
