### ASP.NET Core - Identity - I
###  Cria o projeto com banco de dados sqlite
- dotnet new mvc -au Individual -o autenticacao
- ASP .NET Core MVC

### Modelo MVC ASP.NET
### Models
- ?? 1. Model (Modelo)
- Representa os dados e a logica de negocio.

### View
- ?? 2. View (Visao)
- Interface com o usuario.

### Controler
- ?? 3. Controller (Controlador)
- Faz a ponte entre o Model e a View.
- Recebe as requisiçoes do usuário, processa os dados com o Model e retorna a View apropriada.

### Bibliotecas Utilizadas no projeto
https://www.nuget.org/
https://www.connectionstrings.com/

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


### Montando a String de Conexao com SQL Server / Sqlite3 / Mysql
```
 "ConnectionStrings": {

    "DefaultConnectionSqlite": "Filename=./dados.db",

    "DefaultConnectionMysql": "server=localhost:3306; initial database=dbMacoratti; uid=admin; pwd=123",

    "DefaultConnectionSqlServer": "Server=DESKTOP-R2E5LVV\\SQLEXPRESS; Database=dbautenticacao; trusted_connection=true; trustservercertificate=true"

  },

```
### Classe Program  Seql Server
```
// String de Conexao com o banco de dados Sql Server

builder.Services.AddDbContext<DbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionSqlServer"));
});

```
### Classe Program  Conexao Sqlite3
```
// Conexao com o Sqlite3 - Correta
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionSqlite") ??
    throw new InvalidOperationException("Connection string 'DefaultConnectionSqlite' not found.")));

``` 
### Classe Program  Conexao Mysql
```
// Conexao  com o banco de dados Mysql - Sem Errors

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionMysql");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.Parse("8.0.40-mysql")));

``` 
## Seção 3: Modelo de Dominio - Ententy Framework Core
### Model Categorias
```

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


### 
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
### Aula 25 - Aplicando o Migrations no projeto
### Verificar se est� instalado
- dotnet ef

### Instala Global
- dotnet tool install --global dotnet-ef

### Update e Atualiza
- dotnet ef database update

### Adicionando Migrations no Visual Studio 2022
- Add-migration Inicial
- Update-migration
- remove-migration

### Adicionar daddos na tabela Categorias
- add-migration PopularCategorias
- update-database

### Adicionar daddos na tabela Categorias
- add-migration PopularLanhces
- update-database

### Aula 29 - Apresentando o padrão Repository
- Desacopla a sua aplicação da lógica de acesso a dados
- Centraliza a lógica de acesso a dados
- Facilita a realização de testes
- Facilita a manutenção do código
- Minimiza a duplicação de código nas consultas e comandos

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
- TempData ->  ajuda na manutenção de dados quando você se move de um controlador para outro controlador. Para manter os dados ele utiliza uma variável de sessão (internamente).

### Aula 36
- Conceitos :
-  _ViewStart : Executar código comum antes que qualquer view ou página Razor seja renderizada
-  _ViewImports: Importar diretivas e declarações de forma global para todas as suas páginas de visualização.

### Aula 37
- Bootstrap : Ajustando o código para exibir os lanches

### Aula 38
- Apresentando o conceito de ViewModel
- contém a logica de interface do usuário

### Aula 39
- Implementando a view model LancheListViewModel

### Aula 40
- Apresentando Partial Views
- Definindo uma partial view: _partial

### Aula 41
-  Criando a partial view _LanchesResumo

### Aula 42
-  Criando os itens do Carrinho de Compras : Conceitos

### Aula 43
- Implementando os itens do carrinho de compras
- add-migration CarrinhoCompraItem
- update-database

### Aula 44
-  Apresentando o conceito de Session

### Aula 45
- Configurando Session e HttpContext

### Aula 46
- Criando o carrinho de Compras
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
-  Remover itens do Carrinho de Compras
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
### Aula 49
- Concluindo o Carrinho de Compras
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

### Aula 51
### Aula 52
### Aula 53
### Aula 54
### Aula 55
### Aula 56
### Aula 57
### Aula 58
### Aula 59
### Aula 60














### Melhorar a tela de Lista - (Index)
### Script datatable
- link inserir no layout:  <link href="//cdn.datatables.net/2.3.3/css/dataTables.dataTables.min.css" rel="stylesheet" />
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

