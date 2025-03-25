using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCorreos;
using ProyectoLavacar.Abstraciones.Modelos.ModuloCorreos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ProyectoLavacar.LN.ModuloCorreos
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpClient _cliente;
        private EmailSenderOptions _options;

        public EmailSender()
        {
            _options = ObtenerConfiguracionDeEmailSender();

            _cliente = new SmtpClient
            {
                Host = _options.Host,
                Port = _options.Port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_options.Email, _options.Password),
                EnableSsl = _options.EnableSsl
            };
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var correo = new MailMessage(_options.Email, email, subject, message)
            {
                IsBodyHtml = true
            };
            return _cliente.SendMailAsync(correo);
        }
        private EmailSenderOptions ObtenerConfiguracionDeEmailSender()
        {
            return new EmailSenderOptions
            {
                Port = int.Parse(ConfigurationManager.AppSettings["EmailSender:Port"]),
                Email = ConfigurationManager.AppSettings["EmailSender:Email"],
                EnableSsl = bool.Parse(ConfigurationManager.AppSettings["EmailSender:EnableSsl"]),
                Host = ConfigurationManager.AppSettings["EmailSender:Host"],
                Password = ConfigurationManager.AppSettings["EmailSender:Password"]

            };
        }
    }
}