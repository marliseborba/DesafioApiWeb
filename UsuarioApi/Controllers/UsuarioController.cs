using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsuarioApi.Models;
using X.PagedList;

namespace UsuarioApi.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioContext _context;

        public UsuarioController(UsuarioContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuario/paginacao
        [HttpGet("paginacao")]
        public Task<IPagedList<Usuario>> Paginacao([FromQuery]int? pagina, [FromQuery]int? quantidade)
        {
            int itensPorPagina = (quantidade ?? 5);
            int numPagina = (pagina ?? 1);
            return _context.Usuarios.ToPagedListAsync(numPagina, itensPorPagina);
        }

        // GET: api/Usuario/
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuario/
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> PutUsuario(long id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }
            if (ValidaLoginUnico(usuario.Login, usuario.Id))
                throw new Exception("Este login já está em uso");
            if (ValidaEmailUnico(usuario.Email, usuario.Id))
                throw new Exception("Este e-mail já está em uso");
            var hash = new Hash(SHA512.Create());
            usuario.Senha = hash.CriptografarSenha(usuario.Senha);
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return usuario;
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            if (ValidaLoginUnico(usuario.Login, usuario.Id))
                throw new Exception("Este login já está em uso");
            if (ValidaEmailUnico(usuario.Email, usuario.Id))
                throw new Exception("Este e-mail já está em uso");
            var hash = new Hash(SHA512.Create());
            usuario.Senha = hash.CriptografarSenha(usuario.Senha);
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuario/
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(long id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

        public bool ValidaLoginUnico(string login, long id)
        {
            return _context.Usuarios.Where(u => u.Id != id && u.Login == login).Any();
        }

        public bool ValidaEmailUnico(string email, long id)
        {
            return _context.Usuarios.Where(u => u.Id != id && u.Email == email).Any();
        }

    }
}
