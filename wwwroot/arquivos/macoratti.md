# ASP.NET Core - Identity - I

### Cria o projeto com banco de dados sqlite

- dotnet new mvc -au Individual -o autenticacao
- ASP .NET Core MVC

### Bibliotecas Utilizadas no projeto

link: ttps://www.nuget.org/
link: https://www.connectionstrings.com/

### Pacotes Nuget SqlServer

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools

### Pacotes Nuget SqlLite3

- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.SqlServer

### Pacotes Nuget Mysql

- MySql.Data
- MySql.Data.EntityFramework
- MySql.Data.EntityFrameworkCore
- MySql.EntityFrameworkCore
- Pomelo.EntityFrameworkCore.MySql

### Classe Program Seql Server

```
// String de Conexao com o banco de dados Sql Server

builder.Services.AddDbContext<DbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionSqlServer"));
});

```

### Classe Program Conexao Sqlite3

```
// Conexao com o Sqlite3 - Correta
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionSqlite") ??
    throw new InvalidOperationException("Connection string 'DefaultConnectionSqlite' not found.")));

```

### Classe Program Conexao Mysql

```
// Conexao  com o banco de dados Mysql - Sem Errors

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionMysql");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.Parse("8.0.40-mysql")));

```
### Seção 1:
### Aula 01 - Introdução
### Aula 02 - Apresentação o .NET
### Aula 03 - Visual Studio Code - Instalação 
### Aula 04 - Visual Studio Code - Instalação e criação Projeto MVC
### Aula 05 - Visual Studio Code - Template do Projeto MVC
### Aula 06 - Transição do uso da classe Startap para apenas a classe Program
### Aula 07 -  Visual Studio Code - Hot reload
### Aula 08 - SQL Server e SQL Server Management Studio

### Seção 2:

### Aula 09 - Apresentação do site de Venda de Lanches

### Aula 10 - Ambiente e Ferramentas usadas no curso

### Aula 11 - Criação do projeto ASP .NET Core MVC
- ASP Net Core - MVC

### Aula 12 - Apresentando a estrutura do projeto

### Aula 13 - Apresentando o padrão MVC - Model View Controller

1 - Models

- ?? 1. Model (Modelo)
- Representa os dados e a logica de negocio.

2 - View

- ?? 2. View (Visao)
- Interface com o usuario.

3 - Controler

- ?? 3. Controller (Controlador)
- Faz a ponte entre o Model e a View.
- Recebe as requisiçoes do usuário, processa os dados com o Model e retorna a View apropriada.

### Aula 14 - Funcionamento do projeto ASP .NET Core MVC

### Aula 15 - Criando o Carousel no site para venda de Lanches

```

<style>
    .carousel-item img {
        height: 400px; /* altura desejada */
        object-fit: cover; /* corta a imagem sem distorcer */
    }
</style>

<div id="carouselLanches" class="carousel slide shadow-lg rounded-3 overflow-hidden" data-bs-ride="carousel">
    <!-- Indicadores -->
    <div class="carousel-indicators">
        <button type="button" data-bs-target="#carouselLanches" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
        <button type="button" data-bs-target="#carouselLanches" data-bs-slide-to="1" aria-label="Slide 2"></button>
        <button type="button" data-bs-target="#carouselLanches" data-bs-slide-to="2" aria-label="Slide 3"></button>
        <button type="button" data-bs-target="#carouselLanches" data-bs-slide-to="4" aria-label="Slide 4"></button>
    </div>

    <!-- Slides -->
    <div class="carousel-inner">
        <div class="carousel-item active" data-bs-interval="5000">
            <img src="https://images.unsplash.com/photo-1610970878459-a0e464d7592b?q=80&w=924&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                 class="d-block w-100" alt="Hambúrguer delicioso">
            <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded-2 p-2">
                <h5>Hambúrguer Artesanal</h5>
                <p>Suculento e cheio de sabor!</p>
            </div>
        </div>

        <div class="carousel-item" data-bs-interval="5000">
            <img src="https://images.unsplash.com/photo-1568782947821-3d660dacc7cb?q=80&w=876&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                 class="d-block w-100" alt="Batata frita crocante">
            <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded-2 p-2">
                <h5>Batata Crocante</h5>
                <p>Acompanhamento perfeito para seu lanche.</p>
            </div>
        </div>

        <div class="carousel-item">
            <img src="https://plus.unsplash.com/premium_photo-1695055513501-2573541f00cd?q=80&w=870&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                 class="d-block w-100" alt="Refrigerante gelado">
            <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded-2 p-2">
                <h5>Refresco Gelado</h5>
                <p>Para completar sua refeição com estilo.</p>
            </div>
        </div>


        <div class="carousel-item">
            <img src="https://images.unsplash.com/photo-1665359045452-bfa257a2a6bf?q=80&w=870&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                 class="d-block w-100" alt="Refrigerante gelado">
            <div class="carousel-caption d-none d-md-block bg-dark bg-opacity-50 rounded-2 p-2">
                <h5>Refrigerante Gelado</h5>
                <p>Para o seu lanche com sabor refrescante.</p>
            </div>
        </div>


    </div>

    <!-- Controles -->
    <button class="carousel-control-prev" type="button" data-bs-target="#carouselLanches" data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Anterior</span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#carouselLanches" data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Próximo</span>
    </button>
</div>



```

### Aula 16 - Considerações sobre a arquitetura do projeto

### Seção 3: Modelo de Dominio - Ententy Framework Core

### Aula 17 - Criando o modelo de dominio
### Model Categorias

```
namespace ProjetoLanches.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [Display(Name = "Nome")]
        public string CategoriaNome { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho máximo é 200 caracteres")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set; }
    }
}

```

### Modelo de Dominio
### Model Lanches

```
namespace ProjetoLanches.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Nome do Lanche")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informada")]
        [Display(Name = "Descrição do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição pode exceder {1} caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "O descrição detalhada do lanche deve ser informada")]
        [Display(Name = "Descrição detalhada do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada pode exceder {1} caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o preço do lanche")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}


```

### Aula 18 - Apresentando o entity framework

### Aula 19 - Configurando o EF Core

### Aula 20 - Montando a string de conexão
### Montando a String de Conexao com SQL Server / Sqlite3 / Mysql

```
 "ConnectionStrings": {

    "DefaultConnectionSqlite": "Filename=./dados.db",

    "DefaultConnectionMysql": "server=localhost:3306; initial database=dbMacoratti; uid=admin; pwd=123",

    "DefaultConnectionSqlServer": "Server=DESKTOP-R2E5LVV\\SQLEXPRESS; Database=dbautenticacao; trusted_connection=true; trustservercertificate=true"

  },

```

### Aula 21 - Ententy Framework Core 7 e a String de conexão

- Apenas atualizando a String de conexao para o SQL Server

```
 "ConnectionStrings": {
    "DefaultConnectionSqlServer": "Server=DESKTOP-R2E5LVV\\SQLEXPRESS; Database=dbautenticacao; trusted_connection=true; trustservercertificate=true"
  },

```

### Aula 22 - Apresentando o Data Anotations
- Validações nas classes de dominum

### Aula 23 - Apresentando o Migrations do EF Core

### Adicionando Migrations no Visual Studio 2022

- Add-migration Inicial
- Update-migration
- remove-migration

### Aula 24 - Aplicando os atributos Data Anotations

### Aula 25 - Aplicando o Migrations no projeto
### Verificar se está instalado

- dotnet ef

### Instala Global

- dotnet tool install --global dotnet-ef

### Update e Atualiza

- dotnet ef database update

### Aula 26 - Como popular as tabelas usando migrations

### Aula 27 - Populando a tabela categoria com dados iniciais

- add-migration PopularCategorias
- update-database

### Aula 28 - Populando a tabela lanches com dados iniciais

- add-migration PopularLanhces
- update-database

### Aula 29 - Apresentando o padrão Repository

- Desacopla a sua aplicação da lógica de acesso a dados
- Centraliza a lógica de acesso a dados
- Facilita a realização de testes
- Facilita a manutenção do código
- Minimiza a duplicação de código nas consultas e comandos

### Aula 30 - Implementand o padrão Repository para Categoria
### ICategoriaRepository - Interface

```
using ProjetoLanches.Models;

// Define um namespace para organizar o código relacionado a repositórios e interfaces
namespace ProjetoLanches.Repositories.Interfaces
{
    // Interface que representa o contrato para o repositório de categorias
    public interface ICategoriaRepository
    {
        // Propriedade que retorna uma coleção de objetos do tipo Categoria
        // O uso de IEnumerable permite iteração eficiente e flexível sobre os dados
        IEnumerable<Categoria> Categorias { get; }
    }
}

```

### CategoriaRepository

```
// Define o namespace onde a classe está localizada, ajudando na organização do projeto
namespace ProjetoLanches.Repositories
{
    // Classe que implementa a interface ICategoriaRepository
    // Responsável por acessar os dados da tabela de categorias no banco
    public class CategoriaRepository : ICategoriaRepository
    {
        // Campo privado e somente leitura que representa o contexto do banco de dados
        private readonly ApplicationDbContext _context;

        // Construtor que recebe o contexto do banco de dados via injeção de dependência
        public CategoriaRepository(ApplicationDbContext context)
        {
            // Armazena o contexto recebido para uso nos métodos da classe
            _context = context;
        }

        // Propriedade que retorna todas as categorias do banco de dados
        // Utiliza o Entity Framework para acessar a tabela Categorias
        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}

```

### Aula 31 - Implementando o padrão Repository para Lanches
### Interface

```
// Define o namespace onde a interface está localizada, organizando o código por funcionalidade
namespace ProjetoLanches.Repositories.Interfaces
{
    // Interface que define o contrato para o repositório de lanches
    public interface ILancheRepository
    {
        // Propriedade que retorna todos os lanches disponíveis no sistema
        IEnumerable<Lanche> Lanches { get; } // Retorna uma lista de lanches

        // Propriedade que retorna apenas os lanches marcados como preferidos
        IEnumerable<Lanche> LanchesPreferidos { get; } // Retorna uma lista de lanches preferidos

        // Método que busca um lanche específico pelo seu ID
        Lanche GetLancheById(int id); // Acessa um lanche específico
    }
}

```

### Classe Lanche

```
// Define o namespace onde a classe está localizada, organizando o código por funcionalidade
namespace ProjetoLanches.Repositories
{
    // Classe que implementa a interface ILancheRepository
    // Responsável por acessar os dados da tabela de lanches no banco
    public class LancheRepository : ILancheRepository
    {
        // Campo privado e somente leitura que representa o contexto do banco de dados
        private readonly ApplicationDbContext _context;


        // Construtor que recebe o contexto do banco de dados via injeção de dependência
        public LancheRepository(ApplicationDbContext contexto)
        {
            // Armazena o contexto recebido para uso nos métodos da classe
            _context = contexto;
        }


        // Propriedade que retorna todos os lanches cadastrados, incluindo suas categorias
        public IEnumerable<Lanche> Lanches =>
            _context.Lanches.Include(c => c.Categoria); // Usa Include para carregar os dados da categoria junto com o lanche

        // Propriedade que retorna apenas os lanches marcados como preferidos, incluindo suas categorias
        public IEnumerable<Lanche> LanchesPreferidos =>
            _context.Lanches
                .Where(l => l.IsLanchePreferido) // Filtra os lanches preferidos
                .Include(c => c.Categoria);      // Inclui os dados da categoria

        // Método que retorna um lanche específico com base no seu ID
        public Lanche GetLancheById(int LancheId)
        {
            // Busca o primeiro lanche que tenha o ID informado, ou retorna null se não encontrar
            return _context.Lanches.FirstOrDefault(l => l.LancheId == LancheId);
        }
    }
}


```

### Aula 32 - Registrando o serviço dos repositórios : Injeção de Dependência

```
builder.Services.AddTransient<ILancheRepository, LancheRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>()
```

### Aula 33 - Criando o Controller a View para exibir os lanches

```
namespace ProjetoLanches.Controllers
{
    public class LancheController : Controller
    {

        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        // Método construtor

        public IActionResult List()
        {

            var lancheslistViewModel = new LancheListViewModel();
            {
                lancheslistViewModel.Lanches = _lancheRepository.Lanches;
                lancheslistViewModel.CategoriaAtual = "Categoria Atual";
            }

            return View(lancheslistViewModel);


        }
    }
}

```

### Cria uma Tabela Categorias e Lanches no Banco de dados

```
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

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Lanche> Lanche { get; set; }
    }
}


```

### Aula 30 - Implementando o padrão de Repository para Categoria

- Repositories
- Interfaces
  - ILancheRepository
  - LancheRepository
- Categorias
  - ICategoriaRepository
  - CategoriaRepository

### Aula 31 - Implementando o padrão de Repository para Lanches

### Aula 32 - Registrando o serviço dos repositórios : Injeção de Dependência

- builder.Services.AddTransient<ILancheRepository, LancheRepository>();
- builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

### Aula 33 - Criando o Controller a View para exibir os lanches

- LancheController

```
public class LancheController : Controller
{
    private readonly ILancheRepository _lancheRepository;

    public LancheController(ILancheRepository lancheRepository)
    {
        _lancheRepository = lancheRepository;
    }

    // Método construtor

    public IActionResult List()
    {
        var lanches = _lancheRepository.Lanches;
        return View(lanches);
    }
}
```

### View - Lanche - Index.cshtml

- Criou uma View com a Index.cshtml alterado para List.cshtml

### Aula 34 - Ajustando o código da View List

### Lanche -> List.cshtml

```
@model IEnumerable<ProjetoLanches.Models.Lanche>

<div>
    <h4>Todos os Lanches</h4>

</div>

@foreach(var lanche in Model)
{
    <div>
        <h4>@lanche.Nome</h4>
        <p><img src="@lanche.ImagemUrl"></p>
        <h3>@lanche.Preco.ToString("c")</h3>
   </div>
}
```

### Aula 35 - Conceitos : ViewData, ViewBag e TempData

- ViewData-> Os dados viajam do controlador para a view através de um dicionário ViewDataDictionary. Este ViewDataDictionary é uma classe dicionário que é chamada ViewData.
- viewBag -> é apenas um invólucro dinâmico em torno de ViewData, sendo uma propriedade dinâmica baseada no recurso dynamic da plataforma .NET.
- TempData -> ajuda na manutenção de dados quando você se move de um controlador para outro controlador. Para manter os dados ele utiliza uma variável de sessão (internamente).

### Aula 36 - Conceitos :

- \_ViewStart : Executar código comum antes que qualquer view ou página Razor seja renderizada
- \_ViewImports: Importar diretivas e declarações de forma global para todas as suas páginas de visualização.

### Aula 37 - Bootstrap : Ajustando o código para exibir os lanches

### Aula 38 - Apresentando o conceito de ViewModel

- contém a logica de interface do usuário

### Aula 39 - Implementando a view model LancheListViewModel

```
namespace ProjetoLanches.ViewModels
{
    public class LancheListViewModel
    {
        // Definindo as propriedades do ViewModel
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }
    }

}
```

### Ajustando o \_ViewImports.cshtml

```
@using ProjetoLanches
@using ProjetoLanches.Models
@using ProjetoLanches.ViewModels
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

```

### Aula 40 - Apresentando Partial Views

- Definindo uma partial view: \_partial

### Aula 41 - Criando a partial view \_LanchesResumo.cshtml

### Diretório Share -> \_LanchesResumo.cshtml

```
@model Lanche

<div class="col-sm-4 col-md-4 col-lg-4">
      <h4>@Model.Nome</h4>

       <p class="img-fluid"><img src="@Model.ImagemUrl"></p>

       <h3> Preço: @Model.Preco.ToString("c")</h3>
       <h4> @Model.Nome</h4>
       <p>@Model.DescricaoCurta</p>
</div>
```

### Aula 42 - Criando os itens do Carrinho de Compras : Conceitos

### Aula 43 - Implementando os itens do carrinho de compras

- add-migration CarrinhoCompraItem
- update-database

### Aula 44 - Apresentando o conceito de Session

- O Session no ASP.NET é uma forma de armazenar dados temporários para um usuário específico enquanto ele navega pelo site.

### Aula 45 - Configurando Session e HttpContext

```
builder.Services.AddMemoryCache();
builder.Services.AddSession();
```

### Aula 46 - Criando o carrinho de Compras

```
// Define um namespace para organizar o código relacionado
namespace ProjetoLanches.Models
{
    //Classe quem implementa um Carrinho de Compra
    public class CarrinhoCompra
    {

        // Conexão com o banco de dados via Entity Framework
        private readonly ApplicationDbContext _context;

        // Construtor da classe CarrinhoCompra que recebe o contexto do banco de dados
        public CarrinhoCompra(ApplicationDbContext context)
        {
            // Armazena o contexto recebido para uso interno
            _context = context;
        }

        // Propriedade que armazena o ID único do carrinho de compras
        public string CarrinhoCompraId { get; set; }


        // Lista de itens que pertencem ao carrinho de compras
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        // Método estático que obtém ou cria um carrinho de compras vinculado à sessão do usuário
        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            // Obtém a sessão HTTP atual do usuário
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            // Obtém o contexto do banco de dados a partir dos serviços
            var context = services.GetService<ApplicationDbContext>();


            // Tenta recuperar o ID do carrinho da sessão; se não existir, gera um novo GUID
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            // Salva o ID do carrinho na sessão para persistência entre requisições
            session.SetString("CarrinhoId", carrinhoId);

            // Cria e retorna uma nova instância de CarrinhoCompra com o contexto e o ID definido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }
    }
}

```

### Aula 47

- Adicionar Itens ao Carrinho de Compras

```
// Método para adicionar um item ao carrinho de compras
public void AdicionarAoCarrinho(Lanche lanche)
{
    // Busca no banco de dados se já existe um item no carrinho com o mesmo LancheId e CarrinhoCompraId
    var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault
        (
        s => s.Lanche.LancheId == lanche.LancheId && // Verifica se o lanche é o mesmo
        s.CarrinhoCompraId == CarrinhoCompraId       // Verifica se pertence ao mesmo carrinho
        );

    // Se o item ainda não está no carrinho
    if (carrinhoCompraItem == null)
    {
        // Cria um novo item de carrinho com quantidade 1
        carrinhoCompraItem = new CarrinhoCompraItem {
            CarrinhoCompraId = CarrinhoCompraId, // Define o ID do carrinho
            Lanche = lanche,                     // Associa o lanche ao item
            Quantidade = 1                       // Define a quantidade inicial como 1
        };

        // Adiciona o novo item ao banco de dados
        _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
    }
    else
    {
        // Se o item já existe, apenas incrementa a quantidade
        carrinhoCompraItem.Quantidade++;
    }

    // Salva as alterações no banco de dados
    _context.SaveChanges();
}

```

### Aula 48

- Remover itens do Carrinho de Compras

```
 // Metodo para Remover do Carrinho
 public int RemoverDoCarrinho(Lanche lanche)
 {
     // Busca no banco de dados se já existe um item no carrinho com o mesmo LancheId e CarrinhoCompraId
     var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault
         (
         s => s.Lanche.LancheId == lanche.LancheId && // Verifica se o lanche é o mesmo
         s.CarrinhoCompraId == CarrinhoCompraId       // Verifica se pertence ao mesmo carrinho
         );

     // Variável que armazenará a quantidade atual do item após a remoção
     var quantidadeLocal = 0;

     // Se o item foi encontrado no carrinho
     if (carrinhoCompraItem != null)
     {
         // Se a quantidade do item for maior que 1, apenas decrementa
         if (carrinhoCompraItem.Quantidade > 1)
         {
             carrinhoCompraItem.Quantidade--; // Reduz a quantidade em 1
                                              //quantidadeLocal = carrinhoCompraItem.Quantidade; // (Comentado) Poderia armazenar a nova quantidade
         }
         else
         {
             // Se a quantidade for 1, remove o item do carrinho completamente
             _context.CarrinhoCompraItens.Remove(carrinhoCompraItem); // ⚠️ Faltou ponto e vírgula aqui!
         }
     }

     // Salva as alterações no banco de dados
     _context.SaveChanges();

     // Retorna a quantidade atual do item (sempre será 0 neste caso, pois não foi atualizada)
     return quantidadeLocal;
 }

```

### Aula 49 - Concluindo o Carrinho de Compras

```
  // Método que retorna uma lista dos itens do carrinho de compras
  public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
  {
      // Verifica se a lista CarrinhoCompraItems já foi carregada
      // Se não, busca os itens do carrinho no banco de dados com base no CarrinhoCompraId
      // Inclui os dados do lanche relacionado a cada item
      return CarrinhoCompraItems ??
           (CarrinhoCompraItems = _context.CarrinhoCompraItens
           .Where(c => c.CarrinhoCompraId == CarrinhoCompraId) // Filtra os itens pelo ID do carrinho
           .Include(s => s.Lanche)                             // Carrega os dados do lanche associado
           .ToList());                                         // Converte o resultado para uma lista
  }

```

### Limpar todos os itens do carrinho

```
 // Método que remove todos os itens do carrinho de compras
  public void LimparCarrinho()
  {
      // Busca todos os itens do carrinho com base no CarrinhoCompraId
      var carrinhoItens = _context.CarrinhoCompraItens
          .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

      // Remove todos os itens encontrados de uma vez
      _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);

      // Salva as alterações no banco de dados
      _context.SaveChanges();
  }

```

### Calcular o Valor Total do carrinho

```
     // Método para calcular o valor total dos itens no carrinho de compras
     public decimal GetCarrinhoCompraTotal()
     {
         // Busca todos os itens do carrinho que possuem o mesmo CarrinhoCompraId

         var valorToral = _context.CarrinhoCompraItens
             .Where(valortotal => valortotal.CarrinhoCompraId == CarrinhoCompraId) // Filtra os itens do carrinho atual
             .Select(valortotal => valortotal.Lanche.Preco * valortotal.Quantidade) // Multiplica o preço do lanche pela quantidade
             .Sum(); // Soma todos os valores calculados para obter o total

         // Retorna o valor total do carrinho
         return valorToral;
     }

```

### Aula 50

- Criando o Controlador para gerenciar os itens do carrinho de compras
- CarrinhoCompraController

```
// Aula 50  - Define o namespace do projeto, agrupando as classes relacionadas
namespace ProjetoLanches.Controllers
{

    // Define a classe do controller responsável pelo carrinho de compras
    public class CarrinhoCompraController : Controller
    {

        // Declara uma variável para acessar os dados dos lanches
        private readonly ILancheRepository _lancheRepository;
        // Declara uma variável para manipular o carrinho de compras
        private readonly CarrinhoCompra _carrinhoCompra;


        // Construtor da classe, que recebe as dependências via injeção de dependência
        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            // Atribui o repositório de lanches à variável privada
            _lancheRepository = lancheRepository;

            // Atribui o carrinho de compras à variável privada
            _carrinhoCompra = carrinhoCompra;
        }


        // Método que retorna a view principal do carrinho de compras
        public IActionResult Index()
        {
            // Retorna a view associada à ação Index
            return View();
        }
    }
}

```

### Aula 51 - Criando o Controlador para gerenciar os itens do carrinho de compras - II

```
// Aula 50  - Define o namespace do projeto, agrupando as classes relacionadas
namespace ProjetoLanches.Controllers
{

    // Define a classe do controller responsável pelo carrinho de compras
    public class CarrinhoCompraController : Controller
    {

        // Declara uma variável para acessar os dados dos lanches
        private readonly ILancheRepository _lancheRepository;
        // Declara uma variável para manipular o carrinho de compras
        private readonly CarrinhoCompra _carrinhoCompra;


        // Construtor da classe, que recebe as dependências via injeção de dependência
        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            // Atribui o repositório de lanches à variável privada
            _lancheRepository = lancheRepository;

            // Atribui o carrinho de compras à variável privada
            _carrinhoCompra = carrinhoCompra;
        }


        // Método que retorna a view principal do carrinho de compras
        public IActionResult Index()
        {
            // Obtém os itens atualmente no carrinho de compras
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            // Atribui os itens obtidos à propriedade do carrinho de compras
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraViewModel = new ViewModels.CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            // Retorna a view associada à ação Index
            return View(carrinhoCompraViewModel);
        }

        // Método que adiciona um lanche ao carrinho de compras
        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
        {
            // Busca o lanche pelo ID fornecido
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            // Se o lanche for encontrado, adiciona-o ao carrinho de compras
            if (lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            }
            // Redireciona para a ação Index do controller atual
            return RedirectToAction("Index");

        }

        // Método que Remover um lanche ao carrinho de compras
        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
        {
            // Busca o lanche pelo ID fornecido
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            // Se o lanche for encontrado, adiciona-o ao carrinho de compras
            if (lancheSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
            }
            // Redireciona para a ação Index do controller atual
            return RedirectToAction("Index");

        }

    }
}

```

### Aula 52 - Criando a View para exibir os itens do carrinho de compras

```
namespace ProjetoLanches.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }

     }
}

```

### Aula 53 - Exibindo os lanches preferidos

```
namespace ProjetoLanches.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public HomeController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;

        }


        public IActionResult Index()
        {

            var homeViewModel = new ViewModels.HomeViewModel
            {
                LanchesPreferidos = _lancheRepository.LanchesPreferidos
            };
            return View(homeViewModel);
            //return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


```

### Aula 54 - Apresentando o conceito de ViewComponent

### Aula 55 - Criando uma ViewComponent para exibir detalhes do carrinho

```
// Aula 55 - Importa o namespace necessário para criar componentes de visão
// Define o namespace onde está localizado o componente de visão do carrinho de compras
namespace ProjetoLanches.Components
{


    // Classe que representa o componente de visão do resumo do carrinho de compras
    public class CarrinhoCompraResumo : ViewComponent
    {
        // Declara uma variável para manipular o carrinho de compras
        private readonly CarrinhoCompra _carrinhoCompra;

        // Construtor da classe, que recebe o carrinho de compras via injeção de dependência
        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            // Atribui o carrinho de compras à variável privada
            _carrinhoCompra = carrinhoCompra;
        }



        // Método que é chamado para renderizar o componente de visão
        public IViewComponentResult Invoke()
        {
            // Obtém os itens atualmente no carrinho de compras
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            // Atribui os itens obtidos à propriedade do carrinho de compras
            _carrinhoCompra.CarrinhoCompraItems = itens;

            // Cria uma instância do ViewModel do carrinho de compras, preenchendo suas propriedades
            var carrinhoCompraViewModel = new ViewModels.CarrinhoCompraViewModel
            {
                // Define o carrinho de compras atual
                CarrinhoCompra = _carrinhoCompra,
                // Calcula e define o valor total dos itens no carrinho
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            // Retorna a view associada à ação Index
            return View(carrinhoCompraViewModel);


        }
    }
}


```

### Aula 55 - Continuação

- Criando o diretório - Components
- Criar a Classe CarrinhoCompraResumo, que herda de ViewComponent
- Share cria o diretória components

```
@model CarrinhoCompraViewModel

@if(Model.CarrinhoCompra.CarrinhoCompraItems.Count > 0)
{
    <a asp-controller="CarrinhoCompra" asp-action="Index">
        <span class="badge badge-pill badge-primary">
            @Model.CarrinhoCompra.CarrinhoCompraItems.Count
        </span>
        <span class="text-dark">
            Itens no carrinho
        </span>
    </a>
}

```
### Aula 56 - Apresentando o conceito de TagHelpers

### Aula 57 - Criando uma TagHelper

- Criar diretório TagHelpers
- Criar classe EmailTagHelper
- Sobreescrever o método Process
- Criar item de menu contato no arquivo Layout
- Criar controlador ContatoController
- Criar Método action index e a view Index

### Aula 58 - Ajustando o LancheController para exibir lanches por categoria

```
namespace ProjetoLanches.Controllers
{
    public class LancheController : Controller
    {
        // Declara uma variável para acessar os dados dos lanches
        private readonly ILancheRepository _lancheRepository;
        // Construtor da classe, que recebe o repositório de lanches via injeção de dependência
        public LancheController(ILancheRepository lancheRepository)
        {   // Atribui o repositório de lanches à variável privada
            _lancheRepository = lancheRepository;
        }


        // Método construtor

        public IActionResult List(string categoria)
        {

            // Declara variáveis para armazenar a lista de lanches e a categoria atual
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            // Verifica se a categoria foi fornecida
            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os Lanches";
            }
            // Se a categoria for "Normal" ou "Natural"
            else
            {
                // Filtra os lanches com base na categoria fornecida
                if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches
                        .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                        .OrderBy(l => l.Nome);
                }
                // Se a categoria for "Natural"
                else
                {
                    lanches = _lancheRepository.Lanches
                        .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                        .OrderBy(l => l.Nome);
                }
                // Define a categoria atual com base na categoria fornecida
                categoriaAtual = categoria;

            }
            // Cria uma instância do ViewModel e popula suas propriedades
            var lancheslistViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual,
            };

            // Retorna a view associada à ação List, passando o ViewModel como parâmetro
            return View(lancheslistViewModel);

        }

    }
}



```

### Aula 59 - Apresentando os conceitos sobre Roteamento
### Aula 60 - Múltiplas Rotas - Criando a rota para exibir lanches por categoria
```
// 60 - Múltiplas Rotas - Criando a rota para exibir lanches por categoria
app.UseEndpoints(endpoints =>
{

    // Rota para exibir lanches por categoria
    endpoints.MapControllerRoute(
        name: "categoriaFiltro",
        pattern: "Lanche{action}/{categoria?}",
        defaults: new { controller = "Lanche", action = "List" });

    // Rota para o carrinho de compras
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "admin/{action=Index}/{id?}",
        defaults: new { controller = "Admin" });
   
});

```
### Aula 61 - Criar View Componente para exibir as categorias no menu Lanches
```
namespace ProjetoLanches.Controllers
{
    public class LancheController : Controller
    {
        // Declara uma variável para acessar os dados dos lanches
        private readonly ILancheRepository _lancheRepository;
        // Construtor da classe, que recebe o repositório de lanches via injeção de dependência
        public LancheController(ILancheRepository lancheRepository)
        {   // Atribui o repositório de lanches à variável privada
            _lancheRepository = lancheRepository;
        }


        // Ação que exibe a lista de lanches, possivelmente filtrada por categoria
        public IActionResult List(string categoria)
        {
            // Declara variáveis para armazenar a lista de lanches e a categoria atual
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            // Verifica se a categoria foi fornecida
            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                // Filtra os lanches com base na categoria fornecida
                if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches
                        .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                        .OrderBy(l => l.Nome);
                }
                else
                {
                    lanches = _lancheRepository.Lanches
                        .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                        .OrderBy(l => l.Nome);
                }

                // Define a categoria atual com base na categoria fornecida
                categoriaAtual = categoria;
            }

            // Cria uma instância do ViewModel e popula suas propriedades
            var lancheslistViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual,
            };

            // Retorna a view associada à ação List, passando o ViewModel como parâmetro
            return View(lancheslistViewModel);
        }

    }
}


```
### Aula 62 - Otimizando o método Action List de LancheController

```
namespace ProjetoLanches.Controllers
{
    public class LancheController : Controller
    {
        // Declara uma variável para acessar os dados dos lanches
        private readonly ILancheRepository _lancheRepository;
        // Construtor da classe, que recebe o repositório de lanches via injeção de dependência
        public LancheController(ILancheRepository lancheRepository)
        {   // Atribui o repositório de lanches à variável privada
            _lancheRepository = lancheRepository;
        }


        // Ação que exibe a lista de lanches, possivelmente filtrada por categoria
        public IActionResult List(string categoria)
        {
            // Declara variáveis para armazenar a lista de lanches e a categoria atual
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            // Verifica se a categoria foi fornecida
            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
             // Filtra os lanches com base na categoria fornecida
                lanches = _lancheRepository.Lanches
                     .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                     .OrderBy(c => c);
                

                // Define a categoria atual com base na categoria fornecida
                categoriaAtual = categoria;
            }

            // Cria uma instância do ViewModel e popula suas propriedades
            var lancheslistViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual,
            };

            // Retorna a view associada à ação List, passando o ViewModel como parâmetro
            return View(lancheslistViewModel);
        }

    }
}

```
### Aula 63 - Incluindo um link e um button na exibição dos lanches
### Script datatable



- link inserir no layout: <link href="//cdn.datatables.net/2.3.3/css/dataTables.dataTables.min.css" rel="stylesheet" />

```
@section Scripts {
    <script>
        $(document).ready(function () {
            $('#myTable').DataTable({
                language: {
                    url: "//cdn.datatables.net/plug-ins/1.13.6/i18n/pt-BR.json"
                }
            });
        });
    </script>
}

```
