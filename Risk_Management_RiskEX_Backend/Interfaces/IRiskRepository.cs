using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IRiskRepository
    {

        Task<ICollection<Risk>> GetRisksByType(RiskType risktype);
        //Task<IEnumerable<Risk>> GetRisksByReviewerIdAsync(int userId);
        Task<Object> GetRiskById(int id);
        //Task<IEnumerable<ApprovalDTO>> GetRisksByReviewerAsync(int userId);
        Task<IEnumerable<ApprovalDTO>> GetRisksByReviewerAsync(int? userId);

        Task<Risk> AddQualityRiskAsync(RiskDTO riskDto);
        Task<Risk> AddSecurityOrPrivacyRiskAsync(RiskDTO riskDto);

        Task<Object> GetMitigationStatusOfARisk(int id);       
        Task<ICollection<int>> GetOverallRiskRating();
        Task<Object> GetOverallRiskRating(int id);
        Task<Object> GetRiskByAssigneeId(int id);


    }
}
