using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UsuarioApi.Domain;
using UsuarioApi.Models;
using System;
using System.Linq;

namespace UsuarioApi.Service
{
    public class UsuarioService
    {
        private readonly UsuarioContext _context;

        public UsuarioService(UsuarioContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<ActionResult<Usuario>> GetUsuario(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            return usuario;
        }
        public Usuario PostUsuario(Usuario usuario)
        {
            if (ValidaLoginUnico(usuario.Login))
                throw new Exception("Este login já está em uso");
            if (ValidaEmailUnico(usuario.Email))
                throw new Exception("Este e-mail já está em uso");
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        private bool UsuarioExists(long id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

        public bool ValidaLoginUnico(string login)
        {
            return _context.Usuarios.Where(u => u.Login == login).Any();
        }

        public bool ValidaEmailUnico(string email)
        {
            return _context.Usuarios.Where(u => u.Email == email).Any();
        }
    }
}
