using System.Net;
using System.Net.Mail;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;
        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
            
        }
        public async Task SendEmail(string receptor,string subject,string body) 
        {
            var email = configuration.GetValue<string>("EMAIL_CONFIGURATION:EMAIL");
            var password = configuration.GetValue<string>("EMAIL_CONFIGURATION:PASSWORD");
            var host = configuration.GetValue<string>("EMAIL_CONFIGURATION:HOST");
            var port = configuration.GetValue<int>("EMAIL_CONFIGURATION:PORT");

            var smtpClient = new SmtpClient(host,port);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            string emaill = Environment.GetEnvironmentVariable("EMAIL");
            string passwordd = Environment.GetEnvironmentVariable("PASSWORD");
            smtpClient.Credentials =  new NetworkCredential(emaill, passwordd);
         

            var message = new MailMessage(emaill!, receptor, subject, body);
            message.IsBodyHtml = true;
            await smtpClient.SendMailAsync(message);


        }

       


    }
}
