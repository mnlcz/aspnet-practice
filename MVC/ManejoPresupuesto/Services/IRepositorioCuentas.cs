using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Services;

public interface IRepositorioCuentas
{
    Task Crear(Cuenta cuenta);
}