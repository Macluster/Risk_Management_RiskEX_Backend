using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Data
{
    public class ApplicationDBContext:IdentityDbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            UpdateAuditFields();
            return base.SaveChanges();
        }

        public  DbSet<Risk> Risks {  get; set; }
       public  DbSet<Department> Departments { get; set; }

       public  DbSet<User> Users { get; set; }
       public  DbSet<RiskAssessment> Assessments { get; set; }
       public DbSet<Project> Projects { get; set; }

       public DbSet<Review> Reviews { get; set; }
       public DbSet<ExternalReviewer> ExternalReviewers { get; set; }
       public DbSet<AssessmentBasis> AssessmentsBasis { get; set; }
       public DbSet<AssessmentMatrixImpact> AssessmentsMatrixImpact { get; set; }
       public DbSet<AssessmentMatrixLikelihood> AssessmentsMatrixLikelihood { get; set; }
       public DbSet<RiskResponseData> RiskResponseDatas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(TimeStamps).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(TimeStamps.CreatedAt))
                        .HasColumnType("timestamptz") // Short for "timestamp with time zone"
                        .IsRequired(false);

                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(TimeStamps.UpdatedAt))
                        .HasColumnType("timestamptz")
                        .IsRequired(false);
                }
            }

            // Configure BaseEntity properties as nullable
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property("CreatedById")
                        .IsRequired(false);

                    modelBuilder.Entity(entityType.ClrType)
                        .Property("UpdatedById")
                        .IsRequired(false);
                }
            }

            ConfigureUserRelationships(modelBuilder);
            ConfigureRiskRelationships(modelBuilder);
            ConfigureProjectRelationships(modelBuilder);
            ConfigureReviewRelationships(modelBuilder);
            ConfigureRiskAssessmentRelationships(modelBuilder);
            ConfigureExternalReviewerRelationships(modelBuilder);

            DbInitializer.SeedData(modelBuilder);
        }

        private void ConfigureUserRelationships(ModelBuilder modelBuilder)
        {
            // User - Department
            modelBuilder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(d => d.Users)
                .HasForeignKey(u => u.DepartmentId);

            // User - Project
            modelBuilder.Entity<User>()
                .HasMany(u => u.Projects)
                .WithMany(u => u.Users);
               

            // User - User Created and Updated
            modelBuilder.Entity<User>()
                .HasOne(r => r.CreatedBy)
                .WithMany(u => u.CreatedUsers);

            modelBuilder.Entity<User>()
                .HasOne(r => r.UpdatedBy)
                .WithMany(u => u.UpdatedUsers);
        }

        private void ConfigureRiskRelationships(ModelBuilder modelBuilder)
        {
            // User - Risk responsible user
            modelBuilder.Entity<Risk>()
                .HasOne(r => r.ResponsibleUser)
                .WithMany(u => u.ResponsibleRisks)
                .HasForeignKey(f => f.ResponsibleUserId);

            // User - Risk Created and Updated
            modelBuilder.Entity<Risk>()
                .HasOne(r => r.CreatedBy)
                .WithMany(u => u.CreatedRisks);

            modelBuilder.Entity<Risk>()
                .HasOne(r => r.UpdatedBy)
                .WithMany(u => u.UpdatedRisks);

            // Risk - Projects
            modelBuilder.Entity<Risk>()
                .HasOne(r => r.Project)
                .WithMany(u => u.Risks)
                .HasForeignKey(u => u.ProjectId);

            // Risk - Department
            modelBuilder.Entity<Risk>()
                .HasOne(r => r.Department)
                .WithMany(u => u.Risks)
                .HasForeignKey(u => u.DepartmentId);

            //Risk - Risk Response
            modelBuilder.Entity<Risk>()
                 .HasOne(r => r.RiskResponseData)
                 .WithMany(u => u.Risks)
                 .HasForeignKey(r => r.RiskResponseId)
                 .OnDelete(DeleteBehavior.Restrict);

        }

        private void ConfigureProjectRelationships(ModelBuilder modelBuilder)
        {
            // User - Project Created and Updated
            modelBuilder.Entity<Project>()
                .HasOne(r => r.CreatedBy)
                .WithMany(u => u.CreatedProjects);

            modelBuilder.Entity<Project>()
                .HasOne(r => r.UpdatedBy)
                .WithMany(u => u.UpdatedProjects);

            // Projects - Department
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Department)
                .WithMany(r => r.Projects)
                .HasForeignKey(d => d.DepartmentId);
        }

        private void ConfigureReviewRelationships(ModelBuilder modelBuilder)
        {
            // User - Review Created and Updated
            modelBuilder.Entity<Review>()
                .HasOne(r => r.CreatedBy)
                .WithMany(u => u.CreatedReviews);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.UpdatedBy)
                .WithMany(u => u.UpdatedReviews);

            // Review - User
            modelBuilder.Entity<Review>()
                .HasOne(ra => ra.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(f => f.UserId);

            // Review - ExternalReviewer
            modelBuilder.Entity<Review>()
                .HasOne(ra => ra.ExternalReviewer)
                .WithMany(eu => eu.Reviews)
                .HasForeignKey(f => f.ExternalReviewerId);
        }

        private void ConfigureRiskAssessmentRelationships(ModelBuilder modelBuilder)
        {
            // RiskAssessment - Assessment Basis
            modelBuilder.Entity<RiskAssessment>()
                .HasOne(a => a.AssessmentBasis)
                .WithMany(a => a.RiskAssessments);

            // RiskAssessment - Risk
            modelBuilder.Entity<RiskAssessment>()
                .HasOne(a => a.Risk)
                .WithMany(r => r.RiskAssessments)
                .HasForeignKey(f => f.RiskId);

            modelBuilder.Entity<RiskAssessment>()
                .HasOne(ra => ra.MatrixImpact)
                .WithMany(ma => ma.RiskAssessments)
                .HasForeignKey(f => f.Impact);

            modelBuilder.Entity<RiskAssessment>()
                .HasOne(ra => ra.MatrixLikelihood)
                .WithMany(ma => ma.RiskAssessments)
                .HasForeignKey(f => f.Likelihood);

            // RiskAssessment - Review
            modelBuilder.Entity<RiskAssessment>()
                .HasOne(ra => ra.Review)
                .WithMany(ma => ma.RiskAssessments)
                .HasForeignKey(r => r.ReviewId);
      
        }

        private void ConfigureExternalReviewerRelationships(ModelBuilder modelBuilder)
        {
            // User - ExternalReviewer Created and Updated
            modelBuilder.Entity<ExternalReviewer>()
                .HasOne(r => r.CreatedBy)
                .WithMany(u => u.CreatedExternalReviewers);

            modelBuilder.Entity<ExternalReviewer>()
                .HasOne(r => r.UpdatedBy)
                .WithMany(u => u.UpdatedExternalReviewers);

            // ExternalReviewer - Department
            modelBuilder.Entity<ExternalReviewer>()
                .HasOne(ra => ra.Department)
                .WithMany(eu => eu.ExternalReviewers)
                .HasForeignKey(f => f.DepartmentId);
        }

       
        private void UpdateAuditFields()
        {
            var currentUserId = GetCurrentUserId();

            var entries = ChangeTracker
                .Entries()
                .Where(e => (e.Entity is TimeStamps || e.Entity is BaseEntity) &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            UpdateTimeStamps(entries);
            UpdateUserAuditFields(entries, currentUserId);
        }
        private void UpdateTimeStamps(IEnumerable<EntityEntry> entries)
        {
            var utcNow = DateTime.UtcNow;

            foreach (var entityEntry in entries.Where(e => e.Entity is TimeStamps))
            {
                if (entityEntry.Entity is TimeStamps entity)
                {
                    if (entityEntry.State == EntityState.Added)
                    {
                        entity.CreatedAt = utcNow;
                    }
                    entity.UpdatedAt = utcNow;
                }
            }
        }


        private void UpdateUserAuditFields(IEnumerable<EntityEntry> entries, int? currentUserId)
        {
            if (!currentUserId.HasValue)
                return;

            foreach (var entityEntry in entries.Where(e => e.Entity is BaseEntity))
            {
                if (entityEntry.Entity is BaseEntity baseEntity)
                {
                    if (entityEntry.State == EntityState.Added)
                    {
                        baseEntity.CreatedById = currentUserId;
                        baseEntity.UpdatedById = currentUserId;
                    }
                    else if (entityEntry.State == EntityState.Modified)
                    {
                        baseEntity.UpdatedById = currentUserId;
                    }
                }
            }
        }


        private int? GetCurrentUserId()
        {
            try
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User
                    .FindFirst(ClaimTypes.NameIdentifier)?.Value;

                return userIdClaim != null ? int.Parse(userIdClaim) : null;
            }
            catch
            {
                // If there's any error parsing the ID or accessing the claim, return null
                return null;
            }
        }
    }
}

