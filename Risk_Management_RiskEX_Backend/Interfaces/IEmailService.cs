using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(string receptor, string subject, string body);
    }
}
