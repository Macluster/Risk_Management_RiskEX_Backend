using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly ApplicationDBContext _db;

        public ReviewerRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<ReviewerDTO>> GetAllReviewersAsync()
        {
            var users = await _db.Users
                .Where(u => u.IsActive)
                .Select(u => new ReviewerDTO
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email,
                    Type = "Internal"
                })
                .ToListAsync();

            var externalReviewers = await _db.ExternalReviewers
                .Select(er => new ReviewerDTO
                {
                    Id = er.Id,
                    FullName = er.FullName,
                    Email = er.Email,
                    Type = "External"
                })
                .ToListAsync();

            return users.Concat(externalReviewers).ToList();
        }
    }
}
