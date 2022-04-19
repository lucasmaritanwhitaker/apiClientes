using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;

namespace APICliente.Controllers
{
    public class EmailController : Controller
    {
        public bool SendEmail(string email)
        {
            try
            {
                MailMessage _emailMessage = new()
                {
                    //Remetente
                    From = new MailAddress("testessmn@outlook.com")
                };

                //Setando o destinatário:
                //Mensagem
                _emailMessage.CC.Add(email);
                _emailMessage.Subject = "Cadastro SMN";
                _emailMessage.IsBodyHtml = true;
                _emailMessage.Body = "<b>Seu CADASTRO foi realizado</b><p>Parabéns, você acaba de concluir o seu cadastro</p>";

                //Config Porta
                SmtpClient _smptCliente = new("smtp.office365.com", Convert.ToInt32("587"));

                //Config S/ Porta
                _smptCliente.UseDefaultCredentials = false;
                _smptCliente.Credentials = new NetworkCredential("testessmn@outlook.com", "testesmn$310700");

                _smptCliente.EnableSsl = true;

                _smptCliente.Send(_emailMessage);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}