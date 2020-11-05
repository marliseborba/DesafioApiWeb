﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UsuarioApi.ViewModel
{
    public class UsuarioViewModel
    {
        public long Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Matricula { get; set; }
        [Required]
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; set; }
    }
}
