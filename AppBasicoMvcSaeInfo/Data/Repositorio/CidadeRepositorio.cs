using AppBasicoMvcSaeInfo.Data.Contexto;
using AppBasicoMvcSaeInfo.Data.Interface;
using AppBasicoMvcSaeInfo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBasicoMvcSaeInfo.Data.Repositorio
{
    public class CidadeRepositorio : ICidadeRepositorio
    {
        private readonly MeuDbContext _context;

        public CidadeRepositorio(MeuDbContext meuDbContext)
        {
            _context = meuDbContext;
        }

        public async Task<Cidade> BuscarAlunoPorId(Guid? id)
        {
            var cidade = await _context.Cidades.FindAsync(id);
            return cidade;
        }

        public async Task Adicionar(Cidade cidade)
        {
            await _context.Set<Cidade>().AddAsync(cidade);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Cidade cidade)
        {
            _context.Set<Cidade>().Update(cidade);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(Guid id)
        {
            var cidade = this.BuscarAlunoPorId(id);
            _context.Cidades.Remove(cidade.Result);
            await _context.SaveChangesAsync();
        }
        public IIncludableQueryable<Cidade, Estado> ObterTodosAlunosInclude()
        {
            var cidades = _context.Cidades.Include(x => x.Estado);
            return cidades;
        }
    }
}
