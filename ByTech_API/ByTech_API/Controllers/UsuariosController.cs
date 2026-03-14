using ByTech_API.Data;
using ByTech_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ByTech_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Usuarios>>> PostUsuario(Usuarios usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return Created(nameof(GetUsuarios), new { id = usuario.Id });
        }
    }
}
