### Aula ViwData, ViewBag, DataTemp
```
using Microsoft.AspNetCore.Mvc;
using ProjetoLanches.Repositories.Interfaces;

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
            // ViewData 
            ViewData["Title"] = "Todos os Lanches";
            ViewData["dATA"] = DateTime.Now;

            // Obtendo a lista de lanches e o total de lanches
            var lanches = _lancheRepository.Lanches;
            var totalLanches = lanches.Count();

            // Definindo o título da página
            ViewBag.Title = "Todos os Lanches";
            // Passando o total de lanches para a ViewBag
            ViewBag.TotalLanches = totalLanches;



            return View(lanches);
        }
    }
}

```

### Classe View
```
@model IEnumerable<ProjetoLanches.Models.Lanche>

<div>
    <h2>@ViewData["Title"]</h2>

</div>
<h2>@ViewData["Data"]</h2>


<h3>@ViewBag.Total @ViewBag.TotalLanches</h3>

<h3>@TempData["Nome"]</h3>

@foreach(var lanche in Model)
{
    <div>   
        <h4>@lanche.Nome</h4>
        <p><img src="@lanche.ImagemUrl"></p>
        <h3>@lanche.Preco.ToString("c")</h3>
   </div>
}

```