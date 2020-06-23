using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ETMS.Service.DataAccessLayer.Models
{
    public partial class EMTSDbContext : DbContext
    {
        public EMTSDbContext()
        {
        }

        public EMTSDbContext(DbContextOptions<EMTSDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeInfo> EmployeeInfo { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectAllocation> ProjectAllocation { get; set; }
        public virtual DbSet<TimeEntry> TimeEntry { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=APANANGATT01;Database=ETMS;User Id=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeInfo>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ProjectAllocation>(entity =>
            {
                entity.Property(e => e.AllocationId).ValueGeneratedNever();
            });

            modelBuilder.Entity<TimeEntry>(entity =>
            {
                entity.Property(e => e.TimeEntryId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CCAC39544B57");

                entity.Property(e => e.PasswordText).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
