﻿using AutoMapper;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Risk_Management_RiskEX_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Services;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private const string DEFAULT_PASSWORD = "experion@123";
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<UserRepository> _logger;
        private readonly IEmailService _emailService;

        public UserRepository(ApplicationDBContext db, IMapper mapper, ILogger<UserRepository> logger, IEmailService emailService)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<bool> AddUserToDepartment(UsersDTO userDto, int? currentUserId = null)
        {
            try
            {
                // Input validation
                if (string.IsNullOrWhiteSpace(userDto.Email))
                {
                    _logger.LogError("User email cannot be empty.");
                    return false;
                }

                // Check for existing user
                var existingUser = await _db.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);
                if (existingUser != null)
                {
                    _logger.LogError($"User with email {userDto.Email} already exists.");
                    return false;
                }

                // Validate and get department
                var department = await _db.Departments
                                .FirstOrDefaultAsync(d => d.DepartmentName.ToLower() == userDto.DepartmentName.ToLower());
                if (department == null)
                {
                    _logger.LogError($"Department with name {userDto.DepartmentName} not found.");
                    return false;
                }

                // Create new User entity using AutoMapper
                var user = _mapper.Map<User>(userDto);

                // Set the DepartmentId explicitly
                user.DepartmentId = department.Id;

                // Set audit fields
                user.CreatedAt = DateTime.UtcNow;
                user.UpdatedAt = DateTime.UtcNow;
                user.IsActive = true;

                //if (currentUserId.HasValue)
                //{
                //    user.CreatedBy = currentUserId;
                //    user.UpdatedBy = currentUserId;
                //}

                // Handle project associations if provided
                if (userDto.ProjectNames != null && userDto.ProjectNames.Any())
                {
                    var projects = await _db.Projects
                        .Where(p => userDto.ProjectNames.Contains(p.Name))
                        .ToListAsync();

                    // Verify all project names were found
                    var foundProjectNames = projects.Select(p => p.Name).ToList();
                    var missingProjects = userDto.ProjectNames
                        .Where(name => !foundProjectNames.Contains(name, StringComparer.OrdinalIgnoreCase))
                        .ToList();

                    if (missingProjects.Any())
                    {
                        _logger.LogError($"Projects not found: {string.Join(", ", missingProjects)}");
                        return false;
                    }

                    user.Projects = projects;
                }

                // Add user to database
                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();

                // Send welcome email
                try
                {
                    await _emailService.SendEmail(
                        user.Email,
                        "Your Account Credentials",
                        $"Welcome to the system!\n\n" +
                        $"Your account has been created with the following credentials:\n" +
                        $"Username: {user.Email}\n" +
                        $"Password: {DEFAULT_PASSWORD}\n\n" +
                        "Please change your password upon first login for security purposes."
                    );
                }
                catch (Exception emailEx)
                {
                    _logger.LogWarning($"Failed to send welcome email: {emailEx.Message}");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding user to department");
                return false;
            }
        
        }

        public async Task<bool> ChangeUserActiveStatus(int id,bool isActive)
        {
            var user=await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if(user!=null)
            {
                user.IsActive = isActive;

                _db.Users.Update(user);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

          
           
        }
    }
}










