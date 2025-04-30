using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;
using System.Threading.Tasks;
using Risk_Management_RiskEX_Backend.config;

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
            // Input validation
            if (string.IsNullOrWhiteSpace(externalReviewerDTO.Email))
            {
                //_logger.LogError("User email cannot be empty.");
                return 0;
            }

            // Check for existing user
            var existingUser = await _db.Users.FirstOrDefaultAsync(u => u.Email == externalReviewerDTO.Email);
            if (existingUser != null)
            {
                //_logger.LogError($"User with email {userDto.Email} already exists.");
                throw new InvalidOperationException("Reviewer with the same email already exists.");
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


        public async Task<List<ReviewerDTO>> GetAllReviewersAsync([FromServices] IHttpContextAccessor httpContextAccessor)
        {


            var users = await _db.Users
                .Where(u => !GlobalConfig.AdminEmails.Contains(u.Email))
                .Select(u => new ReviewerDTO
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email,
                    Type = "Internal",
                    IsActive = u.IsActive // Show actual status
                })
                .ToListAsync();

            var externalReviewers = await _db.ExternalReviewers
                .Where(er => !GlobalConfig.AdminEmails.Contains(er.Email))
                .Select(er => new ReviewerDTO
                {
                    Id = er.Id,
                    FullName = er.FullName,
                    Email = er.Email,
                    Type = "External",
                    IsActive = true // Always set true for external
                })
                .ToListAsync();

            return users.Concat(externalReviewers).ToList();
        }

        public async Task<List<ReviewerDTO>> getthereviwer(int id, string reviewStatus)
        {
            if (id == null)
            {
                return new List<ReviewerDTO>();
            }
            if (!Enum.TryParse(reviewStatus, true, out ReviewStatus status))
            {
                throw new ArgumentException($"Invalid RiskType value: {reviewStatus}");
            }

            var reviewers = await _db.Risks
                .Where(r => r.Id == id)
                .Include(r => r.RiskAssessments)
                    .ThenInclude(a => a.Review)
                .SelectMany(r => r.RiskAssessments)
                .Where(a => a.Review != null && a.Review.ReviewStatus == status)
                .Select(review => new ReviewerDTO
                {
                    Id = review.Review.Id,
                   
                    FullName = review.Review.UserId == null
                        ? review.Review.ExternalReviewer.FullName
                        : review.Review.User.FullName, 
                    Email = review.Review.UserId == null
                        ? review.Review.ExternalReviewer.Email
                        : review.Review.User.Email, 
                    Type = review.Review.UserId == null ? "External" : "Internal"
      
                })
                .Distinct()
                .ToListAsync();

            return reviewers;

        }
    }
}
