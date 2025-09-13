using ProjetoLanches.Context;
using ProjetoLanches.Models;
using ProjetoLanches.Repositories.Interfaces;

namespace ProjetoLanches.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        // Instaciar o banco de dados
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retorna todos os campos da tabela categorias
        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
