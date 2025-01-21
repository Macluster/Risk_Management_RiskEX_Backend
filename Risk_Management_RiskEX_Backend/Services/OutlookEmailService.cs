//using System.Net.Mail;
//using System.Net;
//using Risk_Management_RiskEX_Backend.Interfaces;

//namespace Risk_Management_RiskEX_Backend.Services
//{
//    public class OutlookEmailService : IEmailService
//    {
//        private readonly IConfiguration configuration;
//        public OutlookEmailService(IConfiguration configuration)
//        {
//            this.configuration = configuration;

//        }
//        public async Task SendEmail(string receptor, string subject, string body)
//        {
//            // Retrieve email configuration from appsettings.json
//            var email = configuration.GetValue<string>("EMAIL_CONFIGURATION:EMAIL");
//            var password = configuration.GetValue<string>("EMAIL_CONFIGURATION:PASSWORD");
//            var host = configuration.GetValue<string>("EMAIL_CONFIGURATION:HOST");
//            var port = configuration.GetValue<int>("EMAIL_CONFIGURATION:PORT");

//            try
//            {
//                // Configure the SMTP client for Outlook 365
//                using var smtpClient = new SmtpClient(host, port)
//                {
//                    EnableSsl = true, // Outlook requires STARTTLS
//                    UseDefaultCredentials = false, 
//                    Credentials = new NetworkCredential(email, password) 
//                };

               
//                var message = new MailMessage(email, receptor, subject, body)
//                {
//                    IsBodyHtml = true 
//                };

//                await smtpClient.SendMailAsync(message);
//            }
//            catch (Exception ex)
//            {
//                // Log the exception or handle it as needed
//                throw new Exception("Failed to send email using Outlook 365.", ex);
//            }
//        }

//    }
//}
