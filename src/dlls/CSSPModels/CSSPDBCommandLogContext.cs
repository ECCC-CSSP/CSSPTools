/*
 * Manually edited
 * 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace CSSPModels
{
    public partial class CSSPDBCommandLogContext : DbContext
    {

        #region Properties
        public virtual DbSet<CSSPCommandLog> CSSPCommandLogs { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDBCommandLogContext()
        {
        }

        public CSSPDBCommandLogContext(DbContextOptions<CSSPDBCommandLogContext> options)
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