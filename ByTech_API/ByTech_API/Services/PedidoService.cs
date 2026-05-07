using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using ByTech_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ByTech_API.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly AppDbContext _context;
        public PedidoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PedidoDto> AdicionarPedido(PedidoDto pedidoDto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == pedidoDto.Email);
            if (usuario == null) throw new Exception("Usuário não encontrado.");

            var pedido = new Pedido
            {
                UsuarioId = usuario.Id,
                NomeUsuario = pedidoDto.NomeUsuario,
                Email = pedidoDto.Email,
                Celular = pedidoDto.Celular,
                Cpf = pedidoDto.Cpf,
                DataPedido = DateTime.Now,
                ValorTotalPedido = pedidoDto.ValorTotalPedido,
                Endereco = pedidoDto.Endereco,
                Cep = pedidoDto.Cep,
                Cidade = pedidoDto.Cidade,
                Complemento = pedidoDto.Complemento,
                StatusPedidoId = 1,
                ItensPedidos = new List<ItemPedido>() // Começa vazia
            };

            foreach (var itemDto in pedidoDto.Itens)
            {

                var produto = await _context.Produtos.FindAsync(itemDto.ProdutoId);

                if (produto == null)
                    throw new Exception($"Produto com id: {itemDto.ProdutoId} não encontrado");

                if (produto.EstoqueAtual < itemDto.Quantidade)
                    throw new Exception($"Estoque insuficiente para o produto: {produto.Nome}");


                produto.EstoqueAtual -= itemDto.Quantidade;


                pedido.ItensPedidos.Add(new ItemPedido
                {
                    ProdutoId = produto.Id,
                    Nome = produto.Nome,
                    Quantidade = itemDto.Quantidade,
                    Valor = produto.PrecoVenda,
                    ValorTotal = produto.PrecoVenda * itemDto.Quantidade
                });
            }


            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return pedidoDto;
        }

        public async Task<bool> AlterarStatusPedido(int id, int idStatus)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            var status = await _context.StatusPedidos.FindAsync(idStatus);

            if (pedido == null || status == null)
                return false;
            

            pedido.StatusPedidoId = idStatus;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExcluirPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
                return false;

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return true;
        }

        public  async Task<PedidoDto> ObterPedidoId(int id)
        {
            var pedido = await _context.Pedidos.Include(p => p.ItensPedidos)
                                                 .Include(p => p.StatusPedido)
                                                 .FirstOrDefaultAsync(p => p.Id == id);
            if (pedido == null)
                return null;

            return new PedidoDto(pedido);
        }

        public async Task<IEnumerable<PedidoDto>> ObterTodosPedidos()
        {
            var pedidos = await _context.Pedidos.Include(p => p.ItensPedidos).Include(p => p.StatusPedido).ToListAsync();

            if (pedidos == null || !pedidos.Any())
                return null;

            return pedidos.Select(pedido => new PedidoDto(pedido));
        }

        public async Task<IEnumerable<PedidoDto>> ObterTodosPedidosEmail(string email)
        {
            var pedidos = await _context.Pedidos.Include(p => p.ItensPedidos)
                                                .Include(p => p.StatusPedido)
                                                .Where(x => x.Email == email).ToListAsync();

            if (pedidos == null)
                return null;

            return pedidos.Select(pedido => new PedidoDto(pedido));
        }
    }
}
