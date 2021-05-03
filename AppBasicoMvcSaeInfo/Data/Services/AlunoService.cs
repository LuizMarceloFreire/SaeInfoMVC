using AppBasicoMvcSaeInfo.Data.Contexto;
using AppBasicoMvcSaeInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBasicoMvcSaeInfo.Data.Services
{
    public class AlunoService
    {
        public IOrderedQueryable<Aluno> OrdernarGrid(string sortOrder, IOrderedQueryable<Aluno> aluno)
        {
            switch (sortOrder)
            {
                case "nomeDesc":
                    aluno = aluno.OrderByDescending(x => x.Nome);
                    break;
                case "cpfDesc":
                    aluno = aluno.OrderByDescending(x => x.Cpf);
                    break;
                case "dataDesc":
                    aluno = aluno.OrderByDescending(x => x.DataCadastro);
                    break;
                case "dataCadastro":
                    aluno = aluno.OrderBy(x => x.DataCadastro);
                    break;
                case "sexoDesc":
                    aluno = aluno.OrderByDescending(x => x.Sexo);
                    break;
                case "cidadeDesc":
                    aluno = aluno.OrderByDescending(x => x.Endereco.Cidade.Nome);
                    break;
            }

            return aluno;
        }
    }
}
