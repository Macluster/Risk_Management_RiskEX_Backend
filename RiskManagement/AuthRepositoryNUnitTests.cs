using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Risk_Management_RiskEX_Backend.config;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Repository;
using Risk_Management_RiskEX_Backend.Services;

namespace RiskManagement
{
    [TestFixture]
    public class AuthRepositoryTests
    {
        private AuthRepository _authRepository;
        private ApplicationDBContext _dbContext;
        private PasswordService _passwordService;
        private IMapper _mapper;
        private ILogger<AuthRepository> _logger;
        private IConfiguration _configuration;
        private const string TEST_SECRET_KEY = "your_test_secret_key_that_is_at_least_32_characters_long";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Environment.SetEnvironmentVariable("API_SECRET", TEST_SECRET_KEY);
        }

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _dbContext = new ApplicationDBContext(options, new HttpContextAccessor());

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UsersDTO>();
            });
            _mapper = mapperConfig.CreateMapper();

            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            _logger = loggerFactory.CreateLogger<AuthRepository>();

            var inMemorySettings = new Dictionary<string, string>
            {
                {"JWT:Secret", TEST_SECRET_KEY}
            };
            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _passwordService = new PasswordService();
            _authRepository = new AuthRepository(_dbContext, _mapper, _logger, _configuration);

            SeedTestData();
        }

        private void SeedTestData()
        {
            var hashedPassword = _passwordService.HashPassword("TestPassword123!");

            var adminDepartment = new Department { Id = 1, DepartmentName = "AdminDept" };
            var userDepartment = new Department { Id = 2, DepartmentName = "EMT" };
            var regularDepartment = new Department { Id = 3, DepartmentName = "Regular" };

            _dbContext.Departments.AddRange(adminDepartment, userDepartment, regularDepartment);

            var project1 = new Project { Id = 1, Name = "Project1", DepartmentId = 1 };
            var project2 = new Project { Id = 2, Name = "Project2", DepartmentId = 2 };
            _dbContext.Projects.AddRange(project1, project2);

            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "admin@gmail.com",
                    Password = hashedPassword,
                    FullName = "Admin User",
                    IsActive = true,
                    DepartmentId = adminDepartment.Id,
                    Department = adminDepartment
                },
                new User
                {
                    Id = 2,
                    Email = "emt@gmail.com",
                    Password = hashedPassword,
                    FullName = "EMT User",
                    IsActive = true,
                    DepartmentId = userDepartment.Id,
                    Department = userDepartment,
                    Projects = new List<Project> { project1 }
                },
                new User
                {
                    Id = 3,
                    Email = "inactive@gmail.com",
                    Password = hashedPassword,
                    FullName = "Inactive User",
                    IsActive = false,
                    DepartmentId = regularDepartment.Id,
                    Department = regularDepartment
                }
            };

            _dbContext.Users.AddRange(users);
            _dbContext.SaveChanges();
        }

       

        [Test]
        public async Task LoginUser_WithInvalidPassword_ShouldReturnNull()
        {
            // Arrange
            var loginRequest = new LoginRequestDTO
            {
                Email = "admin@gmail.com",
                Password = "WrongPassword123!"
            };

            // Act
            var result = await _authRepository.LoginUser(loginRequest, _passwordService);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task LoginUser_WithNonexistentEmail_ShouldReturnNull()
        {
            // Arrange
            var loginRequest = new LoginRequestDTO
            {
                Email = "nonexistent@gmail.com",
                Password = "TestPassword123!"
            };

            // Act
            var result = await _authRepository.LoginUser(loginRequest, _passwordService);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void LoginUser_WithInactiveUser_ShouldThrowUnauthorizedAccessException()
        {
            // Arrange
            var loginRequest = new LoginRequestDTO
            {
                Email = "inactive@gmail.com",
                Password = "TestPassword123!"
            };

            // Act & Assert
            var exception = Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
                await _authRepository.LoginUser(loginRequest, _passwordService));

            Assert.That(exception.Message, Is.EqualTo("Your account has been deactivated.Please contact the admin."));
        }

       

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Environment.SetEnvironmentVariable("API_SECRET", null);
        }
    }
}
