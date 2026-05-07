using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using ByTech_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ByTech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        private readonly AppDbContext _context;
        public ProdutoController(AppDbContext context, IProdutoService service)
        {
            _service = service;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProduto([FromBody] ProdutoDto produtoDto)
        {
            var produto = await _service.AdicionarProduto(produtoDto);

            if (produto == null) return BadRequest();

            return Ok(produto);
        }


        [HttpGet]
        public async Task<IActionResult> ObterProdutos() 
        {
            var produtos = await _service.ObterTodosAsync();
            if(produtos == null)
                return NotFound();
            return Ok(produtos);
        }

        [HttpGet("/api/produto/categoria/{categoriaId}")]
        public async Task<IActionResult> ObterProdutoIdCategoria(int categoriaId)
        {
            var produto = await _service.ObterPorIdCategoria(categoriaId);
            if (produto == null)
                return NotFound();
            return Ok(produto);
        }

        [HttpGet("/api/produto/{id}")]
        public async Task<IActionResult> ObterProdutoId(int id)
        {
            var produto = await _service.ObterPorId(id);
            if(produto == null) return NotFound();
            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, [FromBody] ProdutoDto produtoDto)
        {
            var produto = await _service.AtualizarProduto(id, produtoDto);

            if(produto == null)
            {
                return NotFound($"Produto com id: {id} não foi encontrado!");
            }



            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarProduto(int id)
        {
            var produto = await _service.DeletarProduto(id);

            if (produto == null)
            {
                return NotFound($"Não existe um produto com o id: {id}");
            }

            return Ok(produto);
        }
    }
}
