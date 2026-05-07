using ByTech_API.Dtos;

namespace ByTech_API.Contracts.Services
{
    public interface IPagamentoService
    {
        Task<IEnumerable<PagamentoDto>> ObterTodos();
        Task<PagamentoDto> ObterPagamentoId(int id);
        Task<PagamentoDto> GerarPagamento(PagamentoDto pagamento);
    }
}
