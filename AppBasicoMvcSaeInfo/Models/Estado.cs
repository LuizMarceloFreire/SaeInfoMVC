using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppBasicoMvcSaeInfo.Models
{
    public class Estado : Entidade
    {
        public string Nome { get; set; }

        [StringLength(2)]
        public string Sigla { get; set; }
        public DateTime DataAlteracaoRegistro { get; set; }
        public string UsuarioAlteracaoRegistro { get; set; }

        public ICollection<Cidade> Cidades { get; set; }
    }
}