using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Models.DTO;
using Microsoft.IdentityModel.Tokens;
using Risk_Management_RiskEX_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class AuthRepository : IAuthRepository
    {

        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthRepository> _logger;  // Fixed logger type
        private readonly IConfiguration _configuration;
        private readonly string _secretKey;
        public AuthRepository(ApplicationDBContext db, IMapper mapper, ILogger<AuthRepository> logger, IConfiguration configuration)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
            _secretKey = Environment.GetEnvironmentVariable("API_SECRET");
            if (string.IsNullOrEmpty(_secretKey))
            {
                _logger.LogError("API_SECRET is not set in the environment variables.");
                throw new InvalidOperationException("API_SECRET is not set in the environment variables.");
            }
        }


        public async Task<LoginResponseDTO> LoginUser(LoginRequestDTO loginRequestDTO)
        {
            try
            {
                var user = await _db.Users
                          .Include(u => u.Department)  // Include Department
                          .Include(u => u.Projects)    // Include Projects
                          .FirstOrDefaultAsync(u => u.Email == loginRequestDTO.Email);

                if (user == null || user.Password != loginRequestDTO.Password)
                {
                    return null;
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secretKey);

                // Create claims
                var claims = new List<Claim>
                {
                       // Basic user claims
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim("DepartmentId", user.Department?.Id.ToString() ?? "Unknown"),
                        new Claim("DepartmentName", user.Department?.DepartmentName ?? "Unknown"),
                        new Claim("UserName", user.FullName ?? "Unknown") // Include the user's name
                };

                // Add the Admin role if the email matches a specific admin email
                if (user.Email == "admin@gmail.com") // Replace with the actual admin email
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }
                else
                {
                    // Add the DepartmentUser role if the user has a department
                    if (user.Department != null)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "DepartmentUser"));

                        // Add ProjectUsers role if the user has associated projects
                        if (user.Projects != null && user.Projects.Any())
                        {
                            claims.Add(new Claim(ClaimTypes.Role, "ProjectUsers"));

                            // Serialize the project list to JSON and add it as a custom claim
                            var projectsJson = JsonSerializer.Serialize(user.Projects.Select(p => new { p.Id, p.Name }));
                            claims.Add(new Claim("Projects", projectsJson));
                        }
                    }
                }

                // Add the current user ID as a custom claim
                claims.Add(new Claim("CurrentUserId", user.Id.ToString()));


                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                LoginResponseDTO loginResponseDTO = new()
                {
                    User = _mapper.Map<UsersDTO>(user),
                    Token = tokenHandler.WriteToken(token)
                };

                return loginResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user login");
                throw;
            }
        }


    }
}
