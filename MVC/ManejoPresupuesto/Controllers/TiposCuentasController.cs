using Dapper;
using ManejoPresupuesto.Models;
using ManejoPresupuesto.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManejoPresupuesto.Controllers;

public class TiposCuentasController(IRepositorioTiposCuentas repositorioTiposCuentas) : Controller
{
    private readonly IRepositorioTiposCuentas _repositorioTiposCuentas = repositorioTiposCuentas;

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

        return View();
    }
}
