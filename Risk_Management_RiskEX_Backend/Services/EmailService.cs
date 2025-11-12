using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Risk_Management_RiskEX_Backend.Interfaces;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;
    private readonly ILogger<EmailService> _logger;
    private readonly HttpClient _httpClient;

    public EmailService(IConfiguration config, ILogger<EmailService> logger)
    {
        _config = config;
        _logger = logger;
        _httpClient = new HttpClient();
    }

    public async Task SendEmail(string receptor, string subject, string body)
    {
        var apiKey = Environment.GetEnvironmentVariable("EMAIL");
        var secretKey = Environment.GetEnvironmentVariable("PASSWORD");

        var payload = new
        {
            Messages = new[]
            {
                new
                {
                    From = new { Email = "riskex@experionglobal.com", Name = "RiskEX System" },
                    To = new[] { new { Email = receptor } },
                    Subject = subject,
                    HTMLPart = body
                }
            }
        };

        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mailjet.com/v3.1/send")
        {
            Content = JsonContent.Create(payload)
        };

        var authToken = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{apiKey}:{secretKey}"));
        request.Headers.Add("Authorization", $"Basic {authToken}");

        var response = await _httpClient.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError($"Mailjet API Error: {result}");
            throw new Exception($"Failed to send email. Response: {result}");
        }

        _logger.LogInformation($"Mail sent successfully to {receptor}");
    }
}
