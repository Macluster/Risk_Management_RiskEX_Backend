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
        Task<ICollection<int>> GetOverallRiskRating();
        Task<Object> GetOverallRiskRating(int id);
        Task<ICollection<RiskCategoryCountDTO>> GetRiskCategoryCounts();
        Task<ICollection<OpenRiskCountByTypeDTO>>GetOpenRiskCountByType();
        Task<ICollection<RiskCategoryCountDTO>> GetRiskCategoryCountsByDepartments(List<int> departmentIds);




  }
}
