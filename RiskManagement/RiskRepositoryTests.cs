//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Risk_Management_RiskEX_Backend.Data;
//using Risk_Management_RiskEX_Backend.Models;
//using Risk_Management_RiskEX_Backend.Repository;

//namespace RiskManagement
//{
//    [TestFixture]
//    public class RiskRepositoryTests
//    {
//        private ApplicationDBContext _context;
//        private RiskRepository _repository;

//        [OneTimeSetUp]
//        public void OneTimeSetUp()
//        {
//            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
//                .UseInMemoryDatabase(databaseName: "TestRiskDb")
//                .Options;

//            _context = new ApplicationDBContext(options);
//            _repository = new RiskRepository(_context);
//        }

//        [SetUp]
//        public async Task SetUp()
//        {
//            // Clear the database before each test
//            await _context.Database.EnsureDeletedAsync();
//            await _context.Database.EnsureCreatedAsync();
//        }


//        [Test]
//        public async Task GetRisksByType_InvalidType_ThrowsArgumentException()
//        {
//            // Act & Assert
//            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
//                await _repository.GetRisksByType("InvalidType"));

//            Assert.That(ex.Message, Is.EqualTo("Invalid RiskType value: InvalidType"));
//        }

//        [Test]
//        public async Task GetRisksByType_EmptyDatabase_ReturnsEmptyList()
//        {
//            // Act
//            var result = await _repository.GetRisksByType("Quality");

//            // Assert
//            Assert.That(result, Is.Not.Null);
//            Assert.That(result, Is.Empty);
//        }

//        [Test]
//        public async Task GetRisksByType_CaseInsensitive_ReturnsMatchingRisks()
//        {
//            // Arrange
//            var risks = new[]
//     {
//        new Risk
//        {
//            Id = 1,
//            RiskId = "R001",
//            RiskName = "Risk 1",
//            RiskType = RiskType.Quality,
//            Description = "Description of Risk 1",
//            Impact = "Impact of Risk 1",
//            Mitigation = "Mitigation for Risk 1",
//            Contingency = "Contingency for Risk 1",
//            Remarks = "Remarks for Risk 1"
//        },
//        new Risk
//        {
//            Id = 2,
//            RiskId = "R002",
//            RiskName = "Risk 2",
//            RiskType = RiskType.Quality,
//            Description = "Description of Risk 2",
//            Impact = "Impact of Risk 2",
//            Mitigation = "Mitigation for Risk 2",
//            Contingency = "Contingency for Risk 2",
//            Remarks = "Remarks for Risk 2"
//        },
//        new Risk
//        {
//            Id = 3,
//            RiskId = "R003",
//            RiskName = "Risk 3",
//            RiskType = RiskType.Privacy,
//            Description = "Description of Risk 3",
//            Impact = "Impact of Risk 3",
//            Mitigation = "Mitigation for Risk 3",
//            Contingency = "Contingency for Risk 3",
//            Remarks = "Remarks for Risk 3"
//        }
//    };

//            await _context.Risks.AddRangeAsync(risks);
//            await _context.SaveChangesAsync();

//            // Act
//            var result = await _repository.GetRisksByType("quality");

//            // Assert
//            Assert.That(result, Is.Not.Null);
//            Assert.That(result.Count, Is.EqualTo(2));
//            Assert.That(result.All(r => r.RiskType == RiskType.Quality), Is.True);
//        }

//        [OneTimeTearDown]
//        public void TearDown()
//        {
//            _context.Dispose();
//        }
//    }
//}
