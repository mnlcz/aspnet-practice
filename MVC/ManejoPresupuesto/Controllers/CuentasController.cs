using ManejoPresupuesto.Models;
using ManejoPresupuesto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManejoPresupuesto.Controllers;

public class CuentasController(
    IRepositorioTiposCuentas repositorioTiposCuentas,
    IServicioUsuarios servicioUsuarios,
    IRepositorioCuentas repositorioCuentas)
    : Controller
{
    [HttpGet]
    public async Task<IActionResult> Crear()
    {
        var usuarioId = servicioUsuarios.ObtenerUsuarioId();
        var tiposCuentas = await repositorioTiposCuentas.Obtener(usuarioId);
        var modelo = new CuentaCreacionViewModel();

        modelo.TiposCuentas = await ObtenerTiposCuentas(usuarioId);

        return View(modelo);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CuentaCreacionViewModel modelo)
    {
        var usuarioId = servicioUsuarios.ObtenerUsuarioId();
        var tipoCuenta = await repositorioTiposCuentas.ObtenerPorId(modelo.TipoCuentaId, usuarioId);

        if (tipoCuenta is null)
        {
            return RedirectToAction("NoEncontrado", "Home");
        }

        if (!ModelState.IsValid)
        {
            modelo.TiposCuentas = await ObtenerTiposCuentas(usuarioId);
            return View(modelo);
        }
        
        await repositorioCuentas.Crear(modelo);
        return RedirectToAction("Index");
    }

    private async Task<IEnumerable<SelectListItem>> ObtenerTiposCuentas(int usuarioId)
    {
        var tiposCuentas = await repositorioTiposCuentas.Obtener(usuarioId);
        return tiposCuentas.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
    }
}