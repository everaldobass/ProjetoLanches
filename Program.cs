using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ProjetoLanches.Context;
using ProjetoLanches.Models;
using ProjetoLanches.Repositories;
using ProjetoLanches.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

//### Classe Program  Conexao Sqlite3
// Conexao com o Sqlite3 - Correta
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnectionSqlite") ??
    throw new InvalidOperationException("Connection string 'DefaultConnectionSqlite' not found.")));


// Aula 32 - Injeção de dependência
builder.Services.AddTransient<ILancheRepository, LancheRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
// Aula 45 - Inejeção de dependência para acessar o contexto HTTP - Enquanto o usuário navega no site
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// Aula 50
builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

// Aula 45 - Session e Carrinho de Compras
builder.Services.AddMemoryCache();
builder.Services.AddSession();


//### Classe Program  Seql Server
// String de Conexao com o banco de dados Sql Server
//builder.Services.AddDbContext<DbContext>(options =>
//{
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionSqlServer"));
//});



//### Classe Program  Conexao Mysql
// Conex?o  com o banco de dados Mysql - Sem Errors
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionMysql");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//options.UseMySql(connectionString, ServerVersion.Parse("8.0.40-mysql")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Aula 45 - Utilizando o session
app.UseSession();

app.UseAuthorization();

// Aula 58 - Definindo as rotas

// 60 - Múltiplas Rotas - Criando a rota para exibir lanches por categoria
// Rotas personalizadas
app.UseEndpoints(endpoints =>
{
    // Rota para exibir lanches por categoria
    endpoints.MapControllerRoute(
        name: "categoriaFiltro",
        pattern: "Lanche/{action}/{categoria?}",
        defaults: new { controller = "Lanche", action = "List" });

    // Rota padrão
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

// Rota padrão
//app.MapControllerRoute(
//name: "default",
// pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

