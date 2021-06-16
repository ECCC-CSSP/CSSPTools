/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace ManageServices
{
    public partial class CSSPDBManageContext : DbContext
    {

        #region Properties
        public virtual DbSet<CommandLog> CommandLogs { get; set; }
        public virtual DbSet<ManageFile> ManageFiles { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<TVItemUserAuthorization> TVItemUserAuthorizations { get; set; }
        public virtual DbSet<TVTypeUserAuthorization> TVTypeUserAuthorizations { get; set; }

        #endregion Properties

        #region Constructors
        public CSSPDBManageContext()
        {
        }

        public CSSPDBManageContext(DbContextOptions<CSSPDBManageContext> options)
            : base(options)
        {
        }
        #endregion Constructors
    }
}