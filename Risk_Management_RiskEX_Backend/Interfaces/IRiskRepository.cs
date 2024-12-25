using RiskManagement_Department_API.Models;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IRiskRepository
    {

        Task<Risk> getRiskById(int id);

        Task<Object> addRisk(Risk risk);
    }
}
