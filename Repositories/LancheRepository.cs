using Microsoft.EntityFrameworkCore;
using ProjetoLanches.Context;
using ProjetoLanches.Models;
using ProjetoLanches.Repositories.Interfaces;

namespace ProjetoLanches.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        // Instanciar o banco de dados
        private readonly ApplicationDbContext _context;

        //Método construtor
        public LancheRepository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        // Retorna todos os lanches e suas categorias
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

        // Retorna os lanches com uma condição
        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.
            Where(l => l.IsLanchePreferido ).
            Include(c => c.Categoria);// Vai incluir as categorias dos lanches
       //Obtenho lum lancho especifico pelo link
        public Lanche GetLancheById(int LancheId)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == LancheId);
        }
    }
}
