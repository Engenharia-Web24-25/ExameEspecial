using EW_Exame.Models;

namespace EW_Exame.Data
{
    public class DbInitializer
    {
        private ApplicationDbContext _context;

        public DbInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Run()
        {
            _context.Database.EnsureCreated();

            if (_context.Categorias.Any())
            {
                return;
            }

            var categorias = new Categoria[]
            {
                new Categoria { Nome = "Informática" },
                new Categoria { Nome = "Livros" },
                new Categoria { Nome = "Escritório" }
            };

            _context.Categorias.AddRange(categorias);

            var produtos = new Produto[]
            {
                new Produto { Nome = "PC", Descricao = "Computador Pessoal - Core i9 - 32GRam - 1T SSD" , Categoria = categorias.Single(c => c.Nome == "Informática")},
                new Produto { Nome = "Impressora", Descricao = "HP Laserjet full color" , Categoria = categorias.Single(c => c.Nome == "Informática")},
                new Produto { Nome = "Secretária", Descricao = "Secretária pessoal c/ bloco de gavetas" , Categoria = categorias.Single(c => c.Nome == "Escritório") }
            };

            _context.Produtos.AddRange(produtos);

            _context.SaveChanges();
        }
    }
}
