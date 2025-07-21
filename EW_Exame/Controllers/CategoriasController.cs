using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EW_Exame.Data;
using EW_Exame.Models;

namespace EW_Exame.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            var categorias = await _context.Categorias
                .Include(c => c.Produtos) 
                .ToListAsync();

            return View(categorias);
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias
                .Include(c => c.Produtos) 
                .FirstOrDefaultAsync(m => m.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                
                bool nomeExiste = await _context.Categorias
                    .AnyAsync(c => c.Nome == categoria.Nome);

                if (nomeExiste)
                {
                    ModelState.AddModelError("Nome", "Esse nome já está em uso.");
                    return View(categoria);
                }

                _context.Add(categoria);
                await _context.SaveChangesAsync();

               
                TempData["Mensagem"] = "Categoria criada com sucesso!";

                return RedirectToAction(nameof(Index));
            }

            return View(categoria);
        }
    }
}
