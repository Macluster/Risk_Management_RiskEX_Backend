using System.Text.Json;
using Risk_Management_RiskEX_Backend.Services;
using Risk_Management_RiskEX_Backend.Models;
using Risk_Management_RiskEX_Backend.Interfaces;

public class DepartmentValidationMiddleware
{
    private readonly RequestDelegate _next;

    public DepartmentValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IUserRepository userRepository)
    {
        var user = context.User;

        if (user?.Identity?.IsAuthenticated ?? false)
        {
            var userId = user.FindFirst("CurrentUserId")?.Value;
            var departmentIdFromToken = user.FindFirst("DepartmentId")?.Value;
            var projectsFromTokenJson = user.FindFirst("Projects")?.Value;

            if (!string.IsNullOrEmpty(userId))
            {

                bool isUserActive = await userRepository.IsUserActiveAsync(userId);
                if (!isUserActive)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("User is inactive. Access denied.");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(departmentIdFromToken))
            {
                var currentDepartmentId = await userRepository.GetDepartmentIdByUserIdAsync(userId);

                if (currentDepartmentId?.ToString() != departmentIdFromToken)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Department mismatch. Please log in again.");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(userId))
            {
                var currentProjectIds = await userRepository.GetProjectIdsByUserIdAsync(userId);


                var tokenProjectList = !string.IsNullOrEmpty(projectsFromTokenJson)
                                   ? JsonSerializer.Deserialize<List<ProjectClaim>>(projectsFromTokenJson)
                                   : new List<ProjectClaim>();

                var tokenProjectIds = tokenProjectList.Select(p => p.Id).OrderBy(id => id).ToList();
                var currentSorted = currentProjectIds.OrderBy(id => id).ToList();

                if (!tokenProjectIds.SequenceEqual(currentSorted))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Project access mismatch. Please log in again.");
                    return;
                }
            }
        }

        await _next(context);
    }

    private class ProjectClaim
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
