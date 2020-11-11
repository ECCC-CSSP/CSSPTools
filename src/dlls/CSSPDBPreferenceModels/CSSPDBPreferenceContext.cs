/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace CSSPDBPreferenceModels
{
    public partial class CSSPDBPreferenceContext : DbContext
    {

        #region Properties
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<TVItemUserAuthorization> TVItemUserAuthorizations { get; set; }
        public virtual DbSet<TVTypeUserAuthorization> TVTypeUserAuthorizations { get; set; }
        public virtual DbSet<Preference> Preferences { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDBPreferenceContext()
        {
        }

        public CSSPDBPreferenceContext(DbContextOptions<CSSPDBPreferenceContext> options)
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