using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Repository;

namespace RiskManagement
{
    [TestFixture]
    public class ReportRepositoryNUnitTests
    {
        private Mock<ApplicationDBContext> _mockContext;
        private Mock<IMapper> _mockMapper;
        private ReportRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _mockContext = new Mock<ApplicationDBContext>();
            _mockMapper = new Mock<IMapper>();
            _repository = new ReportRepository(_mockContext.Object, _mockMapper.Object);
        }

        [Test]
        public async Task GetAllRisk_NoRiskStatus_ReturnsAllRisks()
        {
            // Arrange
            var risks = new List<Risk>
            {
                new Risk { Id = 1, RiskId = "R001", RiskName = "Risk A", RiskStatus = RiskStatus.open },
                new Risk { Id = 2, RiskId = "R002", RiskName = "Risk B", RiskStatus = RiskStatus.close }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Risk>>();
            mockSet.As<IQueryable<Risk>>().Setup(m => m.Provider).Returns(risks.Provider);
            mockSet.As<IQueryable<Risk>>().Setup(m => m.Expression).Returns(risks.Expression);
            mockSet.As<IQueryable<Risk>>().Setup(m => m.ElementType).Returns(risks.ElementType);
            mockSet.As<IQueryable<Risk>>().Setup(m => m.GetEnumerator()).Returns(risks.GetEnumerator());

            _mockContext.Setup(c => c.Risks).Returns(mockSet.Object);

            // Act
            var result = await _repository.GetAllRisk(null);

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetAllRisk_WithValidRiskStatus_ReturnsFilteredRisks()
        {
            // Arrange
            var risks = new List<Risk>
            {
                new Risk { Id = 1, RiskId = "R001", RiskName = "Risk A", RiskStatus = RiskStatus.open },
                new Risk { Id = 2, RiskId = "R002", RiskName = "Risk B", RiskStatus = RiskStatus.close }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Risk>>();
            mockSet.As<IQueryable<Risk>>().Setup(m => m.Provider).Returns(risks.Provider);
            mockSet.As<IQueryable<Risk>>().Setup(m => m.Expression).Returns(risks.Expression);
            mockSet.As<IQueryable<Risk>>().Setup(m => m.ElementType).Returns(risks.ElementType);
            mockSet.As<IQueryable<Risk>>().Setup(m => m.GetEnumerator()).Returns(risks.GetEnumerator());

            _mockContext.Setup(c => c.Risks).Returns(mockSet.Object);

            // Act
            var result = await _repository.GetAllRisk("close");

            // Assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Risk B", result.First().RiskName);
        }

        [Test]
        public async Task GetAllRiskByDepartmentId_WithValidDepartmentId_ReturnsRisks()
        {
            // Arrange
            var risks = new List<Risk>
            {
                new Risk { Id = 1, DepartmentId = 1, RiskName = "Risk A" },
                new Risk { Id = 2, DepartmentId = 2, RiskName = "Risk B" }
            }.AsQueryable();

            var departments = new List<Department>
            {
                new Department { Id = 1, DepartmentName = "IT" }
            }.AsQueryable();

            var mockRiskSet = new Mock<DbSet<Risk>>();
            mockRiskSet.As<IQueryable<Risk>>().Setup(m => m.Provider).Returns(risks.Provider);
            mockRiskSet.As<IQueryable<Risk>>().Setup(m => m.Expression).Returns(risks.Expression);
            mockRiskSet.As<IQueryable<Risk>>().Setup(m => m.ElementType).Returns(risks.ElementType);
            mockRiskSet.As<IQueryable<Risk>>().Setup(m => m.GetEnumerator()).Returns(risks.GetEnumerator());

            var mockDepartmentSet = new Mock<DbSet<Department>>();
            mockDepartmentSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(departments.Provider);
            mockDepartmentSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(departments.Expression);
            mockDepartmentSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(departments.ElementType);
            mockDepartmentSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(departments.GetEnumerator());

            _mockContext.Setup(c => c.Risks).Returns(mockRiskSet.Object);
            _mockContext.Setup(c => c.Departments).Returns(mockDepartmentSet.Object);

            // Act
            var result = await _repository.GetAllRiskByDepartmentId(1, null);

            // Assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Risk A", result.First().RiskName);
        }

        [Test]
        public async Task GetAllClosedRisk_ReturnsOnlyClosedRisks()
        {
            // Arrange
            var risks = new List<Risk>
            {
                new Risk { Id = 1, RiskName = "Risk A", RiskStatus = RiskStatus.open },
                new Risk { Id = 2, RiskName = "Risk B", RiskStatus = RiskStatus.close }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Risk>>();
            mockSet.As<IQueryable<Risk>>().Setup(m => m.Provider).Returns(risks.Provider);
            mockSet.As<IQueryable<Risk>>().Setup(m => m.Expression).Returns(risks.Expression);
            mockSet.As<IQueryable<Risk>>().Setup(m => m.ElementType).Returns(risks.ElementType);
            mockSet.As<IQueryable<Risk>>().Setup(m => m.GetEnumerator()).Returns(risks.GetEnumerator());

            _mockContext.Setup(c => c.Risks).Returns(mockSet.Object);

            // Act
            var result = await _repository.GetAllClosedRisk();

            // Assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Risk B", result.First().RiskName);
        }

        [Test]
        public async Task GetRisksByUserProjects_WithValidProjectIds_ReturnsMatchingRisks()
        {
            // Arrange
            var risks = new List<Risk>
            {
                new Risk { Id = 1, ProjectId = 1, RiskName = "Risk A" },
                new Risk { Id = 2, ProjectId = 2, RiskName = "Risk B" },
                new Risk { Id = 3, ProjectId = 3, RiskName = "Risk C" }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Risk>>();
            mockSet.As<IQueryable<Risk>>().Setup(m => m.Provider).Returns(risks.Provider);
            mockSet.As<IQueryable<Risk>>().Setup(m => m.Expression).Returns(risks.Expression);
            mockSet.As<IQueryable<Risk>>().Setup(m => m.ElementType).Returns(risks.ElementType);
            mockSet.As<IQueryable<Risk>>().Setup(m => m.GetEnumerator()).Returns(risks.GetEnumerator());

            _mockContext.Setup(c => c.Risks).Returns(mockSet.Object);

            // Act
            var result = await _repository.GetRisksByUserProjects(new List<int> { 1, 3 });

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(r => r.RiskName == "Risk A"));
            Assert.IsTrue(result.Any(r => r.RiskName == "Risk C"));
        }
    }
}
