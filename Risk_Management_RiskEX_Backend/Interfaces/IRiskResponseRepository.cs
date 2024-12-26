using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IRiskResponseRepository
    {
        Task<ICollection<RiskResponseData>> GedtAllRiskResponse();
    }
}
