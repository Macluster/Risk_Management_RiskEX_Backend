using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Repository;
using Microsoft.AspNetCore.Http;


namespace Risk_Management_RiskEX_Backend.Tests
{
    [TestFixture]
    public class DepartmentRepositoryTests
    {
        private ApplicationDBContext _dbContext;
        private IMapper _mapper;
        private DepartmentRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
                .Options;

            var httpContextAccessor = new HttpContextAccessor();

            _dbContext = new ApplicationDBContext(options, httpContextAccessor);

            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<DepartmentDTO, Department>()
                   .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Name)));
            _mapper = config.CreateMapper();

            _repository = new DepartmentRepository(_dbContext, _mapper);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        [Test]
        public async Task GetAllDepartments_WhenDepartmentsExist_ReturnsAllDepartments()
        {
            // Arrange
            var departments = new[]
            {
            new Department { DepartmentName = "HR" },
            new Department { DepartmentName = "IT" }
        };
            await _dbContext.Departments.AddRangeAsync(departments);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllDepartments();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(2));
            CollectionAssert.AreEquivalent(
                departments.Select(d => d.DepartmentName),
                result.Select(d => d.DepartmentName)
            );
        }

        [Test]
        public async Task GetAllDepartments_WhenNoDepartments_ReturnsEmptyList()
        {
            var result = await _repository.GetAllDepartments();
            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task AddDepartment_WhenDepartmentDoesNotExist_ReturnsTrue()
        {
            // Arrange
            var departmentDto = new DepartmentDTO { Name = "Finance" };

            // Act
            var result = await _repository.AddDepartment(departmentDto);
            var savedDepartment = await _dbContext.Departments
                .FirstOrDefaultAsync(d => d.DepartmentName == departmentDto.Name);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(savedDepartment, Is.Not.Null);
                Assert.That(savedDepartment.DepartmentName, Is.EqualTo(departmentDto.Name));
            });
        }

        [Test]
        public async Task AddDepartment_WhenDepartmentExists_ReturnsFalse()
        {
            // Arrange
            var existingDepartment = new Department { DepartmentName = "HR" };
            await _dbContext.Departments.AddAsync(existingDepartment);
            await _dbContext.SaveChangesAsync();

            var departmentDto = new DepartmentDTO { Name = "HR" };

            // Act
            var result = await _repository.AddDepartment(departmentDto);

            // Assert
            Assert.That(result, Is.False);
            Assert.That(await _dbContext.Departments.CountAsync(), Is.EqualTo(1));
        }

        [Test]
        public void AddDepartment_ShouldThrowException_WhenErrorOccurs()
        {
            // Arrange
            var invalidDepartmentDto = new DepartmentDTO { Name = null };

            // Act & Assert
            var exception = Assert.ThrowsAsync<ArgumentException>(async () => await _repository.AddDepartment(invalidDepartmentDto));

            // Assert
            Assert.AreEqual("Department name cannot be null or empty.", exception.Message);
        }
    }
}