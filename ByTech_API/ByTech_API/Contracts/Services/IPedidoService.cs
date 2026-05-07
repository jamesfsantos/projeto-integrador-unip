using ByTech_API.Dtos;

namespace ByTech_API.Contracts.Services
{
    public interface IPedidoService 
    {
        Task<IEnumerable<PedidoDto>> ObterTodosPedidos();
        Task<PedidoDto> ObterPedidoId(int id);
        Task<PedidoDto> AdicionarPedido(PedidoDto pedido);
        Task<IEnumerable<PedidoDto>> ObterTodosPedidosEmail(string email);
        Task<bool> AlterarStatusPedido(int id, int status);
        Task<bool> ExcluirPedido(int id);        
    }
}
