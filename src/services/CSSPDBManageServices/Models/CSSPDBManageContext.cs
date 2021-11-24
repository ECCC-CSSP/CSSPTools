namespace ManageServices;

public partial class CSSPDBManageContext : DbContext
{
    public virtual DbSet<CommandLog> CommandLogs { get; set; }
    public virtual DbSet<ManageFile> ManageFiles { get; set; }
    public virtual DbSet<Contact> Contacts { get; set; }
    public virtual DbSet<TVItemUserAuthorization> TVItemUserAuthorizations { get; set; }
    public virtual DbSet<TVTypeUserAuthorization> TVTypeUserAuthorizations { get; set; }


    public CSSPDBManageContext()
    {
    }

    public CSSPDBManageContext(DbContextOptions<CSSPDBManageContext> options)
        : base(options)
    {
    }
}
