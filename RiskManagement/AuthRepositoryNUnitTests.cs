using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Repository;
using Risk_Management_RiskEX_Backend.Services;
using Microsoft.AspNetCore.Http;
using DotNetEnv;

namespace RiskManagement
{
    [TestFixture]

    public class AuthRepositoryNUnitTests
    {
        private AuthRepository _authRepository;
        private ApplicationDBContext _dbContext;
        private PasswordService _passwordService;
        private IMapper _mapper;
        private ILogger<AuthRepository> _logger;
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            // Load environment variables
            DotNetEnv.Env.Load();

            // Retrieve API_SECRET from environment variables

            var secretKey = Environment.GetEnvironmentVariable("API_SECRET");
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("API_SECRET is not set in the environment variables.");
            }

            // Set up in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var httpContextAccessor = new HttpContextAccessor();

            _dbContext = new ApplicationDBContext(options, httpContextAccessor);

            // Set up AutoMapper
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UsersDTO>();
            });
            _mapper = config.CreateMapper();

            // Set up logger
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            _logger = loggerFactory.CreateLogger<AuthRepository>();

            // Set up configuration
            var inMemorySettings = new Dictionary<string, string>
            {
                { "Jwt:Secret", secretKey }
            };
            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            // Set up the password service
            _passwordService = new PasswordService();

            // Initialize repository
            _authRepository = new AuthRepository(_dbContext, _mapper, _logger, _configuration);

            // Seed the database
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            var hashedPassword = _passwordService.HashPassword("Password123!");

            _dbContext.Users.AddRange(
                new User
                {
                    Id = 1,
                    Email = "admin@gmail.com",
                    Password = hashedPassword,
                    IsActive = true,
                    FullName = "Admin User",
                    Department = new Department { Id = 1, DepartmentName = "AdminDept" },
                    Projects = new List<Project> { new Project { Id = 1, Name = "Project1" } }
                },
                new User
                {
                    Id = 2,
                    Email = "user@gmail.com",
                    Password = hashedPassword,
                    IsActive = true,
                    FullName = "Normal User",
                    Department = new Department { Id = 2, DepartmentName = "UserDept" },
                    Projects = new List<Project> { new Project { Id = 2, Name = "Project2" } }
                }
            );
            _dbContext.SaveChanges();
        }

        [Test]
        public async Task LoginUser_WithValidCredentials_ShouldReturnToken()
        {
            // Arrange
            var loginRequestDTO = new LoginRequestDTO
            {
                Email = "admin@gmail.com",
                Password = "Password123!"
            };

            // Act
            var result = await _authRepository.LoginUser(loginRequestDTO, _passwordService);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Token);
            Assert.AreEqual("admin@gmail.com", result.User.Email);
        }

        [Test]
        public async Task LoginUser_WithInvalidCredentials_ShouldReturnNull()
        {
            // Arrange
            var loginRequestDTO = new LoginRequestDTO
            {
                Email = "admin@gmail.com",
                Password = "WrongPassword!"
            };

            // Act
            var result = await _authRepository.LoginUser(loginRequestDTO, _passwordService);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task LoginUser_WithNonExistentUser_ShouldReturnNull()
        {
            // Arrange
            var loginRequestDTO = new LoginRequestDTO
            {
                Email = "nonexistent@gmail.com",
                Password = "Password123!"
            };

            // Act
            var result = await _authRepository.LoginUser(loginRequestDTO, _passwordService);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task LoginUser_WithDeactivatedUser_ShouldThrowUnauthorizedAccessException()
        {
            // Arrange
            var user = await _dbContext.Users.FirstAsync(u => u.Email == "user@gmail.com");
            user.IsActive = false;
            await _dbContext.SaveChangesAsync();

            var loginRequestDTO = new LoginRequestDTO
            {
                Email = "user@gmail.com",
                Password = "Password123!"
            };

            // Act & Assert
            Assert.ThrowsAsync<UnauthorizedAccessException>(async () =>
                await _authRepository.LoginUser(loginRequestDTO, _passwordService));
        }

        [Test]
        public async Task LoginUser_WithValidUser_ShouldIncludeProjectClaims()
        {
            // Arrange
            var loginRequestDTO = new LoginRequestDTO
            {
                Email = "user@gmail.com",
                Password = "Password123!"
            };

            // Act
            var result = await _authRepository.LoginUser(loginRequestDTO, _passwordService);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Token.Contains("Project2")); // Check if project claim is included
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}
