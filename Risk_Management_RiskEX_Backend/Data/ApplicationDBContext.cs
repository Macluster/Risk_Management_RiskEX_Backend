using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Data
{
    public class ApplicationDBContext:IdentityDbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{



        //    base.OnModelCreating(modelBuilder);
        //    // User - Department 
        //    modelBuilder.Entity<User>()
        //        .HasOne(u => u.Department)
        //        .WithMany(d =>d.Users )
        //        .HasForeignKey(u => u.DepartmentId);

        //    // User - Project
        //    modelBuilder.Entity<User>()
        //    .HasMany(u => u.Projects)
        //    .WithOne(u=>u.User)
        //    .HasForeignKey(u => u.UserId);



        //    //User -Risk  responsible user
        //    modelBuilder.Entity<Risk>()
        //     .HasOne(r => r.ResponsibleUser)
        //     .WithMany(u => u.ResponsibleRisks)
        //     .HasForeignKey(f => f.ResponsibleUserId);


        //    // User - User Created and Updated 
        //    modelBuilder.Entity<User>()
        //        .HasOne(r => r.CreatedBy).WithMany(u => u.CreatedUsers);
        //    modelBuilder.Entity<User>()
        //          .HasOne(r => r.UpdatedBy).WithMany(u => u.UpdatedUsers);


        //    // User - Project Created and Updated 
        //    modelBuilder.Entity<Project>()
        //        .HasOne(r => r.CreatedBy).WithMany(u => u.CreatedProjects);
        //    modelBuilder.Entity<Project>()
        //          .HasOne(r => r.UpdatedBy).WithMany(u => u.UpdatedProjects);




        //    //User-Risk Created and Updated
        //    modelBuilder.Entity<Risk>()
        //      .HasOne(r => r.CreatedBy).WithMany(u => u.CreatedRisks);
        //    modelBuilder.Entity<Risk>()
        //          .HasOne(r => r.UpdatedBy).WithMany(u => u.UpdatedRisks);

        //    //User-ExternalReviewer Created and Updated
        //    modelBuilder.Entity<ExternalReviewer>()
        // .HasOne(r => r.CreatedBy).WithMany(u => u.CreatedExternalReviewers);
        //    modelBuilder.Entity<ExternalReviewer>()
        //          .HasOne(r => r.UpdatedBy).WithMany(u => u.UpdatedExternalReviewers);


        //    //User-ExternalReviewer Created and Updated
        //    modelBuilder.Entity<Review>()
        // .HasOne(r => r.CreatedBy).WithMany(u => u.CreatedReviews);
        //    modelBuilder.Entity<Review>()
        //          .HasOne(r => r.UpdatedBy).WithMany(u => u.UpdatedReviews);








        //    //Risk-Projects
        //    modelBuilder.Entity<Risk>()
        //    .HasOne(r => r.Project).WithMany(u => u.Risks).HasForeignKey(u=>u.ProjectId);

        //    //Risk- Department
        //    modelBuilder.Entity<Risk>()
        //    .HasOne(r => r.Department).WithMany(u => u.Risks).HasForeignKey(u => u.DepartmentId);




        //    //RiskAssesssment-Assessment Basis
        //    modelBuilder.Entity<RiskAssessment>().HasOne(a=>a.AssessmentBasis).WithMany(a=>a.RiskAssessments);

        //    //RiskAssessment- Risk
        //    modelBuilder.Entity<RiskAssessment>().HasOne(a => a.Risk).WithMany(r => r.RiskAssessments).HasForeignKey(f=>f.RiskId);
        //    modelBuilder.Entity<RiskAssessment>().HasOne(ra => ra.MatrixImpact).WithMany(ma => ma.RiskAssessments).HasForeignKey(f => f.Impact);
        //    modelBuilder.Entity<RiskAssessment>().HasOne(ra => ra.MatrixLikelihood).WithMany(ma => ma.RiskAssessments).HasForeignKey(f => f.Likelihood);

        //    //RiskAssessment-Review

        //    modelBuilder.Entity<RiskAssessment>().HasOne(ra => ra.Review).WithMany(ma => ma.RiskAssessments).HasForeignKey(r => r.ReviewId);




        //    //Projects -Department
        //    modelBuilder.Entity<Project>().HasOne(p=>p.Department).WithMany(r=>r.Projects).HasForeignKey(d=>d.DepartmentId);



        //    //Review-user

        //    modelBuilder.Entity<Review>().HasOne(ra=>ra.User).WithMany(u=>u.Reviews).HasForeignKey(f=>f.UserId);

        //    //Review-ExternalReviewer

        //    modelBuilder.Entity<Review>().HasOne(ra => ra.ExternalReviewer).WithMany(eu => eu.Reviews).HasForeignKey(f => f.ExternalReviewerId);



        //    //ExternalReviewer-department
        //    modelBuilder.Entity<ExternalReviewer>().HasOne(ra => ra.Department).WithMany(eu => eu.ExternalReviewers).HasForeignKey(f => f.DepartmentId);


        //    DbInitializer.SeedData(modelBuilder);





        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure TimeStamps properties as nullable
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(TimeStamps).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(TimeStamps.CreatedAt))
                        .IsRequired(false);

                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(TimeStamps.UpdatedAt))
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
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId);

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

            //Risk - Risk Respomse
            modelBuilder.Entity<Risk>()
                 .HasOne(r => r.RiskResponseData)
                 .WithMany(u=>u.risks)
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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is TimeStamps && (
                    e.State == EntityState.Added ||
                    e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var entity = (TimeStamps)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}

    