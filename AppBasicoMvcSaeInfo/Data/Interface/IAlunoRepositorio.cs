using AppBasicoMvcSaeInfo.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBasicoMvcSaeInfo.Data.Interface
{
    public interface IAlunoRepositorio
    {
        public Task Adicionar(Aluno aluno);
        public Task Atualizar(Aluno aluno);
        public Task Remover(Guid id);
        public Task<Aluno> BuscarAlunoPorId(Guid? id);
        public IIncludableQueryable<Aluno, Cidade> ObterTodosAlunosInclude();        
    }
}
