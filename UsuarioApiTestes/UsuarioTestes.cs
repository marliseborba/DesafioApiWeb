using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using UsuarioApi.Models;

namespace UsuarioApiTestes
{
    [TestClass]
    public class UsuarioTestes
    {
        private readonly TesteContext _context;
        [TestMethod]
        public void GetUsuario_Quantidade()
        {
            Usuario usuario = new Usuario();
            usuario.Nome = "Marlise";
            usuario.Login = "Liz";
            usuario.Login = "1";
            usuario.Senha = "abc";

            _context.Usuarios.Add(usuario);

            Assert.AreEqual(_context.Usuarios.Count(), 1);
        }
    }
}
