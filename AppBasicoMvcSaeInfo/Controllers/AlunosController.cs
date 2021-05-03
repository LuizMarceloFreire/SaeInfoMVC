using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppBasicoMvcSaeInfo.Data.Contexto;
using AppBasicoMvcSaeInfo.Models;
using AppBasicoMvcSaeInfo.Data.Interface;
using AppBasicoMvcSaeInfo.Data.Services;
using AppBasicoMvcSaeInfo.Data.Repositorio;
using ReflectionIT.Mvc.Paging;

namespace AppBasicoMvcSaeInfo.Controllers
{
    public class AlunosController : Controller
    {
        private readonly MeuDbContext _context;
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly AlunoService _alunoService;

        public AlunosController(MeuDbContext meuDbContext)
        {
            _context = meuDbContext;
            _alunoRepositorio = new AlunoRepositorio(_context);
            _alunoService = new AlunoService();
        }

        public async Task<IActionResult> Index(string sortOrder, int page = 1)
        {
            var alunos = _alunoRepositorio.ObterTodosAlunosInclude().AsNoTracking().OrderBy(x => x.Nome);
            alunos = OrdernarGrid(sortOrder, alunos);
            var model = await PagingList.CreateAsync(alunos, 10, page);

            return View(model);
        }

        public async Task<IActionResult> Detalhes(Guid? id)
        {
            if (id == null)
                return NotFound();

            var aluno = await _context.Alunos.Include(x => x.Endereco).FirstOrDefaultAsync(x => x.Id == id);

            if (aluno == null)
                return NotFound();

            return View(aluno);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                await _alunoRepositorio.Adicionar(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        public async Task<IActionResult> Editar(Guid? id)
        {
            if (id == null)
                return NotFound();

            var aluno = await _context.Alunos.Include(x => x.Responsaveis) .Include(x => x.Endereco).FirstOrDefaultAsync(f => f.Id == id);

            if (aluno == null)
                return NotFound();

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Guid id, Aluno aluno)
        {
            if (id != aluno.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _alunoRepositorio.Atualizar(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        public async Task<IActionResult> Deletar(Guid? id)
        {
            if (id == null)
                return NotFound();

            var aluno = await _context.Alunos.Include(x => x.Endereco).FirstOrDefaultAsync(f => f.Id == id);

            if (aluno == null)
                return NotFound();

            return View(aluno);
        }

        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmaDelete(Guid id)
        {
            await _alunoRepositorio.Remover(id);
            return RedirectToAction("Index");
        }

        public IOrderedQueryable<Aluno> OrdernarGrid(string sortOrder, IOrderedQueryable<Aluno> aluno)
        {
            ViewData["OrdenarNome"] = string.IsNullOrEmpty(sortOrder) ? "nomeDesc" : "";
            ViewData["OrdenarCpf"] = string.IsNullOrEmpty(sortOrder) ? "cpfDesc" : "";
            ViewData["OrdenarDataCadastro"] = sortOrder == "dataCadastro" ? "dataDesc" : "dataCadastro";
            ViewData["OrdenarSexo"] = string.IsNullOrEmpty(sortOrder) ? "sexoDesc" : "";
            ViewData["OrdenarCidade"] = string.IsNullOrEmpty(sortOrder) ? "cidadeDesc" : "";

            aluno = _alunoService.OrdernarGrid(sortOrder, aluno);
            return aluno;
        }
    }
}
