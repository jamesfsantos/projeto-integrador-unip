using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using ByTech_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ByTech_API.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly AppDbContext _context;
        public PagamentoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagamentoDto> GerarPagamento(PagamentoDto pagamentoDto)
        {

            var pagamento = new Pagamento
            {
                Id = pagamentoDto.Id,
                DataConfirmacao = DateTime.Now,
                Metodo = pagamentoDto.Metodo,
                PedidoId = pagamentoDto.PedidoId,
                Status = pagamentoDto.Status,
            };

            if (pagamento == null)
                return null;
        
            _context.Pagamentos.Add(pagamento);
            await _context.SaveChangesAsync();

            return pagamentoDto;
            
        }

        public async Task<PagamentoDto> ObterPagamentoId(int id)
        {
            var pagamento = await _context.Pagamentos.FindAsync(id);

            if (pagamento == null)
                return null;

            return new PagamentoDto
            {
                Id = pagamento.Id,
                PedidoId = pagamento.PedidoId,
                DataConfirmacao = pagamento.DataConfirmacao,
                Metodo = pagamento.Metodo,
                Status = pagamento.Status
            };
        }

        public async Task<IEnumerable<PagamentoDto>> ObterTodos()
        {
            var pagamentos = await _context.Pagamentos.ToListAsync();

            if (pagamentos == null || !pagamentos.Any())
                return null;

            return pagamentos.Select(pagamento => new PagamentoDto(pagamento));
        }   
    }
}
