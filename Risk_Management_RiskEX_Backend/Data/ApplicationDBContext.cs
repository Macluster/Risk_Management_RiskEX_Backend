using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RiskManagement_Department_API.Models;

namespace Risk_Management_RiskEX_Backend.Data
{
    public class ApplicationDBContext:IdentityDbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        DbSet<Risk> risks {  get; set; }
        DbSet<Department> departments { get; set; }

        DbSet<User> users { get; set; }
        DbSet<RiskAssessment> assessments { get; set; }
        DbSet<Project> projects { get; set; }

        DbSet<Review> reviews { get; set; }
        DbSet<ExternalReviewer> externalReviewers { get; set; }
        DbSet<AssessmentBasis> assessmentsBasis { get; set; }
        DbSet<AssessmentMatrixImpact> assessmentsMatrixImpact { get; set; }
        DbSet<AssessmentMatrixLikelihood> assessmentsMatrixLikelihood { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            // User - Department 
            modelBuilder.Entity<User>()
                .HasOne(u => u.Department)
                .WithMany(d =>d.Users )
                .HasForeignKey(u => u.DepartmentId);

            // User - Project
            modelBuilder.Entity<User>()
            .HasMany(u => u.Projects)
            .WithOne(u=>u.User)
            .HasForeignKey(u => u.UserId);

      

            //User -Risk  responsible user
            modelBuilder.Entity<Risk>()
             .HasOne(r => r.ResponsibleUser)
             .WithMany(u => u.ResponsibleRisks)
             .HasForeignKey(f => f.ResponsibleUserId);


            // User - User Created and Updated 
            modelBuilder.Entity<User>()
                .HasOne(r => r.CreatedBy).WithMany(u => u.CreatedUsers);
            modelBuilder.Entity<User>()
                  .HasOne(r => r.UpdatedBy).WithMany(u => u.UpdatedUsers);


            // User - Project Created and Updated 
            modelBuilder.Entity<Project>()
                .HasOne(r => r.CreatedBy).WithMany(u => u.CreatedProjects);
            modelBuilder.Entity<Project>()
                  .HasOne(r => r.UpdatedBy).WithMany(u => u.UpdatedProjects);

            //User-Department Created and Updated
            modelBuilder.Entity<Department>()
              .HasOne(r => r.CreatedBy).WithMany(u => u.CreatedDepartments);
            modelBuilder.Entity<Department>()
                  .HasOne(r => r.UpdatedBy).WithMany(u => u.UpdatedDepartments);


            //User-Risk Created and Updated
            modelBuilder.Entity<Risk>()
              .HasOne(r => r.CreatedBy).WithMany(u => u.CreatedRisks);
            modelBuilder.Entity<Risk>()
                  .HasOne(r => r.UpdatedBy).WithMany(u => u.UpdatedRisks);

            //User-RiskAssessment Created and Updated
            modelBuilder.Entity<RiskAssessment>()
              .HasOne(r => r.CreatedBy).WithMany(u => u.CreatedRiskAssessments);
            modelBuilder.Entity<RiskAssessment>()
                  .HasOne(r => r.UpdatedBy).WithMany(u => u.UpdatedRiskAssessments);


            //User-AssessmentaBasis Created and Updated
            modelBuilder.Entity<AssessmentBasis>()
              .HasOne(r => r.CreatedBy).WithMany(u => u.CreatedAssessmentBasis);
            modelBuilder.Entity<AssessmentBasis>()
                  .HasOne(r => r.UpdatedBy).WithMany(u => u.UpdatedAssessmentBasis);

            //User-AssessmentMatrixImpact Created and Updated
            modelBuilder.Entity<AssessmentMatrixImpact>()
              .HasOne(r => r.CreatedBy).WithMany(u => u.CreatedImpactMatrix);
            modelBuilder.Entity<AssessmentMatrixImpact>()
                  .HasOne(r => r.UpdatedBy).WithMany(u => u.UpdatedImpactMatrix);

            //User-AssessmentMatrixLikelihood Created and Updated
            modelBuilder.Entity<AssessmentMatrixLikelihood>()
         .HasOne(r => r.CreatedBy).WithMany(u => u.CreatedLikeliHoodMatrix);
            modelBuilder.Entity<AssessmentMatrixLikelihood>()
                  .HasOne(r => r.UpdatedBy).WithMany(u => u.UpdatedLikeliHoodMatrix);



            //User-ExternalReviewer Created and Updated
            modelBuilder.Entity<ExternalReviewer>()
         .HasOne(r => r.CreatedBy).WithMany(u => u.CreatedExternalReviewers);
            modelBuilder.Entity<ExternalReviewer>()
                  .HasOne(r => r.UpdatedBy).WithMany(u => u.UpdatedExternalReviewers);


            //User-ExternalReviewer Created and Updated
            modelBuilder.Entity<Review>()
         .HasOne(r => r.CreatedBy).WithMany(u => u.CreatedReviews);
            modelBuilder.Entity<Review>()
                  .HasOne(r => r.UpdatedBy).WithMany(u => u.UpdatedReviews);








            //Risk-Projects
            modelBuilder.Entity<Risk>()
            .HasOne(r => r.Project).WithMany(u => u.Risks).HasForeignKey(u=>u.ProjectId);

            //Risk- Department
            modelBuilder.Entity<Risk>()
            .HasOne(r => r.Department).WithMany(u => u.Risks).HasForeignKey(u => u.DepartmentId);

            


            //RiskAssesssment-Assessment Basis
            modelBuilder.Entity<RiskAssessment>().HasOne(a=>a.AssessmentBasis).WithMany(a=>a.RiskAssessments);

            //RiskAssessment- Risk
            modelBuilder.Entity<RiskAssessment>().HasOne(a => a.Risk).WithMany(r => r.RiskAssessments).HasForeignKey(f=>f.RiskId);
            modelBuilder.Entity<RiskAssessment>().HasOne(ra => ra.MatrixImpact).WithMany(ma => ma.RiskAssessments).HasForeignKey(f => f.Impact);
            modelBuilder.Entity<RiskAssessment>().HasOne(ra => ra.MatrixLikelihood).WithMany(ma => ma.RiskAssessments).HasForeignKey(f => f.Likelihood);

            //RiskAssessment-Review

            modelBuilder.Entity<RiskAssessment>().HasOne(ra => ra.Review).WithMany(ma => ma.RiskAssessments).HasForeignKey(r => r.ReviewId);




            //Projects -Department
            modelBuilder.Entity<Project>().HasOne(p=>p.Department).WithMany(r=>r.Projects).HasForeignKey(d=>d.DepartmentId);



            //Review-user

            modelBuilder.Entity<Review>().HasOne(ra=>ra.User).WithMany(u=>u.Reviews).HasForeignKey(f=>f.UserId);

            //Review-ExternalReviewer

            modelBuilder.Entity<Review>().HasOne(ra => ra.ExternalReviewer).WithMany(eu => eu.Reviews).HasForeignKey(f => f.ExternalReviewerId);



            //ExternalReviewer-department
            modelBuilder.Entity<ExternalReviewer>().HasOne(ra => ra.Department).WithMany(eu => eu.ExternalReviewers).HasForeignKey(f => f.DepartmentId);







        }



    }
}
