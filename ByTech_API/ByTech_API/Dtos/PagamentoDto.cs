using ByTech_API.Enums;
using ByTech_API.Models;

namespace ByTech_API.Dtos
{
    public class PagamentoDto
    {
        public PagamentoDto()
        {
            
        }

        public PagamentoDto(Pagamento pagamento)
        {
            Id = pagamento.Id;
            PedidoId = pagamento.PedidoId;
            Metodo = pagamento.Metodo;
            Status = pagamento.Status;
            DataConfirmacao = pagamento.DataConfirmacao;
        }

        public int Id { get; set; }
        public int PedidoId { get; set; }
        public string Metodo { get; set; }
        public string Status { get; set; }
        public DateTime? DataConfirmacao { get; set; }
    }
}
