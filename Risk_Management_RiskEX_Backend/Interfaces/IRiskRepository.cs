using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IRiskRepository
    {
        Task<ICollection<Risk>> GetRisksByType(string type);

        Task<Risk> AddQualityRiskAsync(RiskDTO riskDto);
        Task<Risk> AddSecurityOrPrivacyRiskAsync(RiskDTO riskDto);

        Task<Object> GetRiskById(int id);
        Task<Object> GetMitigationStatusOfARisk(int id);

        Task<Risk> EditQualityRiskAsync(int id, RiskDTO riskDto);
        Task<Risk> EditSecurityOrPrivacyRiskAsync(int id, RiskDTO riskDto);
        Task<Risk> UpdateQualityRiskAsync(int riskId, RiskUpdateDTO riskUpdateDto);

        Task<Risk> UpdateSecurityOrPrivacyRiskAsync(int riskId, RiskUpdateDTO riskUpdateDto);


    }
}
