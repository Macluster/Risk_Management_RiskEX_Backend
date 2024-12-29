using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IRiskRepository
    {
        Task<ICollection<Risk>> GetRisksByType(RiskType risktype);
        Task<IEnumerable<Risk>> GetRisksByReviewerIdAsync(int? userId, int? externalReviewerId);
    }
}
