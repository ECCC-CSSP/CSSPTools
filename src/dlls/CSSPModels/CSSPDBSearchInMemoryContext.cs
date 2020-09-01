/*
 * Manually edited
 * 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace CSSPModels
{
    public partial class CSSPDBSearchInMemoryContext : DbContext
    {

        #region Properties
        public virtual DbSet<TVItem> TVItems { get; set; }
        public virtual DbSet<TVItemLanguage> TVItemLanguages { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDBSearchInMemoryContext()
        {
        }

        public CSSPDBSearchInMemoryContext(DbContextOptions<CSSPDBSearchInMemoryContext> options)
            : base(options)
        {
        }
        #endregion Constructors

        #region Overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion Overrides
    }
}