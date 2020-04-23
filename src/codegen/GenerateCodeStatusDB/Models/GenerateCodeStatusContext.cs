using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GenerateCodeStatusDB.Models
{
    public partial class GenerateCodeStatusContext : DbContext
    {
        public GenerateCodeStatusContext()
        {
        }

        public GenerateCodeStatusContext(DbContextOptions<GenerateCodeStatusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GenerateCodeStatus> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlite("DataSource=C:\\Users\\charl\\AppData\\Roaming\\CSSP\\GenerateCodeStatus.db");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenerateCodeStatus>(entity =>
            {
                entity.HasKey(e => e.StatusID);

                entity.HasIndex(e => e.StatusID)
                    .IsUnique();

                entity.Property(e => e.StatusID)
                    .HasColumnName("StatusID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Command).IsRequired();

                entity.Property(e => e.LastUpdateDate).IsRequired();

                entity.Property(e => e.ErrorText);

                entity.Property(e => e.StatusText);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
