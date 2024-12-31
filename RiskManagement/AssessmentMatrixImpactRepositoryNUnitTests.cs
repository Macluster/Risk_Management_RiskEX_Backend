using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Repository;

namespace RiskManagement
{
    [TestFixture]
    public class AssessmentMatrixImpactRepositoryNUnitTests
    {
        private ApplicationDBContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDBContext(options);

            // Seed data
            context.AssessmentsMatrixImpact.AddRange(
                new AssessmentMatrixImpact
                {
                    Id = 1,
                    AssessmentFactor = "Low",
                    Impact = 10.0,
                    Definition = "No/slight effect on business",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixImpact
                {
                    Id = 2,
                    AssessmentFactor = "Medium",
                    Impact = 20.0,
                    Definition = "business objectives affected",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixImpact
                {
                    Id = 3,
                    AssessmentFactor = "High",
                    Impact = 40.0,
                    Definition = "business objectives undermined",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new AssessmentMatrixImpact
                {
                    Id = 4,
                    AssessmentFactor = "Critical",
                    Impact = 60.0,
                    Definition = "business objectives not accomplished",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            context.SaveChanges();
            return context;
        }

        [Test]
        public async Task GetAllImpactData_ShouldReturnAllRecords()
        {
            // Arrange
            var dbContext = CreateInMemoryDbContext();
            var repository = new AssessmentMatrixImpactRepository(dbContext);

            // Act
            var result = await repository.GetAllImpactData();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(4, result.Count); // Verify we get all seeded records
        }

        [Test]
        public async Task GetAllImpactData_ShouldReturnCorrectData()
        {
            // Arrange
            var dbContext = CreateInMemoryDbContext();
            var repository = new AssessmentMatrixImpactRepository(dbContext);

            // Act
            var result = await repository.GetAllImpactData();

            // Assert
            Assert.IsTrue(result.Any(r => r.AssessmentFactor == "Low" && r.Impact == 10.0));
            Assert.IsTrue(result.Any(r => r.AssessmentFactor == "Medium" && r.Impact == 20.0));
            Assert.IsTrue(result.Any(r => r.AssessmentFactor == "High" && r.Impact == 40.0));
            Assert.IsTrue(result.Any(r => r.AssessmentFactor == "Critical" && r.Impact == 60.0));
        }

        [Test]
        public async Task GetAllImpactData_ShouldHandleEmptyDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var dbContext = new ApplicationDBContext(options);
            var repository = new AssessmentMatrixImpactRepository(dbContext);

            // Act
            var result = await repository.GetAllImpactData();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(0, result.Count); // No records in database
        }

    }
}
