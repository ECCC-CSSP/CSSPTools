/*
 * Manually edited
 * 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace CSSPDBFilesManagementModels
{
    public partial class CSSPDBFilesManagementContext : DbContext
    {

        #region Properties
        public virtual DbSet<FilesManagement> FilesManagements { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDBFilesManagementContext()
        {
        }

        public CSSPDBFilesManagementContext(DbContextOptions<CSSPDBFilesManagementContext> options)
            : base(options)
        {
        }
        #endregion Constructors
    }
}