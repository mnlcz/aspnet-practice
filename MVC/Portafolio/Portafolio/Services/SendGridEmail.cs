using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Services;

public class SendGridEmail : IEmail
{
    private readonly IConfiguration configuration;

    public SendGridEmail(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task Enviar(ContactoViewModel contacto)
    {
        var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
        var email1 = configuration.GetValue<string>("SENDGRID_FROM");
        var email2 = configuration.GetValue<string>("SENDGRID_TO");
        var nombre = configuration.GetValue<string>("SENDGRID_NOMBRE");

        var cliente = new SendGridClient(apiKey);
        var from = new EmailAddress(email1, nombre);
        var subject = $"El cliente {contacto.Email} quiere contactarte";
        var to = new EmailAddress(email2, nombre);
        var mensajeTextoPlano = contacto.Mensaje;
        var contenidoHtml = $@"De: {contacto.Nombre}
Email: {contacto.Email}
Mensaje: {contacto.Mensaje}";
        var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, mensajeTextoPlano, contenidoHtml);
        var respuesta = await cliente.SendEmailAsync(singleEmail);
    }
}
