/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace CSSPDBSearchModels
{
    public partial class CSSPDBSearchContext : DbContext
    {

        #region Properties
        public virtual DbSet<TVItem> TVItems { get; set; }
        public virtual DbSet<TVItemLanguage> TVItemLanguages { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDBSearchContext()
        {
        }

        public CSSPDBSearchContext(DbContextOptions<CSSPDBSearchContext> options)
            : base(options)
        {
        }
        #endregion Constructors
    }
}