using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Risk_Management_RiskEX_Backend.Services;


namespace RiskManagement
{
    [TestFixture]
    public class EmailServiceTests
    {
        private IConfiguration _configuration;
        private EmailService _emailService;
        private const string TestEmail = "test@example.com";
        private const string TestPassword = "testpassword";
        private const string TestHost = "smtp.example.com";
        private const int TestPort = 587;

        [OneTimeSetUp]
        public void Setup()
        {
            // Create configuration with test values
            var inMemorySettings = new Dictionary<string, string> {
                {"EMAIL_CONFIGURATION:EMAIL", TestEmail},
                {"EMAIL_CONFIGURATION:PASSWORD", TestPassword},
                {"EMAIL_CONFIGURATION:HOST", TestHost},
                {"EMAIL_CONFIGURATION:PORT", TestPort.ToString()}
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _emailService = new EmailService(_configuration);
        }

        [Test]
        public void SendEmail_WithEmptyRecipient_ShouldThrowArgumentException()
        {
            // Arrange
            string receptor = "";
            string subject = "Test Subject";
            string body = "Test Body";

            // Act & Assert
            var exception = Assert.ThrowsAsync<ArgumentException>(async () =>
                await _emailService.SendEmail(receptor, subject, body));
        }

        [Test]
        public void SendEmail_WithNullRecipient_ShouldThrowArgumentNullException()
        {
            // Arrange
            string receptor = null;
            string subject = "Test Subject";
            string body = "Test Body";

            // Act & Assert
            var exception = Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await _emailService.SendEmail(receptor, subject, body));
        }

        [Test]
        public void SendEmail_WithInvalidSmtpSettings_ShouldThrowSmtpException()
        {
            // Arrange
            var invalidSettings = new Dictionary<string, string> {
                {"EMAIL_CONFIGURATION:EMAIL", "invalid@example.com"},
                {"EMAIL_CONFIGURATION:PASSWORD", "wrongpassword"},
                {"EMAIL_CONFIGURATION:HOST", "invalid.host"},
                {"EMAIL_CONFIGURATION:PORT", "587"}
            };

            var invalidConfig = new ConfigurationBuilder()
                .AddInMemoryCollection(invalidSettings)
                .Build();

            var emailService = new EmailService(invalidConfig);
            string receptor = "test@example.com";
            string subject = "Test Subject";
            string body = "Test Body";

            // Act & Assert
            var exception = Assert.ThrowsAsync<SmtpException>(async () =>
                await emailService.SendEmail(receptor, subject, body));
        }

        [Test]
        public void SendEmail_WithInvalidEmailFormat_ShouldThrowFormatException()
        {
            // Arrange
            string recipient = "invalid_email";
            string subject = "Test Subject";
            string body = "Test Body";

            // Act & Assert
            var exception = Assert.ThrowsAsync<FormatException>(async () =>
                await _emailService.SendEmail(recipient, subject, body));
        }

    }
}
