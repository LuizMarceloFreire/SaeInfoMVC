using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppBasicoMvcSaeInfo.Data.Contexto;
using AppBasicoMvcSaeInfo.Models;
using AppBasicoMvcSaeInfo.Data.Interface;
using AppBasicoMvcSaeInfo.Data.Repositorio;
using ReflectionIT.Mvc.Paging;
using AppBasicoMvcSaeInfo.Data.Services;

namespace AppBasicoMvcSaeInfo.Controllers
{
    public class CidadesController : Controller
    {
        private readonly MeuDbContext _context;
        private readonly ICidadeRepositorio _cidadeRepositorio;
        private readonly CidadeService _cidadeService;

        public CidadesController(MeuDbContext context)
        {
            _context = context;
            _cidadeRepositorio = new CidadeRepositorio(_context);
            _cidadeService = new CidadeService();
        }

        public async Task<IActionResult> Index(string sortOrder, int page = 1)
        {
            var cidades = _cidadeRepositorio.ObterTodosAlunosInclude().AsNoTracking().OrderBy(x => x.Nome);
            cidades = OrdernarGrid(sortOrder, cidades);
            var model = await PagingList.CreateAsync(cidades, 5, page);

            return View(model);
        }

        public async Task<IActionResult> Detalhes(Guid? id)
        {
            if (id == null)
                return NotFound();

            var cidade = await _context.Cidades.Include(x => x.Estado).FirstOrDefaultAsync(x => x.Id == id);

            if (cidade == null)
                return NotFound();

            return View(cidade);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                await _cidadeRepositorio.Adicionar(cidade);
                return RedirectToAction(nameof(Index));
            }
            return View(cidade);
        }

        public async Task<IActionResult> Editar(Guid? id)
        {
            if (id == null)
                return NotFound();

            var cidade = await _context.Cidades.Include(x => x.Estado).FirstOrDefaultAsync(x => x.Id == id);

            if (cidade == null)
                return NotFound();

            return View(cidade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Guid id, Cidade cidade)
        {
            if (id != cidade.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _cidadeRepositorio.Atualizar(cidade);
                return RedirectToAction("Index");
            }
            return View(cidade);
        }

        public async Task<IActionResult> Deletar(Guid? id)
        {
            if (id == null)
               return NotFound();

            var cidade = await _context.Cidades.Include(x => x.Estado).FirstOrDefaultAsync(m => m.Id == id);

            if (cidade == null)
                return NotFound();

            return View(cidade);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmaDelete(Guid id)
        {
            await _cidadeRepositorio.Remover(id);
            return RedirectToAction("Index");
        }

        public IOrderedQueryable<Cidade> OrdernarGrid(string sortOrder, IOrderedQueryable<Cidade> cidade)
        {
            ViewData["OrdenarCidade"] = string.IsNullOrEmpty(sortOrder) ? "cidadeDesc" : "";
            ViewData["OrdenarEstado"] = string.IsNullOrEmpty(sortOrder) ? "estadoDesc" : "";

            cidade = _cidadeService.OrdernarGrid(sortOrder, cidade);
            return cidade;
        }
    }
}
