/*
 * Manually edited
 * 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace CSSPDBCommandLogModels
{
    public partial class CSSPDBCommandLogContext : DbContext
    {

        #region Properties
        public virtual DbSet<CommandLog> CommandLogs { get; set; }
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
    }
}