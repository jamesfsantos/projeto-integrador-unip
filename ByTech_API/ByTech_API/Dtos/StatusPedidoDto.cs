using ByTech_API.Models;

namespace ByTech_API.Dtos
{
    public class StatusPedidoDto
    {
        public StatusPedidoDto()
        {
            
        }
        public StatusPedidoDto(StatusPedido statusPedido)
        {
            Id = statusPedido.Id;
            StatusAtual = statusPedido.StatusAtual;
        }
        public int Id { get; set; }
        public string StatusAtual { get; set; }
    }
}
