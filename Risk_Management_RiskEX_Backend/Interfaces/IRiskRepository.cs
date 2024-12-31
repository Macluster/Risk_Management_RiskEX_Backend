using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IRiskRepository
    {
        Task<ICollection<Risk>> GetRisksByType(string type);
        Task<Object> GetRiskById(int id);
        Task<Object> GetMitigationStatusOfARisk(int id);       
        Task<ICollection<int>> GetOverallRiskRating();
        Task<Object> GetOverallRiskRating(int id);


  }
}
