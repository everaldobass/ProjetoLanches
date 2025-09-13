using Microsoft.EntityFrameworkCore;
using ProjetoLanches.Models;

namespace ProjetoLanches.Context
{
    public class ApplicationDbContext : DbContext
    {
        //Define as classe para criar as tabelas
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        { 
        
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }


    }
}
