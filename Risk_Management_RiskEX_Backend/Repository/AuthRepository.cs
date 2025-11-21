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
using Risk_Management_RiskEX_Backend.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Risk_Management_RiskEX_Backend.config;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class AuthRepository : IAuthRepository
    {

        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthRepository> _logger; 
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


        public async Task<LoginResponseDTO> LoginUser(LoginRequestDTO loginRequestDTO,IPasswordService _passwordService)
        {
            try
            {
                var user = await _db.Users
                          .Include(u => u.Department)
                          .Include(u => u.Projects)
                          .FirstOrDefaultAsync(u => u.Email == loginRequestDTO.Email);

                if (user == null)
                {
                    return null;
                }

                if (!user.IsActive)
                {
                    throw new UnauthorizedAccessException("Your account has been deactivated.Please contact the admin.");
                }

                // Hash the password before storing it
                bool isPasswordVerified = _passwordService.VerifyPassword(user.Password, loginRequestDTO.Password);



                if (!isPasswordVerified)
                {
                    return null;
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secretKey);

                var claims = new List<Claim>

                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim("DepartmentId", user.Department?.Id.ToString() ?? "Unknown"),
                    new Claim("DepartmentName", user.Department?.DepartmentName ?? "Unknown"),
                    new Claim("UserName", user.FullName ?? "Unknown"),
                    new Claim("UserMail", user.Email ?? "Unknown")
                };

                //if (user.Email == "admin@gmail.com")
                //{
                //    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                //}
                if (GlobalConfig.IsAdmin(user.Email))
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }
                else
                {

                    if (user.Department != null)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "DepartmentUser"));

                      
                        if (user.Department.DepartmentName.Equals("EMT", StringComparison.OrdinalIgnoreCase))
                        {
                            claims.Add(new Claim(ClaimTypes.Role, "EMTUser"));
                        }

                        if (user.Projects != null && user.Projects.Any())
                        {
                            claims.Add(new Claim(ClaimTypes.Role, "ProjectUsers"));

                          
                            var projectsJson = JsonSerializer.Serialize(user.Projects.Select(p => new { p.Id, p.Name, p.ProjectCode}));
                            claims.Add(new Claim("Projects", projectsJson));
                        }
                    }
                }

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
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Deactivated user attempted to login: {Email}", loginRequestDTO.Email);
                throw; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user login");
                throw;
            }
        }

        public async Task<LoginResponseDTO> LoginUserWithMicrosoft(string email)
        {
            try
            {
                var user = await _db.Users
                    .Include(u => u.Department)
                    .Include(u => u.Projects)
                    .FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                {

                    return null;
                }

                if (!user.IsActive)
                {
                    throw new UnauthorizedAccessException("Your account has been deactivated.Please contact the admin.");
                }

                var key = Encoding.ASCII.GetBytes(_secretKey);

                var claims = new List<Claim>
                 {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim("DepartmentId", user.Department?.Id.ToString() ?? "Unknown"),
                    new Claim("DepartmentName", user.Department?.DepartmentName ?? "Unknown"),
                    new Claim("UserName", user.FullName ?? "Unknown"),
                    new Claim("UserMail", user.Email ?? "Unknown")
                 };

                //if (user.Email == "admin@gmail.com")
                //{
                //    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                //}
                if (GlobalConfig.IsAdmin(user.Email))
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }
                else
                {
                    if (user.Department != null)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "DepartmentUser"));

                        if (user.Department.DepartmentName.Equals("EMT", StringComparison.OrdinalIgnoreCase))
                        {
                            claims.Add(new Claim(ClaimTypes.Role, "EMTUser"));
                        }

                        if (user.Projects != null && user.Projects.Any())
                        {
                            claims.Add(new Claim(ClaimTypes.Role, "ProjectUsers"));

                            var projectsJson = JsonSerializer.Serialize(user.Projects.Select(p => new { p.Id, p.Name, p.ProjectCode }));
                            claims.Add(new Claim("Projects", projectsJson));
                        }
                    }
                }

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

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return new LoginResponseDTO
                {
                    User = _mapper.Map<UsersDTO>(user),
                    Token = tokenHandler.WriteToken(token),
                };
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Deactivated user or unauthorized user  attempted to login: {email}", email);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during user login");
                throw;
            }
        }


        public async Task<String> RegisterUser(LoginRequestDTO loginRequestDTO)
        {
            return "";

        }


        public async Task<bool> SaveResetToken(string email, string token)
        {
            var resetToken = new PasswordResetToken
            {
                Email = email,
                Token = token,
                ExpiryDate = DateTime.UtcNow.AddHours(1)
            };

            _db.PasswordResetTokens.Add(resetToken);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> ValidateResetToken(string email, string token)
        {
            var tokenEntry = await _db.PasswordResetTokens
                .FirstOrDefaultAsync(t => t.Email == email && t.Token == token);

            return tokenEntry != null && tokenEntry.ExpiryDate > DateTime.UtcNow;
        }

        public async Task<bool> UpdateUserPassword(string email, string newPasswordHash)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return false;

            user.Password = newPasswordHash;
            _db.Users.Update(user);

            return await _db.SaveChangesAsync() > 0;
        }


    }
}
