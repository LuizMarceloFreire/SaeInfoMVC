using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppBasicoMvcSaeInfo.Models
{
    public class Responsavel : Entidade
    {
        public Responsavel()
        {
            DataCadastro = DateTime.Now;
        }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        [Display(Name = "RG")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        [StringLength(30)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        [Display(Name = "Profissão")]
        public string Profissao { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracaoRegistro { get; set; }
        public string UsuarioAlteracaoRegistro { get; set; }
    }
}