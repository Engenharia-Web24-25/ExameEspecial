using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EW_Exame.Models;

namespace EW_Exame.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EW_Exame.Models.Categoria> Categorias { get; set; } = default!;
        public DbSet<EW_Exame.Models.Produto> Produtos { get; set; } = default!;
    }
}
