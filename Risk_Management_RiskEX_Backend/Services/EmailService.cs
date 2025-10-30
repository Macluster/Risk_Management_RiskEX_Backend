using System.Net;
using System.Net.Mail;
using Risk_Management_RiskEX_Backend.Interfaces;

namespace Risk_Management_RiskEX_Backend.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task SendEmail(string receptor, string subject, string body)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(receptor))
                {
                    throw new ArgumentException("Receptor email cannot be null or empty", nameof(receptor));
                }

                if (string.IsNullOrWhiteSpace(subject))
                {
                    throw new ArgumentException("Subject cannot be null or empty", nameof(subject));
                }

                if (string.IsNullOrWhiteSpace(body))
                {
                    throw new ArgumentException("Body cannot be null or empty", nameof(body));
                }

                // Get configuration
                var host = _configuration.GetValue<string>("EMAIL_CONFIGURATION:HOST");
                var port = _configuration.GetValue<int>("EMAIL_CONFIGURATION:PORT");
                var email = Environment.GetEnvironmentVariable("EMAIL");
                var password = Environment.GetEnvironmentVariable("PASSWORD");

                // Log configuration (without sensitive data)
                _logger.LogInformation($"Email configuration - Host: {host}, Port: {port}, From: {email}");

                // Validate configuration
                if (string.IsNullOrWhiteSpace(host))
                {
                    throw new InvalidOperationException("EMAIL_CONFIGURATION:HOST is not configured");
                }

                if (port == 0)
                {
                    throw new InvalidOperationException("EMAIL_CONFIGURATION:PORT is not configured");
                }

                if (string.IsNullOrWhiteSpace(email))
                {
                    throw new InvalidOperationException("EMAIL environment variable is not set");
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    throw new InvalidOperationException("PASSWORD environment variable is not set");
                }

                // Create SMTP client
                using var smtpClient = new SmtpClient(host, port)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(email, password),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Timeout = 30000 // 30 seconds timeout
                };

                // Create message
                using var message = new MailMessage(email, receptor, subject, body)
                {
                    IsBodyHtml = true
                };

                _logger.LogInformation($"Attempting to send email to: {receptor}");

                // Send email
                await smtpClient.SendMailAsync(message);

                _logger.LogInformation($"Email sent successfully to: {receptor}");
            }
            catch (SmtpException ex)
            {
                _logger.LogError($"SMTP Error sending email to {receptor}: {ex.Message}");
                _logger.LogError($"SMTP Status Code: {ex.StatusCode}");
                throw new InvalidOperationException($"Failed to send email: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending email to {receptor}: {ex.Message}");
                throw;
            }
        }
    }
}