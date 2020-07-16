/*
 * Manually edited
 * 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace CSSPModels
{
    public partial class CSSPFilesManagementDBContext : DbContext
    {

        #region Properties
        public virtual DbSet<CSSPFile> CSSPFiles { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPFilesManagementDBContext()
        {
        }

        public CSSPFilesManagementDBContext(DbContextOptions<CSSPFilesManagementDBContext> options)
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