using AppBasicoMvcSaeInfo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppBasicoMvcSaeInfo.Models
{
    public class Aluno : Entidade
    {
        public Aluno()
        {
            DataCadastro = DateTime.Now;
        }

        [Required(ErrorMessage ="O campo é obrigatório.")]
        [StringLength(30)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo é obrigatório.")]
        [Display(Name = "RG")]
        public string Rg { get; set; }
        
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        
        [Required(ErrorMessage = "O campo é obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data em formato incorreto.")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataDeNascimento { get; set; }
        
        [Required(ErrorMessage = "O campo é obrigatório.")]
        [Display(Name = "Matricula")]
        public int Matricula { get; set; }
        
        [Display(Name = "Idade")]
        public int Idade { get; set; }
        
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Data em formato incorreto.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O campo é obrigatório.")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }

        public Endereco Endereco { get; set; }
        public DateTime DataAlteracaoRegistro { get; set; }
        public string UsuarioAlteracaoRegistro { get; set; }

        public Responsavel Responsaveis { get; set; }
    }
}
