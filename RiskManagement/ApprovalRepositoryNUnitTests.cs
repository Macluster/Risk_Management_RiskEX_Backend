using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Repository;

namespace RiskManagement
{
    [TestFixture]
    public class ApprovalRepositoryNUnitTests
    {
         
        private ApplicationDBContext _dbContext;
        private ApprovalsRepository _approvalsRepository;

        [SetUp]
        public void SetUp()
        {
            // Setup in-memory database context with EF Core
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "RiskManagementDb")
                .Options;

            var httpContextAccessor = new HttpContextAccessor();


            _dbContext = new ApplicationDBContext(options,httpContextAccessor);
            _approvalsRepository = new ApprovalsRepository(_dbContext);

            // Seed the database with required entities
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            var department = new Department { DepartmentName = "IT" };
            var reviewer = new User { FullName = "John Doe", Department = department };
            var externalReviewer = new ExternalReviewer { FullName = "Jane Smith", Department = department };

            var risk = new Risk
            {
                RiskId = "R123",
                RiskName = "Risk1",
                RiskType = RiskType.Quality,
                Description = "Risk Description",
                OverallRiskRating = 4,
                RiskStatus = RiskStatus.open,
                Department = department,
                PlannedActionDate = DateTime.Now
            };

            var riskAssessment = new RiskAssessment
            {
                Risk = risk,
                Review = new Review
                {
                    User = reviewer,
                    ExternalReviewer = externalReviewer,
                    ReviewStatus = ReviewStatus.ReviewPending
                }
            };

            _dbContext.Risks.Add(risk);
            _dbContext.Assessments.Add(riskAssessment);
            _dbContext.SaveChanges();
        }

        [Test]
        public async Task GetReviewByRiskIdAsync_Returns_Review_When_RiskId_Is_Valid()
        {
            // Arrange
            var riskId = 1; // Assuming the risk ID seeded is 1

            // Act
            var result = await _approvalsRepository.GetReviewByRiskIdAsync(riskId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(ReviewStatus.ReviewPending, result.ReviewStatus);
        }

        [Test]
        public async Task GetRiskDetailsToReviewAsync_Returns_RiskDetails_When_ReviewStatus_Is_Pending()
        {
            // Act
            var result = await _approvalsRepository.GetRiskDetailsToReviewAsync();

            // Assert
            Assert.IsNotEmpty(result);
            Assert.AreEqual("Risk1", result.First().RiskName);
            Assert.AreEqual("IT", result.First().RiskDepartment);
        }

        [Test]
        public async Task GetRisksByReviewerAsync_Returns_Risks_For_Specific_Reviewer()
        {
            // Arrange
            var userId = 1; // Assuming reviewer ID is 1

            // Act
            var result = await _approvalsRepository.GetRisksByReviewerAsync(userId);

            // Assert
            Assert.IsNotEmpty(result);
            Assert.AreEqual("Risk1", result.First().RiskName);
        }

        [Test]
        public async Task UpdateReviewStatusAsync_Updates_Status_When_Valid_Status_Is_Provided()
        {
            // Arrange
            var riskId = 1; // Assuming risk ID 1 is valid
            var approvalStatus = "approved"; // valid status

            // Act
            var result = await _approvalsRepository.UpdateReviewStatusAsync(riskId, approvalStatus);

            // Assert
            Assert.IsTrue(result);

            // Verify the status update
            var review = await _approvalsRepository.GetReviewByRiskIdAsync(riskId);
            Assert.AreEqual(ReviewStatus.ReviewCompleted, review.ReviewStatus);
        }

        [Test]
        public async Task UpdateReviewStatusAsync_Returns_False_When_Review_Not_Found()
        {
            // Arrange
            var riskId = 9999; // Invalid riskId
            var approvalStatus = "approved";

            // Act
            var result = await _approvalsRepository.UpdateReviewStatusAsync(riskId, approvalStatus);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task UpdateReviewCommentByRiskIdAsync_Updates_Comment_When_Valid_RiskId_Is_Provided()
        {
            // Arrange
            var riskId = 1; // Assuming risk ID 1 is valid
            var comments = "Updated comments";

            // Act
            var result = await _approvalsRepository.UpdateReviewCommentByRiskIdAsync(riskId, comments);

            // Assert
            Assert.IsTrue(result);

            // Verify the comment update
            var review = await _approvalsRepository.GetReviewByRiskIdAsync(riskId);
            Assert.AreEqual(comments, review.Comments);
        }

        [Test]
        public async Task UpdateReviewCommentByRiskIdAsync_Returns_False_When_Review_Not_Found()
        {
            // Arrange
            var riskId = 9999; // Invalid riskId
            var comments = "Updated comments";

            // Act
            var result = await _approvalsRepository.UpdateReviewCommentByRiskIdAsync(riskId, comments);

            // Assert
            Assert.IsFalse(result);
        }

        [TearDown]
        public void TearDown()
        {
            
            _dbContext.Dispose();
        }
    }
}
