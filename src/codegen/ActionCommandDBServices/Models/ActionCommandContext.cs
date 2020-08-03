using Microsoft.EntityFrameworkCore;

namespace ActionCommandDBServices.Models
{
    public partial class ActionCommandContext : DbContext
    {
        public ActionCommandContext()
        {
        }

        public ActionCommandContext(DbContextOptions<ActionCommandContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActionCommand> ActionCommands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionCommand>(entity =>
            {
                entity.HasKey(e => e.ActionCommandID);

                entity.HasIndex(e => e.ActionCommandID)
                    .IsUnique();

                entity.Property(e => e.ActionCommandID)
                    .HasColumnName("ActionCommandID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Action).IsRequired();
                entity.Property(e => e.Command).IsRequired();
                entity.Property(e => e.FullFileName).IsRequired();
                entity.Property(e => e.Description);
                entity.Property(e => e.ErrorText);
                entity.Property(e => e.ExecutionStatusText);
                entity.Property(e => e.FilesStatusText);
                entity.Property(e => e.PercentCompleted);
                entity.Property(e => e.LastUpdateDate).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
