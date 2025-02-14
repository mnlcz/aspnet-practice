using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Services;

public interface IRepositorioTiposCuentas
{
    Task Crear(TipoCuenta tipoCuenta);
    Task<bool> Existe(string nombre, int usuarioId);
}
