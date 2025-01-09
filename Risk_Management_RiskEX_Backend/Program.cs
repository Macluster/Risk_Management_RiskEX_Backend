
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Risk_Management_RiskEX_Backend;
using Risk_Management_RiskEX_Backend.Data;
using Risk_Management_RiskEX_Backend.Interfaces;
using Risk_Management_RiskEX_Backend.Repository;
using Risk_Management_RiskEX_Backend.Services;


//Loading Env file
DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

//Getting Connection String from Env file adding to db context
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
var jwt_Scret = Environment.GetEnvironmentVariable("API_SECRET");
//builder.Services.AddDbContext<ApplicationDBContext>(options =>
//           options.UseNpgsql(connectionString));


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
// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<IUserRepository, UserRepository>();
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


builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewerRepository, ReviewerRepository>();
//builder.Services.AddScoped<IPasswordResetRepository, PasswordResetRepository>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<PasswordService>();

<<<<<<< HEAD

builder.Services.AddSwaggerGen(option =>
=======



builder.Services.AddSwaggerGen(option => {

>>>>>>> 7b9e81c4427dc64e34d8d80a17eac721d8a8f1bc
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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
            jwt_Scret)),
        ValidateIssuer = false,
        ValidateAudience = false

    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));

    options.AddPolicy("ProjectUsers", policy =>
             policy.RequireRole("ProjectUsers"));

    options.AddPolicy("DepartmentUsers", policy =>
        policy.RequireRole("DepartmentUser"));
});





builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});





var app = builder.Build();
app.UseCors("AllowAll");



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
