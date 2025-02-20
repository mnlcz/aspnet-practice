using ManejoPresupuesto.Models;
using ManejoPresupuesto.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManejoPresupuesto.Controllers;

public class TiposCuentasController(IRepositorioTiposCuentas repositorioTiposCuentas) : Controller
{
    private readonly IRepositorioTiposCuentas _repositorioTiposCuentas = repositorioTiposCuentas;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var usuarioId = 1;
        var tiposCuentas = await _repositorioTiposCuentas.Obtener(usuarioId);

        return View(tiposCuentas);
    }

    [HttpGet]
    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Crear(TipoCuenta tipoCuenta)
    {
        if (!ModelState.IsValid)
        {
            return View(tipoCuenta);
        }

        tipoCuenta.UsuarioId = 1;

        var yaExisteTipoCuenta = await _repositorioTiposCuentas.Existe(tipoCuenta.Nombre, tipoCuenta.UsuarioId);

        if (yaExisteTipoCuenta)
        {
            ModelState.AddModelError(nameof(tipoCuenta.Nombre), "El tipo de cuenta ya existe");

            return View(tipoCuenta);
        }

        await _repositorioTiposCuentas.Crear(tipoCuenta);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> VerificarExisteTipoCuenta(string nombre)
    {
        var usuarioId = 1;
        var yaExisteTipoCuenta = await _repositorioTiposCuentas.Existe(nombre, usuarioId);

        if (yaExisteTipoCuenta)
        {
            return Json($"El nombre {nombre} ya existe.");
        }

        return Json(true);
    }
}
