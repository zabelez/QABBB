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
        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<GamePlatform> GamePlatforms { get; set; } = null!;
        public virtual DbSet<Heatmap> Heatmaps { get; set; } = null!;
        public virtual DbSet<HeatmapLayer> HeatmapLayers { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Platform> Platforms { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectFile> ProjectFiles { get; set; } = null!;
        public virtual DbSet<ProjectForm> ProjectForms { get; set; } = null!;
        public virtual DbSet<ProjectPlatform> ProjectPlatforms { get; set; } = null!;
        public virtual DbSet<ProjectSummaryDoc> ProjectSummaryDocs { get; set; } = null!;
        public virtual DbSet<TesterUploadedFile> TesterUploadedFiles { get; set; } = null!;
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

                entity.Property(e => e.IdCompany).HasColumnName("idCompany");

                entity.Property(e => e.Logo).HasColumnName("logo");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
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
                    .HasMaxLength(45)
                    .HasColumnName("subject");

                entity.Property(e => e.Text)
                    .HasMaxLength(45)
                    .HasColumnName("text");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.IdGame)
                    .HasName("PRIMARY");

                entity.ToTable("game");

                entity.HasIndex(e => e.IdPublisher, "gameFK1_idx");

                entity.HasIndex(e => e.IdDeveloper, "gameFK2_idx");

                entity.Property(e => e.IdGame).HasColumnName("idGame");

                entity.Property(e => e.Gamelogo).HasColumnName("gamelogo");

                entity.Property(e => e.IdDeveloper).HasColumnName("idDeveloper");

                entity.Property(e => e.IdPublisher).HasColumnName("idPublisher");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdDeveloperNavigation)
                    .WithMany(p => p.GameIdDeveloperNavigations)
                    .HasForeignKey(d => d.IdDeveloper)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gameFK2");

                entity.HasOne(d => d.IdPublisherNavigation)
                    .WithMany(p => p.GameIdPublisherNavigations)
                    .HasForeignKey(d => d.IdPublisher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gameFK1");
            });

            modelBuilder.Entity<GamePlatform>(entity =>
            {
                entity.HasKey(e => e.IdGamePlatform)
                    .HasName("PRIMARY");

                entity.ToTable("gamePlatform");

                entity.HasIndex(e => e.IdGame, "gamePlatformFK1_idx");

                entity.HasIndex(e => e.IdPlatform, "gamePlatformFK2_idx");

                entity.Property(e => e.IdGamePlatform).HasColumnName("idGamePlatform");

                entity.Property(e => e.IdGame).HasColumnName("idGame");

                entity.Property(e => e.IdPlatform).HasColumnName("idPlatform");

                entity.HasOne(d => d.IdGameNavigation)
                    .WithMany(p => p.GamePlatforms)
                    .HasForeignKey(d => d.IdGame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gamePlatformFK1");

                entity.HasOne(d => d.IdPlatformNavigation)
                    .WithMany(p => p.GamePlatforms)
                    .HasForeignKey(d => d.IdPlatform)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gamePlatformFK2");
            });

            modelBuilder.Entity<Heatmap>(entity =>
            {
                entity.HasKey(e => e.IdHeatmap)
                    .HasName("PRIMARY");

                entity.ToTable("heatmap");

                entity.HasIndex(e => e.IdProject, "heatmap_FK1_idx");

                entity.Property(e => e.IdHeatmap).HasColumnName("idHeatmap");

                entity.Property(e => e.Color)
                    .HasMaxLength(9)
                    .HasColumnName("color");

                entity.Property(e => e.IdProject).HasColumnName("idProject");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.Heatmaps)
                    .HasForeignKey(d => d.IdProject)
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
                entity.HasKey(e => e.Idlog)
                    .HasName("PRIMARY");

                entity.ToTable("log");

                entity.HasIndex(e => e.IdUser, "log_FK1_idx");

                entity.Property(e => e.Idlog)
                    .ValueGeneratedNever()
                    .HasColumnName("idlog");

                entity.Property(e => e.Date)
                    .HasMaxLength(45)
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

                entity.Property(e => e.CohortSize).HasColumnName("cohortSize");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.PowerBiUrl).HasColumnName("powerBiURL");

                entity.Property(e => e.SpreadsheetUrl).HasColumnName("spreadsheetUrl");

                entity.Property(e => e.StartDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("startDateTime");
            });

            modelBuilder.Entity<ProjectFile>(entity =>
            {
                entity.HasKey(e => e.IdProjectFiles)
                    .HasName("PRIMARY");

                entity.ToTable("projectFile");

                entity.HasIndex(e => e.IdProject, "projectFile_FK1_idx");

                entity.Property(e => e.IdProjectFiles).HasColumnName("idProjectFiles");

                entity.Property(e => e.IdProject).HasColumnName("idProject");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProjectFiles)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
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
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProjectForms)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("projectForm_FK1");
            });

            modelBuilder.Entity<ProjectPlatform>(entity =>
            {
                entity.HasKey(e => e.IdProjectPlatform)
                    .HasName("PRIMARY");

                entity.ToTable("projectPlatform");

                entity.HasIndex(e => e.IdProject, "projectPlatform_FK1_idx");

                entity.HasIndex(e => e.IdGamePlatform, "projectPlatform_FK2_idx");

                entity.Property(e => e.IdProjectPlatform).HasColumnName("idProjectPlatform");

                entity.Property(e => e.IdGamePlatform).HasColumnName("idGamePlatform");

                entity.Property(e => e.IdProject).HasColumnName("idProject");

                entity.HasOne(d => d.IdGamePlatformNavigation)
                    .WithMany(p => p.ProjectPlatforms)
                    .HasForeignKey(d => d.IdGamePlatform)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("projectPlatform_FK2");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProjectPlatforms)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("projectPlatform_FK1");
            });

            modelBuilder.Entity<ProjectSummaryDoc>(entity =>
            {
                entity.HasKey(e => e.IdProjectSummaryDocs)
                    .HasName("PRIMARY");

                entity.ToTable("projectSummaryDocs");

                entity.HasIndex(e => e.IdProject, "projectSummaryDocs_FK1_idx");

                entity.Property(e => e.IdProjectSummaryDocs).HasColumnName("idProjectSummaryDocs");

                entity.Property(e => e.IdProject).HasColumnName("idProject");

                entity.Property(e => e.Label)
                    .HasMaxLength(45)
                    .HasColumnName("label");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProjectSummaryDocs)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("projectSummaryDocs_FK1");
            });

            modelBuilder.Entity<TesterUploadedFile>(entity =>
            {
                entity.HasKey(e => e.IdTesterUploadedFiles)
                    .HasName("PRIMARY");

                entity.ToTable("testerUploadedFiles");

                entity.HasIndex(e => e.IdProject, "testerUploadedFiles_FK1_idx");

                entity.Property(e => e.IdTesterUploadedFiles).HasColumnName("idTesterUploadedFiles");

                entity.Property(e => e.IdProject).HasColumnName("idProject");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.TesterUploadedFiles)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("testerUploadedFiles_FK1");
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
                    .HasMaxLength(45)
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

                entity.Property(e => e.IdUserPlatform).HasColumnName("idUserPlatform");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.IdPlatform).HasColumnName("idPlatform");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.RemovedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("removedAt");

                entity.HasOne(d => d.IdPlatformNavigation)
                    .WithMany(p => p.UserPlatforms)
                    .HasForeignKey(d => d.IdPlatform)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userPlatform_FK2");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserPlatforms)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userPlatform_FK1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
