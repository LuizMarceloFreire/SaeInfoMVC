using System;
using System.ComponentModel.DataAnnotations;

namespace AppBasicoMvcSaeInfo.Models
{
    public class Endereco : Entidade
    {
        [Required(ErrorMessage = "O campo é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        public int Numero { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        public Cidade Cidade { get; set; }
        public DateTime DataAlteracaoRegistro { get; set; }
        public string UsuarioAlteracaoRegistro { get; set; }
    }
}