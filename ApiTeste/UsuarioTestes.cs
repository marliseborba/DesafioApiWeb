using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UsuarioApi;

namespace ApiTeste
{
    [TestClass]
    public class UsuarioTestes
    {
        private readonly UsuarioContext _context;
        [TestMethod]
        public void GetUsuario_Quantidade()
        {
            Usuario usuario = new Usuario();
            _context.Usuarios.Add(usuario);

            Assert.AreEqual(_context.Usuarios.GetUsuario.Count, 1) ;
        }
    }
}
