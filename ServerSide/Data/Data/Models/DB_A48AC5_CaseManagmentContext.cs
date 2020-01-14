using System;
using Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models
{
    public partial class DB_A48AC5_CaseManagmentContext : DbContext
    {
        public DB_A48AC5_CaseManagmentContext()
        {
        }

        public DB_A48AC5_CaseManagmentContext(DbContextOptions<DB_A48AC5_CaseManagmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActionTaken> ActionTaken { get; set; }
        public virtual DbSet<AspNetProfile> AspNetProfile { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<CaseEmbassy> CaseEmbassy { get; set; }
        public virtual DbSet<CaseForeignExporter> CaseForeignExporter { get; set; }
        public virtual DbSet<CaseImporter> CaseImporter { get; set; }
        public virtual DbSet<CaseStage> CaseStage { get; set; }
        public virtual DbSet<CaseType> CaseType { get; set; }
        public virtual DbSet<Cases> Cases { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentLanguage> DocumentLanguage { get; set; }
        public virtual DbSet<DomesticIndustry> DomesticIndustry { get; set; }
        public virtual DbSet<Embassies> Embassies { get; set; }
        public virtual DbSet<ForeignExporterProducers> ForeignExporterProducers { get; set; }
        public virtual DbSet<Government> Government { get; set; }
        public virtual DbSet<Importers> Importers { get; set; }
        public virtual DbSet<SendingMethod> SendingMethod { get; set; }
        public virtual DbSet<Structure> Structure { get; set; }
        public virtual DbSet<StructureType> StructureType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(DBGlobals.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<ActionTaken>(entity =>
            {
                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<AspNetProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_UserProfile");

                entity.Property(e => e.UserId)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(128);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.Property(e => e.AttachmentName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FolderName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.Attachment)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attachment_Document");
            });

            modelBuilder.Entity<CaseEmbassy>(entity =>
            {
                entity.HasOne(d => d.Case)
                    .WithMany(p => p.CaseEmbassy)
                    .HasForeignKey(d => d.CaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CaseEmbassy_Case");

                entity.HasOne(d => d.Embassy)
                    .WithMany(p => p.CaseEmbassy)
                    .HasForeignKey(d => d.EmbassyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CaseEmbassy_Embassies");
            });

            modelBuilder.Entity<CaseStage>(entity =>
            {
                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CaseType>(entity =>
            {
                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Cases>(entity =>
            {
                entity.HasKey(e => e.CaseId)
                    .HasName("PK_Case");

                entity.HasIndex(e => e.StructureId)
                    .HasName("IX_Cases")
                    .IsUnique();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.ActionTaken)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.ActionTakenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_ActionTaken");

                entity.HasOne(d => d.CaseStage)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.CaseStageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_CaseStage");

                entity.HasOne(d => d.CaseType)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.CaseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_CaseType");

                entity.HasOne(d => d.DomesticIndustry)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.DomesticIndustryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_DomesticIndustry");

                entity.HasOne(d => d.Government)
                    .WithMany(p => p.Cases)
                    .HasForeignKey(d => d.GovernmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Case_Government");

                entity.HasOne(d => d.Structure)
                    .WithOne(p => p.Cases)
                    .HasForeignKey<Cases>(d => d.StructureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cases_Structure");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasIndex(e => e.StructureId)
                    .HasName("IX_Document")
                    .IsUnique();

                entity.Property(e => e.CodeReference).HasMaxLength(100);

                entity.Property(e => e.CommentAr).HasMaxLength(350);

                entity.Property(e => e.CommentEn).HasMaxLength(350);

                entity.Property(e => e.FromWhome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SectorId).HasColumnName("SectorID");

                entity.Property(e => e.SendingDate).HasColumnType("date");

                entity.Property(e => e.SubjectAr)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SubjectEn)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ToWhome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Case)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.CaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_Cases");

                entity.HasOne(d => d.Structure)
                    .WithOne(p => p.Document)
                    .HasForeignKey<Document>(d => d.StructureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_Structure");
            });

            modelBuilder.Entity<DocumentLanguage>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DomesticIndustry>(entity =>
            {
                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Embassies>(entity =>
            {
                entity.HasKey(e => e.EmbassyId);

                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ForeignExporterProducers>(entity =>
            {
                entity.HasKey(e => e.ForeignExporterId);

                entity.ToTable("ForeignExporter_Producers");

                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Government>(entity =>
            {
                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Importers>(entity =>
            {
                entity.HasKey(e => e.ImporterId);

                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SendingMethod>(entity =>
            {
                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Structure>(entity =>
            {
                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.StructureParent)
                    .WithMany(p => p.InverseStructureParent)
                    .HasForeignKey(d => d.StructureParentId)
                    .HasConstraintName("FK_Structure_Structure");

                entity.HasOne(d => d.StructureType)
                    .WithMany(p => p.Structure)
                    .HasForeignKey(d => d.StructureTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Structure_StructureType");
            });

            modelBuilder.Entity<StructureType>(entity =>
            {
                entity.Property(e => e.StructureTypeId).ValueGeneratedNever();

                entity.Property(e => e.NameAr).HasMaxLength(50);

                entity.Property(e => e.NameEn).HasMaxLength(50);
            });
        }
    }
}
