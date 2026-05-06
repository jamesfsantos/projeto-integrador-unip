using ByTech_API.Models;

namespace ByTech_API.Dtos
{
    public class PedidoDto
    {
        public PedidoDto()
        {
            Itens = new List<ItemPedidoDto>();
        }
        public PedidoDto(Pedido pedido)
        {
            Id = pedido.Id;
            UsuarioId = pedido.UsuarioId;
            DataPedido = pedido.DataPedido;
            ValorTotalPedido = pedido.ValorTotalPedido;
            NomeUsuario = pedido.NomeUsuario;
            Email = pedido.Email;
            Celular = pedido.Celular;
            Cpf = pedido.Cpf;
            Endereco = pedido.Endereco;
            Complemento = pedido.Complemento;
            Cidade = pedido.Cidade;
            Cep = pedido.Cep;
            StatusPedidoId = pedido.StatusPedidoId;
            StatusPedido = new StatusPedidoDto
            {
                Id = pedido.StatusPedido.Id,
                StatusAtual = pedido.StatusPedido.StatusAtual
            };
            if(pedido.ItensPedidos != null)
            {
                Itens = pedido.ItensPedidos.Select(x => new ItemPedidoDto 
                { 
                    Id = x.Id,
                    Nome = x.Nome,
                    Quantidade = x.Quantidade,
                    Valor = x.Valor,
                    ValorTotal = x.ValorTotal,
                    ProdutoId = x.ProdutoId
                }).ToList();
            }
        }

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
        public StatusPedidoDto? StatusPedido { get; set; }
        public List<ItemPedidoDto> Itens { get; set; } 
        
    }
}
