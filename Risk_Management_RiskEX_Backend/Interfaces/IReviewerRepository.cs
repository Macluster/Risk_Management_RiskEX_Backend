using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IReviewerRepository
    {
        Task<List<ReviewerDTO>> GetAllReviewersAsync();
        Task<int> AddNewReviewer(ExternalReviewerDTO externalReviewerDTO);

    }
}
