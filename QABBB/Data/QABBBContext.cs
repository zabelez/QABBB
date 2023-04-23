using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QABBB.Models;

namespace QABBB.Data
{
    public partial class QABBBContext : DbContext
    {
        public QABBBContext()
        {
        }

        public QABBBContext(DbContextOptions<QABBBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<CompanyEmployee> CompanyEmployees { get; set; } = null!;
        public virtual DbSet<CompanyEmployeePosition> CompanyEmployeePositions { get; set; } = null!;
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; } = null!;
        public virtual DbSet<Heatmap> Heatmaps { get; set; } = null!;
        public virtual DbSet<HeatmapLayer> HeatmapLayers { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Platform> Platforms { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectDeveloper> ProjectDevelopers { get; set; } = null!;
        public virtual DbSet<ProjectFile> ProjectFiles { get; set; } = null!;
        public virtual DbSet<ProjectForm> ProjectForms { get; set; } = null!;
        public virtual DbSet<ProjectInterview> ProjectInterviews { get; set; } = null!;
        public virtual DbSet<ProjectPlatform> ProjectPlatforms { get; set; } = null!;
        public virtual DbSet<ProjectPublisher> ProjectPublishers { get; set; } = null!;
        public virtual DbSet<ProjectSummaryDoc> ProjectSummaryDocs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserPlatform> UserPlatforms { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("PRIMARY");

                entity.ToTable("admin");

                entity.HasIndex(e => e.IdUser, "admin_FK1_idx");

                entity.HasIndex(e => e.CreatedBy, "admin_FK2_idx");

                entity.HasIndex(e => e.RemovedBy, "admin_FK3_idx");

                entity.Property(e => e.IdAdmin).HasColumnName("idAdmin");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.RemovedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("removedAt");

                entity.Property(e => e.RemovedBy).HasColumnName("removedBy");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.AdminCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("admin_FK2");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.AdminIdUserNavigations)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("admin_FK1");

                entity.HasOne(d => d.RemovedByNavigation)
                    .WithMany(p => p.AdminRemovedByNavigations)
                    .HasForeignKey(d => d.RemovedBy)
                    .HasConstraintName("admin_FK3");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.IdCompany)
                    .HasName("PRIMARY");

                entity.ToTable("company");

                entity.HasIndex(e => e.CompanyParent, "company_FK1_idx");

                entity.Property(e => e.IdCompany).HasColumnName("idCompany");

                entity.Property(e => e.CompanyParent).HasColumnName("companyParent");

                entity.Property(e => e.Logo).HasColumnName("logo");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.HasOne(d => d.CompanyParentNavigation)
                    .WithMany(p => p.InverseCompanyParentNavigation)
                    .HasForeignKey(d => d.CompanyParent)
                    .HasConstraintName("company_FK1");
            });

            modelBuilder.Entity<CompanyEmployee>(entity =>
            {
                entity.HasKey(e => e.IdCompanyEmployee)
                    .HasName("PRIMARY");

                entity.ToTable("companyEmployee");

                entity.HasIndex(e => e.IdCompany, "companyEmployee_FK1_idx");

                entity.HasIndex(e => e.IdPerson, "companyEmployee_FK2_idx");

                entity.HasIndex(e => e.CreatedBy, "companyEmployee_FK3_idx");

                entity.HasIndex(e => e.RemovedBy, "companyEmployee_FK4_idx");

                entity.HasIndex(e => e.IdPosition, "companyEmployee_FK5_idx");

                entity.Property(e => e.IdCompanyEmployee).HasColumnName("idCompanyEmployee");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.IdCompany).HasColumnName("idCompany");

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.Property(e => e.IdPosition).HasColumnName("idPosition");

                entity.Property(e => e.RemovedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("removedAt");

                entity.Property(e => e.RemovedBy).HasColumnName("removedBy");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CompanyEmployeeCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("companyEmployee_FK3");

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.CompanyEmployees)
                    .HasForeignKey(d => d.IdCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("companyEmployee_FK1");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.CompanyEmployeeIdPersonNavigations)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("companyEmployee_FK2");

                entity.HasOne(d => d.IdPositionNavigation)
                    .WithMany(p => p.CompanyEmployees)
                    .HasForeignKey(d => d.IdPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("companyEmployee_FK5");

                entity.HasOne(d => d.RemovedByNavigation)
                    .WithMany(p => p.CompanyEmployeeRemovedByNavigations)
                    .HasForeignKey(d => d.RemovedBy)
                    .HasConstraintName("companyEmployee_FK4");
            });

            modelBuilder.Entity<CompanyEmployeePosition>(entity =>
            {
                entity.HasKey(e => e.IdCompanyEmployeePosition)
                    .HasName("PRIMARY");

                entity.ToTable("companyEmployeePosition");

                entity.Property(e => e.IdCompanyEmployeePosition).HasColumnName("idCompanyEmployeePosition");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<EmailTemplate>(entity =>
            {
                entity.HasKey(e => e.IdEmailTemplate)
                    .HasName("PRIMARY");

                entity.ToTable("emailTemplate");

                entity.Property(e => e.IdEmailTemplate).HasColumnName("idEmailTemplate");

                entity.Property(e => e.Html).HasColumnName("html");

                entity.Property(e => e.Subject)
                    .HasMaxLength(200)
                    .HasColumnName("subject");

                entity.Property(e => e.Text)
                    .HasMaxLength(200)
                    .HasColumnName("text");
            });

            modelBuilder.Entity<Heatmap>(entity =>
            {
                entity.HasKey(e => e.IdHeatmap)
                    .HasName("PRIMARY");

                entity.ToTable("heatmap");

                entity.HasIndex(e => e.IdProjectPlatform, "heatmap_FK1_idx");

                entity.Property(e => e.IdHeatmap).HasColumnName("idHeatmap");

                entity.Property(e => e.Color)
                    .HasMaxLength(9)
                    .HasColumnName("color");

                entity.Property(e => e.IdProjectPlatform).HasColumnName("idProjectPlatform");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdProjectPlatformNavigation)
                    .WithMany(p => p.Heatmaps)
                    .HasForeignKey(d => d.IdProjectPlatform)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("heatmap_FK1");
            });

            modelBuilder.Entity<HeatmapLayer>(entity =>
            {
                entity.HasKey(e => e.IdHeatmapLayer)
                    .HasName("PRIMARY");

                entity.ToTable("heatmapLayer");

                entity.HasIndex(e => e.IdHeatmap, "heatmapLayerFK1_idx");

                entity.Property(e => e.IdHeatmapLayer).HasColumnName("idHeatmapLayer");

                entity.Property(e => e.IdHeatmap).HasColumnName("idHeatmap");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(200)
                    .HasColumnName("imagePath");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdHeatmapNavigation)
                    .WithMany(p => p.HeatmapLayers)
                    .HasForeignKey(d => d.IdHeatmap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("heatmapLayerFK1");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.IdLog)
                    .HasName("PRIMARY");

                entity.ToTable("log");

                entity.HasIndex(e => e.IdUser, "log_FK1_idx");

                entity.Property(e => e.IdLog).HasColumnName("idLog");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Ip)
                    .HasMaxLength(45)
                    .HasColumnName("ip");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("log_FK1");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("PRIMARY");

                entity.ToTable("person");

                entity.HasIndex(e => e.Email, "email_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdPerson).HasColumnName("idPerson");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .HasColumnName("email");

                entity.Property(e => e.PersonName)
                    .HasMaxLength(200)
                    .HasColumnName("personName");
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.HasKey(e => e.IdPlatform)
                    .HasName("PRIMARY");

                entity.ToTable("platform");

                entity.Property(e => e.IdPlatform).HasColumnName("idPlatform");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.IdProject)
                    .HasName("PRIMARY");

                entity.ToTable("project");

                entity.Property(e => e.IdProject).HasColumnName("idProject");

                entity.Property(e => e.Duration)
                    .HasPrecision(5, 1)
                    .HasColumnName("duration");

                entity.Property(e => e.Logo).HasColumnName("logo");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.PowerBiUrl).HasColumnName("powerBiURL");

                entity.Property(e => e.SpreadsheetUrl).HasColumnName("spreadsheetUrl");

                entity.Property(e => e.StartDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("startDateTime");
            });

            modelBuilder.Entity<ProjectDeveloper>(entity =>
            {
                entity.HasKey(e => e.IdProjectDeveloper)
                    .HasName("PRIMARY");

                entity.ToTable("projectDeveloper");

                entity.HasIndex(e => e.IdProject, "projectDeveloper_FK1_idx");

                entity.HasIndex(e => e.IdCompany, "projectDeveloper_FK2_idx");

                entity.Property(e => e.IdProjectDeveloper).HasColumnName("idProjectDeveloper");

                entity.Property(e => e.IdCompany).HasColumnName("idCompany");

                entity.Property(e => e.IdProject).HasColumnName("idProject");

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.ProjectDevelopers)
                    .HasForeignKey(d => d.IdCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("projectDeveloper_FK2");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProjectDevelopers)
                    .HasForeignKey(d => d.IdProject)
                    .HasConstraintName("projectDeveloper_FK1");
            });

            modelBuilder.Entity<ProjectFile>(entity =>
            {
                entity.HasKey(e => e.IdProjectFile)
                    .HasName("PRIMARY");

                entity.ToTable("projectFile");

                entity.HasIndex(e => e.IdProject, "projectFile_FK1_idx");

                entity.Property(e => e.IdProjectFile).HasColumnName("idProjectFile");

                entity.Property(e => e.IdProject).HasColumnName("idProject");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProjectFiles)
                    .HasForeignKey(d => d.IdProject)
                    .HasConstraintName("projectFile_FK1");
            });

            modelBuilder.Entity<ProjectForm>(entity =>
            {
                entity.HasKey(e => e.IdProjectForm)
                    .HasName("PRIMARY");

                entity.ToTable("projectForm");

                entity.HasIndex(e => e.IdProject, "projectForm_FK1_idx");

                entity.Property(e => e.IdProjectForm).HasColumnName("idProjectForm");

                entity.Property(e => e.IdProject).HasColumnName("idProject");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProjectForms)
                    .HasForeignKey(d => d.IdProject)
                    .HasConstraintName("projectForm_FK1");
            });

            modelBuilder.Entity<ProjectInterview>(entity =>
            {
                entity.HasKey(e => e.IdProjectInterview)
                    .HasName("PRIMARY");

                entity.ToTable("projectInterview");

                entity.HasIndex(e => e.IdProject, "projectInterview_FK1_idx");

                entity.Property(e => e.IdProjectInterview).HasColumnName("idProjectInterview");

                entity.Property(e => e.IdProject).HasColumnName("idProject");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProjectInterviews)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("projectInterview_FK1");
            });

            modelBuilder.Entity<ProjectPlatform>(entity =>
            {
                entity.HasKey(e => e.IdProjectPlatform)
                    .HasName("PRIMARY");

                entity.ToTable("projectPlatform");

                entity.HasIndex(e => e.IdProject, "projectGame_FK1_idx");

                entity.HasIndex(e => e.IdPlatform, "projectPlatform_FK2_idx");

                entity.Property(e => e.IdProjectPlatform).HasColumnName("idProjectPlatform");

                entity.Property(e => e.CohortSize).HasColumnName("cohortSize");

                entity.Property(e => e.IdPlatform).HasColumnName("idPlatform");

                entity.Property(e => e.IdProject).HasColumnName("idProject");

                entity.HasOne(d => d.IdPlatformNavigation)
                    .WithMany(p => p.ProjectPlatforms)
                    .HasForeignKey(d => d.IdPlatform)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("projectPlatform_FK2");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProjectPlatforms)
                    .HasForeignKey(d => d.IdProject)
                    .HasConstraintName("projectPlatform_FK1");
            });

            modelBuilder.Entity<ProjectPublisher>(entity =>
            {
                entity.HasKey(e => e.IdProjectPublisher)
                    .HasName("PRIMARY");

                entity.ToTable("projectPublisher");

                entity.HasIndex(e => e.IdProject, "projectDeveloper_FK1_idx");

                entity.HasIndex(e => e.IdCompany, "projectDeveloper_FK2_idx");

                entity.Property(e => e.IdProjectPublisher).HasColumnName("idProjectPublisher");

                entity.Property(e => e.IdCompany).HasColumnName("idCompany");

                entity.Property(e => e.IdProject).HasColumnName("idProject");

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.ProjectPublishers)
                    .HasForeignKey(d => d.IdCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("projectPublisher_FK20");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProjectPublishers)
                    .HasForeignKey(d => d.IdProject)
                    .HasConstraintName("projectPublisher_FK10");
            });

            modelBuilder.Entity<ProjectSummaryDoc>(entity =>
            {
                entity.HasKey(e => e.IdProjectSummaryDoc)
                    .HasName("PRIMARY");

                entity.ToTable("projectSummaryDoc");

                entity.HasIndex(e => e.IdProject, "projectSummaryDocs_FK1_idx");

                entity.Property(e => e.IdProjectSummaryDoc).HasColumnName("idProjectSummaryDoc");

                entity.Property(e => e.IdProject).HasColumnName("idProject");

                entity.Property(e => e.Label)
                    .HasMaxLength(45)
                    .HasColumnName("label");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProjectSummaryDocs)
                    .HasForeignKey(d => d.IdProject)
                    .HasConstraintName("projectSummaryDoc_FK1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.Property(e => e.IdPerson)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idPerson");

                entity.Property(e => e.IsDarkMode).HasColumnName("isDarkMode");

                entity.Property(e => e.IsPasswordResetRequired).HasColumnName("isPasswordResetRequired");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Status)
                    .HasColumnType("enum('Active','Inactive')")
                    .HasColumnName("status");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userFK1");
            });

            modelBuilder.Entity<UserPlatform>(entity =>
            {
                entity.HasKey(e => e.IdUserPlatform)
                    .HasName("PRIMARY");

                entity.ToTable("userPlatform");

                entity.HasIndex(e => e.IdUser, "userPlatform_FK1_idx");

                entity.HasIndex(e => e.IdPlatform, "userPlatform_FK2_idx");

                entity.HasIndex(e => e.CreatedBy, "userPlatform_FK3_idx");

                entity.HasIndex(e => e.RemovedBy, "userPlatform_FK4_idx");

                entity.Property(e => e.IdUserPlatform).HasColumnName("idUserPlatform");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.IdPlatform).HasColumnName("idPlatform");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.RemovedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("removedAt");

                entity.Property(e => e.RemovedBy).HasColumnName("removedBy");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.UserPlatformCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userPlatform_FK3");

                entity.HasOne(d => d.IdPlatformNavigation)
                    .WithMany(p => p.UserPlatforms)
                    .HasForeignKey(d => d.IdPlatform)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userPlatform_FK2");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserPlatformIdUserNavigations)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userPlatform_FK1");

                entity.HasOne(d => d.RemovedByNavigation)
                    .WithMany(p => p.UserPlatformRemovedByNavigations)
                    .HasForeignKey(d => d.RemovedBy)
                    .HasConstraintName("userPlatform_FK4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
