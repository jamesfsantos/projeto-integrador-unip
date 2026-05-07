using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using ByTech_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ByTech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPagamentoService _service;

        public PagamentoController(AppDbContext context, IPagamentoService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPagamentos()
        {
            var pagamentos = await _service.ObterTodos();
            if (pagamentos == null)
                return NotFound();
            return Ok(pagamentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPagamentosId(int id)
        {
            var pagamento = await _service.ObterPagamentoId(id);

            if(pagamento == null)
                return NotFound("Pagamento não encontrado!");

            return Ok(pagamento);
        }

        [HttpPost]
        public async Task<IActionResult> RealizarPagamento(PagamentoDto pagamentoDto)
        {
            var pagamento = await _service.GerarPagamento(pagamentoDto);
            if (pagamento == null)
                return BadRequest();

            return Ok(pagamento);
        }

        
    }
}
