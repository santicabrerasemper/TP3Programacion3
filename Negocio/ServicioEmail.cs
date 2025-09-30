using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ServicioEmail
    {
        private MailMessage email;
        private SmtpClient server;


        public ServicioEmail()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("", "");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@ecommerceprogra");
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = "<h1> Gracias por participar  </h1> <br>Ya estas inscripto...</br>";

        }

        public void enviarEmail ()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
