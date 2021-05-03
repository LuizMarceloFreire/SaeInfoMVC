using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppBasicoMvcSaeInfo.Data.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppBasicoMvcSaeInfo.Controllers
{
    public class AlunosPorCidadeController : Controller
    {
        private readonly MeuDbContext _context;

        public AlunosPorCidadeController(MeuDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> BuscarCidade()
        {
            var cidades = await _context.Cidades.ToListAsync();

            return View(cidades);
        }

        public async Task<IActionResult> BuscarAlunoPorCidade(Guid? id)
        {
            if (id == null)
                return NotFound();

            var alunosLista = _context.Alunos.Include(x => x.Endereco.Cidade);

            return View(await alunosLista.Where(x => x.Endereco.Cidade.Id == id).ToListAsync());
        }
    }
}