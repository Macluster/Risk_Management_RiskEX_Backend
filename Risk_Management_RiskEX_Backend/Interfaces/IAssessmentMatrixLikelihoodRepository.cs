using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IAssessmentMatrixLikelihoodRepository
    {
        Task<ICollection<AssessmentMatrixLikelihood>> GetAllLikelyHoodData();
    }
}
