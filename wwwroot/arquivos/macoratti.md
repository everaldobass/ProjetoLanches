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
- Recebe as requisi��es do usu�rio, processa os dados com o Model e retorna a View apropriada.

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
### Aula 34 - Ajustando o código da View List
### Aula 35 - Conceitos : ViewData, ViewBag e TempData














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

