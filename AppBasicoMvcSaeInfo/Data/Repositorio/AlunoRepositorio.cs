using AppBasicoMvcSaeInfo.Data.Contexto;
using AppBasicoMvcSaeInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using AppBasicoMvcSaeInfo.Data.Interface;

namespace AppBasicoMvcSaeInfo.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly MeuDbContext _context;

        public AlunoRepositorio(MeuDbContext meuDbContext)
        {
            _context = meuDbContext;
        }

        public async Task<Aluno> BuscarAlunoPorId(Guid? id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            return aluno;
        }

        public async Task Adicionar(Aluno aluno)
        {
            await _context.Set<Aluno>().AddAsync(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Aluno aluno)
        {
            _context.Set<Aluno>().Update(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(Guid id)
        {
            var aluno = this.BuscarAlunoPorId(id);
            _context.Alunos.Remove(aluno.Result);
            await _context.SaveChangesAsync();
        }

        public IIncludableQueryable<Aluno, Cidade> ObterTodosAlunosInclude()
        {
            var aluno = _context.Alunos.Include(x => x.Responsaveis).Include(x => x.Endereco.Cidade);
            return aluno;
        }
    }
}
