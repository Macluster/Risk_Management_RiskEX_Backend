namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IEmailRepository
    {
        Task<bool> SendAssignmentEmailAsync(int riskId);
        Task<(string FullName, string Email)> GetResponsibleUserDetailsAsync(int riskId);
    }
}
