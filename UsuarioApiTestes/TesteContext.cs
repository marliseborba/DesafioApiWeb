using Microsoft.AspNetCore.Mvc;

namespace UsuarioApiTestes
{
    class TesteContext : ControllerBase
    {
        private readonly TesteContext _context;

        public TesteContext (TesteContext context)
        {
            _context = context;
        }
    }
}
