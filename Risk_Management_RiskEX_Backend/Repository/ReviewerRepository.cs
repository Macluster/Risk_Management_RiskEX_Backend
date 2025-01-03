using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
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

        public async Task<int> AddNewReviewer(ExternalReviewerDTO externalReviewerDTO)
        {

            if (externalReviewerDTO == null || string.IsNullOrWhiteSpace(externalReviewerDTO.FullName) || string.IsNullOrWhiteSpace(externalReviewerDTO.Email))
            {
                throw new ArgumentException("Invalid external reviewer details.");
            }

            var department = await _db.Departments.FindAsync(externalReviewerDTO.DepartmentId);
            if (department == null)
            {
                throw new KeyNotFoundException("Department not found.");
            }

           
            var externalReviewer = new ExternalReviewer
            {
                FullName = externalReviewerDTO.FullName,
                Email = externalReviewerDTO.Email,
                DepartmentId = externalReviewerDTO.DepartmentId
                //Department = department
            };

            _db.ExternalReviewers.Add(externalReviewer);
            await _db.SaveChangesAsync();

            return externalReviewer.Id;
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
