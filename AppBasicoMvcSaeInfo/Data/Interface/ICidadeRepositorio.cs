using AppBasicoMvcSaeInfo.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBasicoMvcSaeInfo.Data.Interface
{
    public interface ICidadeRepositorio
    {
        public Task<Cidade> BuscarAlunoPorId(Guid? id);
        public Task Adicionar(Cidade cidade);
        public Task Atualizar(Cidade cidade);
        public Task Remover(Guid id);
        public IIncludableQueryable<Cidade, Estado> ObterTodosAlunosInclude();
    }
}
