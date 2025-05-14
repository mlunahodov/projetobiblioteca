using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;
using System.Threading.Tasks;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace Biblioteca.Controllers;

public class HomeController : Controller
{
    private static List<LivroModel> listaLivros = new List<LivroModel>();
    private static int proximoId = 1;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Cadastrar()
    {
        return View();
    }
    public IActionResult Create(LivroModel livro)
    {
        if (livro.id == 0)
        {
            livro.id = proximoId++;
            listaLivros.Add(livro);
        }
        else
        {
            LivroModel livroexistente = listaLivros.FirstOrDefault(t => t.id == livro.id);

            if (livroexistente != null)
            {

                livroexistente.titulo = livro.titulo;
                livroexistente.genero = livro.genero;
                livroexistente.autor = livro.autor;
                livroexistente.sumario = livro.sumario;
                livroexistente.status = livro.status;
            }

        }

        return RedirectToAction("Listar");
    }
    public IActionResult Listar()
    {
        return View(listaLivros);
    }

    public IActionResult Excluir(int id)
    {
        try
        {
            var livro = listaLivros.FirstOrDefault(t => t.id == id);
            if (livro != null)
            {
                listaLivros.Remove(livro);
                
            }
            

            return RedirectToAction("Listar");
        }
        catch (Exception ex)
        {
            TempData["Mensagem"] = $"Erro ao excluir: {ex.Message}";
            TempData["MensagemTipo"] = "erro";
            return RedirectToAction("Listar");
        }
    }


    [HttpGet]
    public IActionResult ObterLivro(int id)
    {
        var livro = listaLivros.FirstOrDefault(t => t.id == id);
        if (livro != null)
        {

            return View("Editar", livro);

            
        }
        return NotFound();
    }

    [HttpGet]
    public IActionResult PesquisarLivro(string termo)
    {

        var livrosEncontradas = listaLivros.Where(t => t.titulo.Contains(termo) || t.sumario.Contains(termo)).ToList();

        return View("Listar", livrosEncontradas);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
