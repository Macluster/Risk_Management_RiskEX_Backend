using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<ReportDTO>> GetAllRisk(String riskStatus);
        Task<IEnumerable<ReportDTO>> GetAllRiskByDepartmentId(int id, String riskStatus);
        Task<IEnumerable<ReportDTO>> GetAllClosedRisk();
        Task<List<ReportDTO>> GetRisksByUserProjects(List<int> projectIds);
        //Task<int>  GetLastestRiskId();
    }
}
