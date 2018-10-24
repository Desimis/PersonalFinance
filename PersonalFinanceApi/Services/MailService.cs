using PersonalFinanceApi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using PersonalFinanceApi.Interfaces;

namespace PersonalFinanceApi.Services
{
    public class MailService : IMailService
    {
        public MailService()
        {

        }

        public async Task<bool> SendMail(string from, string to, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage(from, to);
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                mail.Subject = subject;
                mail.Body = body;
                await client.SendMailAsync(mail);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
