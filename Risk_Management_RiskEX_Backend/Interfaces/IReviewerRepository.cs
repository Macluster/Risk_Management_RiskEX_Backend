using Microsoft.AspNetCore.Mvc;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Interfaces
{
    public interface IReviewerRepository
    {
        Task<List<ReviewerDTO>> GetAllReviewersAsync([FromServices] IHttpContextAccessor httpContextAccessor);
        Task<int> AddNewReviewer(ExternalReviewerDTO externalReviewerDTO);
        Task<List<ReviewerDTO>> getthereviwer(int id,string reviewStatus);

    }
}
