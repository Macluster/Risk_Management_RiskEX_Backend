﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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


        public async Task<List<ReviewerDTO>> GetAllReviewersAsync([FromServices] IHttpContextAccessor httpContextAccessor)
        {
            // Get the current user's role from the token
            var currentUserRole = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;

            if (currentUserRole?.ToLower() == "admin")
            {
                return new List<ReviewerDTO>();  
            }

            var users = await _db.Users
                .Where(u => u.IsActive
                    && !u.Email.ToLower().Contains("admin"))
                .Select(u => new ReviewerDTO
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email,
                    Type = "Internal"
                })
                .ToListAsync();

            var externalReviewers = await _db.ExternalReviewers
                .Where(er => !er.Email.ToLower().Contains("admin"))
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

        public async Task<List<ReviewerDTO>> getthereviwer(int id)
        {
            if (id == null)
            {
                return new List<ReviewerDTO>();
            }

            var reviewers = await _db.Risks
                .Where(r => r.Id == id)
                .Include(r => r.RiskAssessments)
                    .ThenInclude(a => a.Review)
                .SelectMany(r => r.RiskAssessments) 
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
