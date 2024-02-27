using Portafolio.Models;

namespace Portafolio.Services;

public interface IEmail
{
    Task Enviar(ContactoViewModel contacto);
}
