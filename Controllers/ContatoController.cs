using Microsoft.AspNetCore.Mvc;

// Define o namespace onde está localizado o controlador
namespace ProjetoLanches.Controllers
{
    // Define a classe do controlador para gerenciar as ações relacionadas ao contato
    public class ContatoController : Controller
    {
        // Define a ação padrão que retorna a view associada
        public IActionResult Index()
        {
            return View();
        }
    }
}
