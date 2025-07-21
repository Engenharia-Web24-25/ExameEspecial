using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EW_Exame.Data;
using EW_Exame.Models;

namespace EW_Exame.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var produtos = await _context.Produtos
                .Include(p => p.Categoria)
                .ToListAsync();

            return View(produtos);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,CategoriaId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                
                produto.Username = User.Identity?.Name ?? "UtilizadorDesconhecido";

                _context.Add(produto);
                await _context.SaveChangesAsync();

                
                TempData["Mensagem"] = "Produto inserido com sucesso!";

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            return View(produto);
        }
    }
}
