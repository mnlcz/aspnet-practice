using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using System.Diagnostics;
using Portafolio.Services;

namespace Portafolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositorioProyectos repo;
    private readonly IEmail email;

    public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repo, IEmail email)
    {
        _logger = logger;
        this.repo = repo;
        this.email = email;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var proyectos = repo.ObtenerProyectos().Take(3).ToList();
        HomeIndexViewModel modelo = new() { Proyectos = proyectos };
        return View(modelo);
    }

    [HttpGet]
    public IActionResult ListadoProyectos()
    {
        var proyectos = repo.ObtenerProyectos().ToList();
        return View(proyectos);
    }

    [HttpGet]
    public IActionResult Contacto()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
    {
        await email.Enviar(contactoViewModel);
        return RedirectToAction("Gracias");
    }

    [HttpGet]
    public IActionResult Gracias()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}