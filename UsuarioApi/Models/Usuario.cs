using System.ComponentModel.DataAnnotations;

namespace UsuarioApi.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Login { get; set; }
        public string Matricula { get; set; }
        [Required]
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        public Usuario (long id, string nome, string login, string matricula, string senha, bool ativo, string email)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Matricula = matricula;
            Senha = senha;
            Ativo = ativo;
            Email = email;
        }
    }
}
