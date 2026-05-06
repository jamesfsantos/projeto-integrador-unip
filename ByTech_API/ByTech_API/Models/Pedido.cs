using System.Reflection.Metadata.Ecma335;

namespace ByTech_API.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotalPedido { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public int StatusPedidoId { get; set; }

        public StatusPedido StatusPedido { get; set; }

        public virtual ICollection<ItemPedido> ItensPedidos { get; set; }

        public Usuario Usuario {  get; set; }
    }
}
