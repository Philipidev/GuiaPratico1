using System.Net;
using System.Net.Mail;

namespace GuiaPraticoRedes.Services
{
    public static class EmailService
    {
        private static string Email = "xxxxxxx@gmail.com";
        private  static string Senha = "xxxxxxxxxxxx";

        public static bool EnviarEmail(string To, string Subject, string Body)
        {
            try
            {
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Email, Senha)
                };
                using (var message = new MailMessage(Email, To)
                {
                    Subject = Subject,
                    Body = Body
                })
                {
                    smtp.Send(message);
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
