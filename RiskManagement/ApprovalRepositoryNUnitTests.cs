using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Repository;

namespace RiskManagement
{
    [TestFixture]
    public class ApprovalRepositoryNUnitTests
    {
        private ApplicationDBContext _context;
        private ApprovalsRepository _repository;

        [SetUp]
        public void SetUp()
        {
            // Set up in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var httpContextAccessor = new HttpContextAccessor();
            _context = new ApplicationDBContext(options,httpContextAccessor);
            _repository = new ApprovalsRepository(_context);




            // Seed the database with test data
            SeedData();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        private void SeedData()
        {
            var departments = new List<Department>
    {
        new Department { Id = 1, DepartmentName = "IT" },
        new Department { Id = 2, DepartmentName = "HR" }
    };

            var users = new List<User>
    {
        new User { Id = 1, FullName = "John Doe", DepartmentId = 1, Email = "john.doe@example.com" },
        new User { Id = 2, FullName = "Jane Smith", DepartmentId = 2, Email = "jane.smith@example.com" }
    };

            var risks = new List<Risk>
    {
        new Risk
        {
            Id = 1,
            RiskId = "RISK-001",
            RiskName = "Test Risk 1",
            DepartmentId = 1,
            Description = "Test Risk Description",
            RiskType = RiskType.Quality,
            OverallRiskRating = 2,
            PlannedActionDate = DateTime.UtcNow.AddDays(30),
            RiskStatus = RiskStatus.open,
            Impact = "High financial impact if unaddressed", // Required property
            Mitigation = "Implement additional controls to reduce risk" // Required property
        }
    };

            var riskAssessments = new List<RiskAssessment>
    {
        new RiskAssessment
        {
            Id = 1,
            RiskId = 1,
            Review = new Review
            {
                Id = 1,
                ReviewStatus = ReviewStatus.ReviewPending,
                UserId = 1
            }
        }
    };

            _context.Departments.AddRange(departments);
            _context.Users.AddRange(users);
            _context.Risks.AddRange(risks);
            _context.Assessments.AddRange(riskAssessments);

            _context.SaveChanges();
        }

        [Test]
        public async Task GetReviewByRiskIdAsync_ShouldReturnReview_WhenRiskExists()
        {
            // Arrange
            var riskId = 1;

            // Act
            var result = await _repository.GetReviewByRiskIdAsync(riskId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ReviewStatus.ReviewPending, result.ReviewStatus);
        }

        [Test]
        public async Task GetRiskDetailsToReviewAsync_ShouldReturnRisks_WhenReviewStatusIsPending()
        {
            // Act
            var result = await _repository.GetRiskDetailsToReviewAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public async Task GetRisksByReviewerAsync_ShouldReturnRisks_WhenReviewerExists()
        {
            // Arrange
            var userId = 1;

            // Act
            var result = await _repository.GetRisksByReviewerAsync(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public async Task UpdateReviewStatusAsync_ShouldUpdateStatus_WhenRiskExists()
        {
            // Arrange
            var riskId = 1;
            var approvalStatus = "approved";

            // Act
            var result = await _repository.UpdateReviewStatusAsync(riskId, approvalStatus);

            // Assert
            Assert.IsTrue(result);

            var updatedReview = await _repository.GetReviewByRiskIdAsync(riskId);
            Assert.AreEqual(ReviewStatus.ReviewCompleted, updatedReview.ReviewStatus);
        }

        [Test]
        public async Task UpdateReviewCommentByRiskIdAsync_ShouldUpdateComment_WhenRiskExists()
        {
            // Arrange
            var riskId = 1;
            var comments = "Updated comment";

            // Act
            var result = await _repository.UpdateReviewCommentByRiskIdAsync(riskId, comments);

            // Assert
            Assert.IsTrue(result);

            var updatedReview = await _repository.GetReviewByRiskIdAsync(riskId);
            Assert.AreEqual(comments, updatedReview.Comments);
        }
    }
}
