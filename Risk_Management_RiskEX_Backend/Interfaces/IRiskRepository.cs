using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IRiskRepository
    {

        Task<ICollection<Risk>> GetRisksByType(RiskType risktype);
        //Task<IEnumerable<Risk>> GetRisksByReviewerIdAsync(int userId);

        Task<Object> GetRiskById(int id);
     
        //Task<IEnumerable<ApprovalDTO>> GetRisksByReviewerAsync(int? userId);

       
        //Task<IEnumerable<ApprovalDTO>> GetRisksByReviewerAsync(int userId);
        //Task<IEnumerable<ApprovalDTO>> GetRisksByReviewerAsync(int? userId);


        Task<Risk> AddQualityRiskAsync(RiskDTO riskDto);
        Task<Risk> AddSecurityOrPrivacyRiskAsync(RiskDTO riskDto);


        //Task<Object> GetRiskById(int id);
        Task<Object> GetMitigationStatusOfARisk(int id);

        Task<Risk> EditQualityRiskAsync(int id, RiskDTO riskDto);
        Task<Risk> EditSecurityOrPrivacyRiskAsync(int id, RiskDTO riskDto);
        Task<Risk> UpdateQualityRiskAsync(int riskId, RiskUpdateDTO riskUpdateDto);
        Task<Risk> UpdateSecurityOrPrivacyRiskAsync(int riskId, RiskUpdateDTO riskUpdateDto);
        Task<ICollection<RiskCategoryCountDTO>> GetRiskCategoryCountsByDepartments(List<int> departmentIds, List<int> projectids);
        Task<Object> GetRiskByAssigneeId(int id);
        Task<Object> RiskApproachingDeadline(List<int> departmentIds, List<int> projectids);
        Task<Object> GetRiskWithHeighestOverallRationg(List<int> departmentIds, List<int> projectids);
        Task<ICollection<OpenRiskCountByTypeDTO>> GetOpenRiskCountByType(List<int> departmentIds, List<int> projectids);
        Task<ICollection<RiskCategoryCountDTO>> GetRiskCategoryCounts(int?id);
        Task<object> GetAllRiskAssigned();

        Task<string> SetAndGetRiskIdAsync(int ?departmentId, int? projectId);



    }

      

 
    
}
