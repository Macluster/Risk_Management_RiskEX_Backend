using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IApprovalRepository
    {
        Task<IEnumerable<ApprovalDTO>> GetRisksByReviewerAsync(int? userId);
        Task<IEnumerable<RiskDetailsDTO>> GetRiskDetailsToReviewAsync();
        Task<IEnumerable<Review>> GetReviewByRiskIdAsync(int riskId);
        Task<bool> UpdateReviewStatusAsync(int riskId, string approvalStatus);
        Task<bool> UpdateReviewCommentByRiskIdAsync(int riskId, string comments);
        Task<Review> GetReviewBasedPostOrPre(int riskId, bool isMitigated);

    }
}
