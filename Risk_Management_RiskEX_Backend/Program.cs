using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Risk_Management_RiskEX_Backend;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Repository;
using Risk_Management_RiskEX_Backend.Services;

//Loading Env file
DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

//Getting Connection String from Env file adding to db context
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
var jwt_Scret = Environment.GetEnvironmentVariable("API_SECRET");

builder.Services.AddDbContext<ApplicationDBContext>((serviceProvider, options) =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<ApplicationDBContext>((serviceProvider) =>
{
    var options = serviceProvider.GetRequiredService<DbContextOptions<ApplicationDBContext>>();
    var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
    return new ApplicationDBContext(options, httpContextAccessor);
});

builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRiskMongoService, RiskMongoService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IRiskRepository, RiskRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IRiskResponseRepository, RiskResponseRepository>();
builder.Services.AddScoped<IAssessmentMatrixImpactRepository, AssessmentMatrixImpactRepository>();
builder.Services.AddScoped<IAssessmentMatrixLikelihoodRepository, AssessmentMatrixLikelihoodRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IApprovalRepository, ApprovalsRepository>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewerRepository, ReviewerRepository>();
builder.Services.AddScoped<UserService>();

// Configure MongoDB
builder.Services.Configure<RiskDatabaseSettingscs>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
             "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
             "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
             "Example: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwt_Scret)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ProjectUsers", policy => policy.RequireRole("ProjectUsers"));
    options.AddPolicy("DepartmentUsers", policy => policy.RequireRole("DepartmentUser"));
});

var corsOrigins = builder.Configuration.GetSection("CorsOrigins").Get<string[]>() ?? new string[] { };

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        if (corsOrigins.Length > 0)
        {
            var cleanedOrigins = corsOrigins.Select(o => o.TrimEnd('/')).ToArray();

            policy.WithOrigins(cleanedOrigins)
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials(); 
        }
        else
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        }
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<DepartmentValidationMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();
app.MapControllers();

app.Run();