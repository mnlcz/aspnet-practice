using ManejoPresupuesto.Models;
using ManejoPresupuesto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManejoPresupuesto.Controllers;

public class CuentasController(IRepositorioTiposCuentas repositorioTiposCuentas, IServicioUsuarios servicioUsuarios)
    : Controller
{
    [HttpGet]
    public async Task<IActionResult> Crear()
    {
        var usuarioId = servicioUsuarios.ObtenerUsuarioId();
        var tiposCuentas = await repositorioTiposCuentas.Obtener(usuarioId);
        var modelo = new CuentaCreacionViewModel();

        modelo.TiposCuentas = tiposCuentas.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
        
        return View(modelo);
    }
}