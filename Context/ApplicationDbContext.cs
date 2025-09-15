using Microsoft.EntityFrameworkCore;
using ProjetoLanches.Models;

// Define o namespace onde está o contexto do banco de dados da aplicação
namespace ProjetoLanches.Context
{
    // Classe que representa o contexto do banco de dados, herdando de DbContext do Entity Framework
    public class ApplicationDbContext : DbContext
    {

        // Construtor da classe que recebe as opções de configuração do contexto via injeção de dependência
        // Essas opções geralmente incluem a string de conexão e outras configurações do EF
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // O corpo do construtor está vazio, pois a configuração é passada diretamente para a classe base
        }


        // Define uma tabela chamada "Categorias" no banco de dados, baseada na classe Categoria
        public DbSet<Categoria> Categorias { get; set; }

        // Define uma tabela chamada "Lanches" no banco de dados, baseada na classe Lanche
        public DbSet<Lanche> Lanches { get; set; }


        // Define uma tabela chamada "CarrinhoCompraItens" no banco de dados, baseada na classe CarrinhoCompraItem
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
    }
}
