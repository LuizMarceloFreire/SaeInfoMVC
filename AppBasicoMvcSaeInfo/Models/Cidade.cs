using AppBasicoMvcSaeInfo.Models;
using System;

namespace AppBasicoMvcSaeInfo.Models
{
    public class Cidade : Entidade
    {
        public string Nome { get; set; }
        public DateTime DataAlteracaoRegistro { get; set; }
        public string UsuarioAlteracaoRegistro { get; set; }
        public Estado Estado { get; set; }
    }
}