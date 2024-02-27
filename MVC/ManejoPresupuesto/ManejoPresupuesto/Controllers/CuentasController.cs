using ManejoPresupuesto.Services;
using ManejoPresupuesto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;

namespace ManejoPresupuesto.Controllers;

public class CuentasController : Controller
{
    private readonly IRepositorioTiposCuentas _repoTiposCuentas;
    private readonly IServicioUsuarios _servicioUsuarios;
    private readonly IRepositorioCuentas _repoCuentas;
    private readonly IMapper _mapper;

    public CuentasController(IRepositorioTiposCuentas repoTiposCuentas, IServicioUsuarios servicioUsuarios,
            IRepositorioCuentas repoCuentas, IMapper mapper)
    {
        _repoTiposCuentas = repoTiposCuentas;
        _servicioUsuarios = servicioUsuarios;
        _repoCuentas = repoCuentas;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var usuarioId = _servicioUsuarios.ObtenerUsuarioId();
        var cuentasConTipoCuenta = await _repoCuentas.Buscar(usuarioId);
        var modelo = cuentasConTipoCuenta
            .GroupBy(x => x.TipoCuenta)
            .Select(grupo => new IndiceCuentasViewModel
            {
                TipoCuenta = grupo.Key,
                Cuentas = grupo.AsEnumerable()
            }).ToList();
        return View(modelo);
    }

    [HttpGet]
    public async Task<IActionResult> Crear()
    {
        var usuarioId = _servicioUsuarios.ObtenerUsuarioId();
        var modelo = new CreadorCuentaViewModel();
        modelo.TiposCuentas = await ObtenerTiposCuentas(usuarioId);
        return View(modelo);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CreadorCuentaViewModel cuenta)
    {
        var usuarioId = _servicioUsuarios.ObtenerUsuarioId();
        var tipoCuenta = await _repoTiposCuentas.ObtenerPorId(cuenta.TipoCuentaId, usuarioId);
        if (tipoCuenta is null) return RedirectToAction("NoEncontrado", "Home");
        if (!ModelState.IsValid)
        {
            cuenta.TiposCuentas = await ObtenerTiposCuentas(usuarioId);
            return View(cuenta);
        }
        await _repoCuentas.Crear(cuenta);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Editar(CreadorCuentaViewModel cuentaEditar)
    {
        var usuarioId = _servicioUsuarios.ObtenerUsuarioId();
        var cuenta = await _repoCuentas.ObtenerPorId(cuentaEditar.Id, usuarioId);
        if (cuenta is null)
            return RedirectToAction("NoEncontrado", "Home");
        var tipoCuenta = await _repoTiposCuentas.ObtenerPorId(cuentaEditar.TipoCuentaId, usuarioId);
        if (tipoCuenta is null)
            return RedirectToAction("NoEncontrado", "Home");
        await _repoCuentas.Actualizar(cuentaEditar);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Editar(int id)
    {
        var usuarioId = _servicioUsuarios.ObtenerUsuarioId();
        var cuenta = await _repoCuentas.ObtenerPorId(id, usuarioId);
        if (cuenta is null)
            return RedirectToAction("NoEncontrado", "Home");
        var modelo = _mapper.Map<CreadorCuentaViewModel>(cuenta);
        modelo.TiposCuentas = await ObtenerTiposCuentas(usuarioId);
        return View(modelo);
    }

    [HttpGet]
    public async Task<IActionResult> Borrar(int id)
    {
        var usuarioId = _servicioUsuarios.ObtenerUsuarioId();
        var cuenta = await _repoCuentas.ObtenerPorId(id, usuarioId);
        if (cuenta is null)
            return RedirectToAction("NoEncontrado", "Home");
        return View(cuenta);
    }

    [HttpPost]
    public async Task<IActionResult> BorrarCuenta(int id)
    {
        var usuarioId = _servicioUsuarios.ObtenerUsuarioId();
        var cuenta = await _repoCuentas.ObtenerPorId(id, usuarioId);
        if (cuenta is null)
            return RedirectToAction("NoEncontrado", "Home");
        await _repoCuentas.Borrar(id);
        return RedirectToAction("Index");
    }

    private async Task<IEnumerable<SelectListItem>> ObtenerTiposCuentas(int usuarioId)
    {
        var tiposCuentas = await _repoTiposCuentas.Obtener(usuarioId);
        return tiposCuentas.Select(x => new SelectListItem(x.Nombre, x.Id.ToString()));
    }
}
