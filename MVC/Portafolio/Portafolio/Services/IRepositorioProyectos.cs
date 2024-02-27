using Portafolio.Models;

namespace Portafolio.Services;

public interface IRepositorioProyectos
{
    List<ProyectoViewModel> ObtenerProyectos();
}
